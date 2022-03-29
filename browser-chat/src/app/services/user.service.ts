import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  public users: User[] = [];
  token?: string = '';
  userId?: number = 0;

  constructor(private http: HttpClient) {
    this.loadStorage();
  }

  loadStorage() {
    if (sessionStorage.getItem('Token')) {
      this.token = sessionStorage.getItem('Token')?.toString();
      this.userId = Number(sessionStorage.getItem('UserId')?.toString());
    } else {
      this.token = '';
      this.userId = 0;
      // this.menu = [];
    }
  }
  saveStorage(token: string, userId: number) {
    sessionStorage.setItem('Token', token);
    sessionStorage.setItem('UserId', userId.toString());
    this.userId = userId;
    this.token = token;
  }

  addUser() {
    // TODO: REVISAR POST
    this.http.get(environment.serviceURL + '/users')
      .subscribe(response => {
        console.log(`servico para addiion de usuarios`);
      });
  }
  login(email: string, password: string) {
    // TODO: REVISAR POST
    return this.http.post(environment.serviceURL + '/users/login/', { email, password }).pipe(
      map((response: any) => {
        return response;
      })
    );
  }
}
