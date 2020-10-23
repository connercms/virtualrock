import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './public-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { PublicIndexComponent } from './components/public-index/public-index.component';
import { PublicService } from './services/public.service';

@NgModule({
  declarations: [PublicIndexComponent],
  imports: [
    CommonModule,
    PublicRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ],
  providers: [PublicService]
})
export class PublicModule {}
