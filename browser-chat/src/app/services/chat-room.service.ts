import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Chatroom } from '../interfaces/chatroom.interface';

@Injectable({
  providedIn: 'root'
})
export class ChatRoomService {


  public chatRooms: Chatroom[] = []

  constructor(private http: HttpClient) { }

  loadChatrooms() {
    return this.http.get(environment.serviceURL + '/chatrooms').pipe(
      map((response: any) => {
        return response;
      })
    );
  }

}
