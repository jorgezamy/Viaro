import { Routes } from '@angular/router';
import { AlumnosComponent } from './components/alumnos/alumnos.component';
import { ProfesoresComponent } from './components/profesores/profesores.component';
import { GradosComponent } from './components/grados/grados.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
  },

  {
    path: 'alumnos',
    component: AlumnosComponent,
  },
  {
    path: 'profesores',
    component: ProfesoresComponent,
  },
  {
    path: 'grados',
    component: GradosComponent,
  },
];
