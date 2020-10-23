import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { HomeIndexComponent } from './components/home-index/home-index.component';
import { HomeRoutingModule } from './home-routing.module';
import { UsersComponent } from './components/users/users.component';

@NgModule({
  declarations: [HomeIndexComponent, UsersComponent],
  imports: [CommonModule, HomeRoutingModule, SharedModule]
})
export class HomeModule {}
