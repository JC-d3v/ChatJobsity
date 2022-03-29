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

  constructor(private http: HttpClient) { }

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
