import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsRoutingModule } from './students-routing.module';
import { StudentsShellComponent } from './containers/students-shell/students-shell.component';


@NgModule({
  declarations: [StudentsShellComponent],
  imports: [
    CommonModule,
    StudentsRoutingModule
  ],
  entryComponents: [StudentsShellComponent]
})
export class StudentsModule { }
