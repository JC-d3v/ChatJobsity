import { Component, } from '@angular/core';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styles: [
  ]
})
export class ChatComponent {
  message: string = '';

  constructor() { }

  sendMessage() {
    console.log(`enviando el mensaje -->${this.message}`);
    this.message = ''
  }
}
