import { Component, } from '@angular/core';
import { ChatRoomService } from 'src/app/services/chat-room.service';

import { ChatService } from "../../services/chat.service";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styles: [
  ]
})
export class ChatComponent {
  message: string = '';
  chatRooms: any;
  messages: any;
  botmessages: any = [];
  chatRoom: any;
  chatRoomIndex: number = 0;
  constructor(public chatService: ChatService,
    public chatRoomService: ChatRoomService,
  ) {
    this.chatRoomService.loadChatrooms().subscribe(
      chatRooms => {
        this.chatRooms = chatRooms;
        this.chatRoom = chatRooms[0];
        this.loadChatRoom();
      });
  }
  sendMessage() {
    if (this.message.length === 0) {
      return;
    }
    this.chatService.addMessage(this.message, this.chatRoom.chatRoomId).subscribe(
      (response) => {
        if (response) {
          this.botmessages.push(response);
          console.log(this.botmessages);
        }
        this.loadChatRoom();
      }
    );
    this.message = '';
  }

  selectChatRoom() {
    this.chatRoom = this.chatRooms[this.chatRoomIndex];
    this.loadChatRoom()
  }

  loadChatRoom() {
    this.chatService.loadMessages(this.chatRoom.chatRoomId).subscribe(
      messages => {
        this.messages = messages;
        this.messages = this.messages.concat(this.botmessages);
      });
  }
}
