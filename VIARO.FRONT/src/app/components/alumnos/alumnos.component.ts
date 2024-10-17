import { Component } from '@angular/core';
import { ApiService } from '../../services/api/api.service';
import { CommonModule } from '@angular/common';
import { IAlumnoRequest, IAlumnos } from '../../models/alumnos.interface';

import { MatDialog } from '@angular/material/dialog';

import { NuevoAumnoComponent } from '../../material/nuevo-aumno/nuevo-aumno.component';
import { DeleteComponent } from '../../material/delete/delete.component';

@Component({
  selector: 'app-alumnos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './alumnos.component.html',
  styleUrl: './alumnos.component.css',
})
export class AlumnosComponent {
  constructor(private _api: ApiService, public dialog: MatDialog) {}

  alumnos: IAlumnos[] = [];

  formAlumno: IAlumnoRequest = {
    nombre: '',
    apellido: '',
    genero: '',
    fechaNacimiento: '',
  };

  getAlumnos() {
    this._api.getAlumnos().subscribe((data) => (this.alumnos = data));
  }

  ngOnInit() {
    this.getAlumnos();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NuevoAumnoComponent, {
      width: '750px',
      disableClose: true,
      data: {
        alumno: {
          nombre: '',
          apellido: '',
          genero: '',
          fechaNacimiento: '',
        },
        titulo: 'Nuevo Alumno',
        tipo: 'crear',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.getAlumnos();
    });
  }

  editAlumno(alumno: IAlumnos) {
    this.formAlumno = { ...alumno };

    const dialogRef = this.dialog.open(NuevoAumnoComponent, {
      data: {
        alumno: this.formAlumno,
        titulo: 'Editar Alumno',
        tipo: 'actualizar',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.getAlumnos();
    });
  }

  deleteDialog(id: string): void {
    const dialogRef = this.dialog.open(DeleteComponent, {
      width: '750px',
      disableClose: true,
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.getAlumnos();
    });
  }
}
