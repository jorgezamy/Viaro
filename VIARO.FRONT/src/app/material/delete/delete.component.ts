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
import { ModalDelete } from '../../models/modal.interface';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatDividerModule,
  ],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css',
})
export class DeleteComponent {
  id = '';

  constructor(
    private _http: ApiService,
    private _dialogRef: MatDialogRef<DeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ModalDelete
  ) {
    this.id = data.id;
  }

  onSubmit() {
    this._http.deleteAlumno(this.id).subscribe((data) => console.log(data));
    this._dialogRef.close();
  }
}
