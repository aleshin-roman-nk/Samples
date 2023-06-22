import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Lesson01PageComponent } from './lesson-01/lesson01-page/lesson01-page.component';
import { MainPageComponent } from './main-page/main-page.component';

const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'lesson-01', component: Lesson01PageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
