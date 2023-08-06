import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Lesson01PageComponent } from './lesson-01/lesson01-page/lesson01-page.component';
import { MainPageComponent } from './main-page/main-page.component';
import { Lesson02PageComponent } from './lesson-02/lesson02-page/lesson02-page.component';
import { UserInputComponent } from './lesson-02/comps/user-input/user-input.component';
import { FormsModule } from '@angular/forms';
import { UserInput1Component } from './lesson-02/comps/user-input1/user-input1.component';
import { ModalFormComponent } from './comps/modal-form/modal-form.component';
import { ModalFormAComponent } from './comps/modal-form-a/modal-form-a.component';
import { Lesson03PageComponent } from './lesson-03/lesson03-page/lesson03-page.component';
import { Lesson04PageComponent } from './lesson-04/lesson04-page/lesson04-page.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalComponent } from './lesson-04/modal/modal.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { ModalAComponent } from './lesson-04/modal-a/modal-a.component';

@NgModule({
  declarations: [
    AppComponent,
    Lesson01PageComponent,
    MainPageComponent,
    Lesson02PageComponent,
    UserInputComponent,
    UserInput1Component,
    ModalFormComponent,
    ModalFormAComponent,
    Lesson03PageComponent,
    Lesson04PageComponent,
    ModalComponent,
    ModalAComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
