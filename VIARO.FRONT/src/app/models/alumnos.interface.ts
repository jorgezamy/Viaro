export interface IAlumnos {
  id: string;
  nombre: string;
  apellido: string;
  genero: string;
  fechaNacimiento: string;
}

export interface IAlumnoRequest {
  nombre: string;
  apellido: string;
  genero: string;
  fechaNacimiento: string;
}
