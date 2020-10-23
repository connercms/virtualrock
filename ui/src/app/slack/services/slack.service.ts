import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SlackService {
  constructor(private http: HttpClient) {}

  completeAuthentication(code: string) {
    // TODO: Move these somewhere secure
    const client_id = '3025985651.1457668188753';
    const client_secret = 'b607edda4102b0df1a3c45ee0ede55a8';

    return this.http.get(
      `https://slack.com/api/oauth.v2.access?client_id=${client_id}&client_secret=${client_secret}&code=${code}`
    );
  }
}
