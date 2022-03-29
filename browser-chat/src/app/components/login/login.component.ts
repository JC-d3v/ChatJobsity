import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  authenticated: boolean = true;
  email: string = '';
  password: string = '';
  constructor(public usersService: UsersService) { }

  ngOnInit(): void {
  }

  login() {
    this.authenticated = !this.authenticated;
    this.usersService.login(this.email, this.password).subscribe(
      response => {
        this.usersService.saveStorage(response.auth_token, response.id);
      }
    )
  }
}
