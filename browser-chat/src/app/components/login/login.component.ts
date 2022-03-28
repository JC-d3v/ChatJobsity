import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  authenticated: boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  login() {
    this.authenticated = !this.authenticated;
  }
}
