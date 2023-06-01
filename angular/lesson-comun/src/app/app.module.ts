import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { V1CommunComponent } from './comp/v1-commun/v1-commun.component';
import { InputComponent } from './comp/input/input.component';

@NgModule({
  declarations: [
    AppComponent,
    V1CommunComponent,
    InputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
