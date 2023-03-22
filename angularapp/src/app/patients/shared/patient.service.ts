import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, tap } from "rxjs";

import { MessageService } from "primeng/api";
import { Patient } from "./patient.model";

@Injectable({ providedIn: 'root' })
export class PatientService {

  private patientsUrl = 'https://localhost:7211/patients';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  getAll(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.patientsUrl)
      .pipe(
        tap(_ => this.log('fetched patients')),
        catchError(this.handleError())
      );
  }

  update(patient: Patient): Observable<any> {
    return this.http.put(this.patientsUrl, patient, this.httpOptions).pipe(
      tap(_ => this.log(`updated patient id=${patient.id}`)),
      catchError(this.handleError())
    );
  }

  private handleError(): any {
    //this.messageService.add({ severity: 'success', summary: 'File Uploaded', detail: '' });
  };

  private log(message: string) {
    //this.messageService.add(`PatientService: ${message}`);
  }

}
