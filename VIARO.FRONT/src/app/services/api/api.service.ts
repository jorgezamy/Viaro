import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAlumnoRequest, IAlumnos } from '../../models/alumnos.interface';
import { IResponse } from '../../models/response.interface';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private _http: HttpClient) {}

  private baseUrl = 'https://localhost:7230/api/';

  getAlumnos(): Observable<IAlumnos[]> {
    const url = `${this.baseUrl}Alumnos`;

    return this._http.get<IAlumnos[]>(url, {
      headers: { 'Content-Type': 'application/json' },
    });
  }

  createAlumno(alumno: IAlumnoRequest): Observable<IResponse> {
    const url = `${this.baseUrl}Alumnos`;

    return this._http.post<IResponse>(url, alumno, {
      headers: { 'Content-Type': 'application/json' },
    });
  }

  updateAlumno(alumno: IAlumnos): Observable<IResponse> {
    const url = `${this.baseUrl}Alumnos/${alumno.id}`;

    return this._http.put<IResponse>(url, alumno, {
      headers: { 'Content-Type': 'application/json' },
    });
  }

  deleteAlumno(id: string): Observable<IResponse> {
    const url = `${this.baseUrl}Alumnos/${id}`;

    return this._http.delete<IResponse>(url, {
      headers: { 'Content-Type': 'application/json' },
    });
  }
}
