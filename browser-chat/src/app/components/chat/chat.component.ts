import { Component, } from '@angular/core';

import { ChatService } from "../../services/chat.service";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styles: [
  ]
})
export class ChatComponent {
  message: string = '';

  constructor(public _cs: ChatService) {
    this._cs.loadMessages();
    console.log(`Constructor mostrando mensajes`);
  }

  sendMessage() {
    if (this.message.length === 0) {
      return;
    }
    // TODO: enviar mensaje .then .catch 
    console.log(`enviando el mensaje -->${this.message}`);
    this._cs.addMessage(this.message);
    this.message = '';
  }
}
