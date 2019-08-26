import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from '@_shared/shared-routing.module';
import { MaterialModule } from '@_shared/material.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedRoutingModule,
    MaterialModule
  ],
  exports: [
    MaterialModule
  ]
})
export class SharedModule { }
