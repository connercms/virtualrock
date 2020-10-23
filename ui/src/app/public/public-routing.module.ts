import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublicIndexComponent } from './components/public-index/public-index.component';

const routes: Routes = [
  {
    path: '',
    component: PublicIndexComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule {}
