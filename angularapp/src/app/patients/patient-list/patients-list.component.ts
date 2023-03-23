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
      .subscribe(data => {
        this.patients = data;
        this.loading = false;
      });
  }

  onRowEditInit(patient: Patient) {
    //patient.birthday = new Date(patient.birthday)
    this.clonedPatients[patient.id] = { ...patient };
  }

  onRowEditSave(patient: Patient) {
    this.patientService.update(patient)
      .subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Patient is updated' });
      });
  }

  onRowEditCancel(patient: Patient, index: number) {
    this.patients[index] = this.clonedPatients[patient.id];
    delete this.clonedPatients[patient.id];
  }

}
