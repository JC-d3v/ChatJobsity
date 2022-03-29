import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Chatroom } from '../interfaces/chatroom.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatRoomService {

  private apiURL: string = 'https://localhost:44332/api/chatrooms';

  public chatRooms: Chatroom[] = []

  constructor(private http: HttpClient) { }

  loadChatrooms() {
    return this.http.get(this.apiURL).pipe(
      map((response: any) => {
        return response;
      })
    );
  }

}
