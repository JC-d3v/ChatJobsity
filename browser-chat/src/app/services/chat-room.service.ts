import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chatroom } from '../interfaces/chatroom.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatRoomService {

  private apiURL: string = 'https://localhost:44332/api/chatrooms';

  public chatRooms: Chatroom[] = []

  constructor(private http: HttpClient) { }

  loadChatrooms() {
    this.http.get(this.apiURL)
      .subscribe(response => {
        console.log(`servico de carga de chatrooms -->`, response);
      });
  }


}
