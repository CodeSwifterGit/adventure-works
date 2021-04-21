import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { AppLoaderComponent } from './app-loader.component';

@Injectable()
export class AppLoaderService {
  dialogRef: MatDialogRef<AppLoaderComponent>;

  constructor(private readonly dialog: MatDialog) {}

  open(title: string = 'Please wait'): Observable<boolean> {
    this.dialogRef = this.dialog.open(AppLoaderComponent, { disableClose: true, backdropClass: 'light-backdrop' });
    this.dialogRef.updateSize('200px');
    this.dialogRef.componentInstance.title = title;
    return this.dialogRef.afterClosed();
  }

  close() {
    if (this.dialogRef) {
      this.dialogRef.close();
    }
  }
}
