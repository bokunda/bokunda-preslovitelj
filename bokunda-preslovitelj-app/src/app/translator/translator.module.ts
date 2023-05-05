import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TranslatorRoutingModule } from './translator-routing.module';
import { TranslatorMainComponent } from './translator-main/translator-main.component';
import { TranslatorEditComponent } from './translator-main/translator-edit/translator-edit.component';
import { MaterialModule } from '../shared/material/material.module';
import { SharedModule } from '../shared/shared/shared.module';


@NgModule({
  declarations: [
    TranslatorMainComponent,
    TranslatorEditComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    TranslatorRoutingModule
  ],
  exports: [
    TranslatorMainComponent,
    TranslatorEditComponent
  ]
})
export class TranslatorModule { }
