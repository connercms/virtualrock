import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SlackRoutingModule } from './slack-routing.module';
import { RedirectComponent } from './components/redirect/redirect.component';
import { SlackService } from './services/slack.service';

@NgModule({
  declarations: [RedirectComponent],
  imports: [CommonModule, SlackRoutingModule],
  providers: [SlackService]
})
export class SlackModule {}
