import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Lesson01PageComponent } from './lesson-01/lesson01-page/lesson01-page.component';
import { MainPageComponent } from './main-page/main-page.component';
import { Lesson02PageComponent } from './lesson-02/lesson02-page/lesson02-page.component';
import { Lesson03PageComponent } from './lesson-03/lesson03-page/lesson03-page.component';
import { Lesson04PageComponent } from './lesson-04/lesson04-page/lesson04-page.component';

const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'lesson-01', component: Lesson01PageComponent },
  { path: 'lesson-02', component: Lesson02PageComponent },
  { path: 'lesson-03', component: Lesson03PageComponent },
  { path: 'lesson-04', component: Lesson04PageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
