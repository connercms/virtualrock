import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedRoutingModule } from './shared-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { UserService } from './services/user.service';

@NgModule({
  declarations: [HeaderComponent],
  imports: [CommonModule, SharedRoutingModule],
  exports: [HeaderComponent],
  providers: [UserService]
})
export class SharedModule {}
