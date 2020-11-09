import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Assignment } from './assignment';
import { CustomerDetails } from './customer-details';

@Injectable({ providedIn: 'root' })
export class AssignmentService {

  private assignmentsUrl;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    this.assignmentsUrl = this.baseUrl + 'api/assignments';
  }

  getAssignments(): Observable<Assignment[]> {
    return this.http.get<Assignment[]>(this.assignmentsUrl, this.httpOptions);
  }

  createAssignment(customerDetails: CustomerDetails) : Observable<Assignment> {
    return this.http.post<Assignment>(this.assignmentsUrl, customerDetails, this.httpOptions);
  }

  deleteAssignment(assignmentId: string): Observable<Object> {
    return this.http.delete(`${this.assignmentsUrl}/${assignmentId}`);
  }
}
