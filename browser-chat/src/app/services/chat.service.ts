import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Message } from '../interfaces/message.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private apiURL: string = 'https://localhost:44332/api/users';

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

  loadMessages() {
    // this.chats = this.chats_temp;
    // console.log(`servicio de Carga de mensajes `, this.chats);
    // TODO: cargar mensajes chat
    this.http.get(this.apiURL)
      .subscribe(response => {
        console.log(response);
      });
  }

  addMessage(messageStr: string) {
    // let message: Message = {
    //   uid: '2',
    //   name: 'demo',
    //   time: new Date().getTime(),
    //   message: messageStr
    // }
    // this.chats.push(message);
    // console.log(`agregando un mensaje`, message.message);
  }
}
