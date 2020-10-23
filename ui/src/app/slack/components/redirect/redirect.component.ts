import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { SlackService } from '../../services/slack.service';
import { tap, first } from 'rxjs/operators';
import { SlackResponse } from '../../interfaces/slack-response.interface';

@Component({
  selector: 'app-redirect',
  templateUrl: './redirect.component.html',
  styleUrls: ['./redirect.component.scss']
})
export class RedirectComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    private slackService: SlackService,
    private userService: UserService
  ) {}

  ngOnInit() {
    console.log('test');
    this.activatedRoute.queryParamMap
      .pipe(first((paramMap) => paramMap.has('code')))
      .subscribe((paramMap) => {
        console.log(paramMap);
        this.slackService
          .completeAuthentication(paramMap.get('code'))
          .subscribe((response: SlackResponse) => {
            console.log(response);
            if (response.ok) {
              console.log('Hooray!');
              this.userService
                .createUser({
                  slackId: response.authed_user.id
                })
                .subscribe(console.log);
            }
          });
      });
  }
}
