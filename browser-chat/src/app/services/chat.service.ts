import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Message } from '../interfaces/message.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  // private apiURL: string = 'https://localhost:44332/api/users';
  private apiURL: string = 'https://restcountries.com/v2/name/car';
  // private apiURL: string = 'https://rickandmortyapi.com/api/episode/3';
  // private apiURL: string = 'https://rickandmortyapi.com/api/character/12';



  public chats: Message[] = [];

  chats_temp: Message[] = [
    {
      uid: '1',
      name: 'jorge',
      time: 123,
      message: 'first'
    },

    {
      uid: '1',
      name: 'jorge',
      time: 123,
      message: 'second'
    }
  ]

  constructor(private http: HttpClient) { }

  loadMessages() {
    this.chats = this.chats_temp;
    console.log(`servicio de Carga de mensajes `, this.chats);
    // TODO: cargar mensajes chat
    this.http.get(this.apiURL)
      .subscribe(response => {
        console.log(response);
      });
  }

  addMessage(messageStr: string) {
    let message: Message = {
      uid: '2',
      name: 'demo',
      time: new Date().getTime(),
      message: messageStr
    }
    this.chats.push(message);
    console.log(`agregando un mensaje`, message.message);
  }
}
