import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

import { Message } from '../interfaces/message.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private apiURL: string = 'https://localhost:44332/api/messages/';

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

  constructor(private http: HttpClient) { }

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
      return this.http.get(this.apiURL + chatRoomId)
        .pipe(
          map((response: any) => {
            return response;
          })
        );
    }
    else
      return this.http.get(this.apiURL)
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
    return this.http.post(this.apiURL, message)
      .pipe(
        map((response: any) => {
          return response;
        })
      );
  }
}
