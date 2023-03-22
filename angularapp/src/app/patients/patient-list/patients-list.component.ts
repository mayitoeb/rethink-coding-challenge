import { Component, OnInit } from '@angular/core';

import { Patient } from '../shared/patient.model';
import { PatientService } from '../shared/patient.service';

@Component({
  selector: 'patient-list',
  templateUrl: './patient-list.component.html',
})
export class PatientListComponent implements OnInit {

  loading: boolean = true;
  patients: Patient[] = [];

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.getPatients();
  }

  getPatients(): void {
    this.patientService.getAll()
      .subscribe(patients => {
        this.patients = patients;
        this.loading = false;
      });
  }

}
