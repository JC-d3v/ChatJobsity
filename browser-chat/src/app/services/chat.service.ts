import { Injectable } from '@angular/core';

import { Message } from '../interfaces/message.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

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

  constructor() { }

  loadMessages() {
    // TODO: cargar mensajes chat
    this.chats = this.chats_temp;
    console.log(`servicio de Carga de mensajes `, this.chats);
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
