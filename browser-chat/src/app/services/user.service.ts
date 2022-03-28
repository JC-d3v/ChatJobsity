import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private apiURL: string = 'https://localhost:44332/api/users';

  public users: User[] = [];

  constructor(private http: HttpClient) { }

  addUser() {
    // TODO: REVISAR POST
    this.http.get(this.apiURL)
      .subscribe(response => {
        console.log(`servico para addiion de usuarios`);
      });
  }

}
