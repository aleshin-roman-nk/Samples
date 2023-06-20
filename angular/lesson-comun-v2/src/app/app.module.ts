import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputComponent } from './comps/input/input.component';
import { StudentComponent } from './comps/student/student.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductComponent } from './comps/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    InputComponent,
    StudentComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
