import { Component, OnInit } from '@angular/core';

declare var particlesJS: any;

@Component({
  selector: 'app-home-index',
  templateUrl: './home-index.component.html',
  styleUrls: ['./home-index.component.scss']
})
export class HomeIndexComponent implements OnInit {
  constructor() {}

  ngOnInit() {
    particlesJS.load('particles-js', 'assets/data/particles.json', function () {
      console.log('particles.js config loaded');
    });
  }
}
