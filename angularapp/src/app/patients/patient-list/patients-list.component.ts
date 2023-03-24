import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';

import { Patient } from '../shared/patient.model';
import { PatientService } from '../shared/patient.service';

@Component({
  selector: 'patient-list',
  templateUrl: './patient-list.component.html',
  styles: [`
        :host ::ng-deep .p-cell-editing {
            padding-top: 0 !important;
            padding-bottom: 0 !important;
        }
    `]
})
export class PatientListComponent implements OnInit {

  loading: boolean = true;
  genders: string[] = ['M', 'F']
  patients: Patient[] = [];
  clonedPatients: { [s: string]: Patient; } = {};

  constructor(private messageService: MessageService,
    private patientService: PatientService) { }

  ngOnInit(): void {
    this.getPatients();
  }

  getPatients(): void {
    this.patientService.getAll()
      .subscribe({
        next: (data) => {
          this.patients = data;
          this.loading = false;
        },
        error: (e) => this.messageService.add({ severity: 'error', summary: 'Error', detail: 'There was an error getting the patients.' })
      });
  }

  onRowEditInit(patient: Patient) {
    patient.birthday = new Date(patient.birthday)
    this.clonedPatients[patient.id] = { ...patient };
  }

  onRowEditSave(patient: Patient, index: number) {
    this.patientService.update(patient)
      .subscribe({
        next: () => this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Patient is updated' }),
        error: (e) => {
          if (e.status == 400) {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Patient is not valid.' })
          } else {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'There was an error updating the patient.' })
          }

          this.patients[index] = this.clonedPatients[patient.id];
        }
      });
  }

  onRowEditCancel(patient: Patient, index: number) {
    this.patients[index] = this.clonedPatients[patient.id];
    delete this.clonedPatients[patient.id];
  }

}
