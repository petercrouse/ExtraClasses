import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentsShellComponent } from './containers/students-shell/students-shell.component';

const routes: Routes = [
  { path: '', component: StudentsShellComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentsRoutingModule { }
