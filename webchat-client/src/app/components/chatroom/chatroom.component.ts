import { Component, NgZone, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import Message from '../../models/message';
import User from '../../models/user';
import { ChatService } from '../../services/chat.service';
import UserService from '../../services/user.service';
import { map } from 'rxjs/operators'

@Component({
  selector: 'app-chatroom',
  templateUrl: './chatroom.component.html'
})
export class ChatRoomComponent {
 
  message: Message;
  messages = new Array<Message>();
  textValue: string = '';
  user: User; 
  data: any;

  constructor(
    private http: HttpClient, 
    private chatService: ChatService,
    private userService: UserService,
    private ngZone: NgZone) { 
      this.subscribeToEvents(); 
      this.getCurremtUser();
      this.chatService.getMesagges().subscribe((resp: Array<any>) => {
        return resp.map((msg) => {
          this.messages.push({
            Type: msg.type,
            Text: msg.text,
            Date: msg.date,
            UserId: msg.userId
          });
        });
      });
      setTimeout(() => this.setScrollbar(), 500);      
    }

    setScrollbar() {
      var element = document.getElementById("chat-messages");
      element.scrollTo(0,(element.scrollHeight - element.clientHeight));
    }

    getCurremtUser(): void {
      setTimeout(() => {
        let userId = this.userService.getUserId();        
        this.http.get(`http://localhost:5000/users/${userId}`)
          .subscribe((response: any) => {
            let usr = {
              Id: response.id,
              UserName: response.userName,
              Name: response.name,
              Email: response.email
            };
            this.user = usr;
          });
      }, 500)
    }

    sendMessage(): void {  
      if (this.textValue) {  
        this.message = new Message();  
        this.message.UserId = this.user.Id;
        this.message.Type = "sent";  
        this.message.Text = this.textValue;  
        this.message.Date = new Date();  
        this.messages.push(this.message);        
        this.chatService.sendMessage(this.message);  
        this.textValue = '';  
      }  
      this.setScrollbar();  
    } 

    private subscribeToEvents(): void {  
      this.chatService.messageReceived.subscribe((receivedMessage: any) => {
        this.ngZone.run(() => {
          if (this.user.Id !== +receivedMessage.userId) { 
            let msg = {
              Type: 'received',
              Text: receivedMessage.text,
              Date: receivedMessage.date,
              User: receivedMessage.user,
            }
            this.messages.push(msg);
          }  
        });  
      });  
    }  

}
