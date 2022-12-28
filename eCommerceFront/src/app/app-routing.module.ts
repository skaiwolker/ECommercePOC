import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninComponent } from './core/signin/signin.component';

const routes: Routes = [
  {
  path: '',
  loadChildren: () => import('./home/home.module').then(h => h.HomeModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
