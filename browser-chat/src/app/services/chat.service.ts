import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { Message } from '../interfaces/message.interface';
import { UsersService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  public chats: Message[] = [];

  // chats_temp: Message[] = [
  //   {
  //     MessageId: 1,
  //     Userid: 1,
  //     ChatroomID: 1,
  //     text: 'string',
  //     time:"2018-08-01"
  //   }

  // ]

  constructor(private http: HttpClient,
    private userService: UsersService
  ) { }

  // loadMessages() {
  //   // this.chats = this.chats_temp;
  //   // console.log(`servicio de Carga de mensajes `, this.chats);
  //   // TODO: cargar mensajes chat
  //   this.http.get(this.apiURL)
  //     .subscribe(response => {
  //       console.log(response);
  //     });
  // }

  loadMessages(chatRoomId: number) {
    if (chatRoomId > 0) {
      return this.http.get(environment.serviceURL + '/messages/' + chatRoomId)
        .pipe(
          map((response: any) => {
            return response;
          })
        );
    }
    else
      return this.http.get(environment.serviceURL + '/messages/')
        .pipe(
          map((response: any) => {
            return response;
          })
        );
  }
  addMessage(messageStr: string, chatRoomId: number) {
    let message = {
      text: messageStr,
      chatRoomId: chatRoomId
    }
    return this.http.post(environment.serviceURL + '/messages/', message,
      {
        headers: {
          Authorization: `Bearer ${this.userService.token}`
        }
      }
    )
      .pipe(
        map((response: any) => {
          return response;
        })
      );
  }
}
