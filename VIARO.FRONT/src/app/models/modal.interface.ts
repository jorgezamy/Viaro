import { IAlumnos } from './alumnos.interface';

export interface ModalType {
  alumno: IAlumnos;
  titulo: string;
  tipo: 'crear' | 'actualizar';
}

export interface ModalDelete {
  id: string;
}
