import { Component, Inject } from '@angular/core';

import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDividerModule } from '@angular/material/divider';

import { ApiService } from '../../services/api/api.service';
import { IAlumnoRequest, IAlumnos } from '../../models/alumnos.interface';
import { FormsModule } from '@angular/forms';
import { ModalType } from '../../models/modal.interface';

@Component({
  selector: 'app-nuevo-aumno',
  standalone: true,
  imports: [
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatDividerModule,
  ],
  templateUrl: './nuevo-aumno.component.html',
  styleUrl: './nuevo-aumno.component.css',
})
export class NuevoAumnoComponent {
  createAlumno: IAlumnoRequest = {
    nombre: '',
    apellido: '',
    genero: '',
    fechaNacimiento: '',
  };

  alumno: IAlumnos = {
    id: '',
    nombre: '',
    apellido: '',
    genero: '',
    fechaNacimiento: '',
  };

  titulo = '';
  tipo = '';

  constructor(
    private _dialogRef: MatDialogRef<NuevoAumnoComponent>,
    private _api: ApiService,
    @Inject(MAT_DIALOG_DATA) public data: ModalType
  ) {
    this.alumno = { ...data.alumno };
    this.titulo = data.titulo;
    this.tipo = data.tipo;
  }

  onSubmit() {
    if (
      this.alumno.nombre &&
      this.alumno.apellido &&
      this.alumno.genero &&
      this.alumno.fechaNacimiento
    ) {
      this.createAlumno = {
        nombre: this.alumno.nombre,
        apellido: this.alumno.apellido,
        genero: this.alumno.genero,
        fechaNacimiento: this.alumno.fechaNacimiento,
      };

      console.log('this.tipo', this.tipo);

      if (this.tipo == 'crear') {
        this._api
          .createAlumno(this.createAlumno)
          .subscribe((data) => console.log(data));
      }
      if (this.tipo == 'actualizar') {
        console.log('se actualizo');

        this._api
          .updateAlumno(this.alumno)
          .subscribe((data) => console.log(data));
      }
      this._dialogRef.close();
    }
  }
}
