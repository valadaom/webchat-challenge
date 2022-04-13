import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import UserService from '../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  @Output() isLoggedIn = new EventEmitter<boolean>();
  @Output() userId = new EventEmitter<Number>();
  public register: boolean;
  public username: string;
  public password: string;
  public email: string;
  public name: string;
  public loginSignUpMessage: string;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  public login(): void {
    this.userService.login(this.username, this.password).subscribe((response)=>{
      let Id = response.data;
      this.userService.setUserId(Id);
      if(Id !== '0' && Id !== undefined){
        this.isLoggedIn.emit(true);
        this.userId.emit(Id);
      }else if(Id == '0') {
        this.isLoggedIn.emit(false);
      }
    });
  }

  public toggleLoginSignUp(): void {
    this.register = !this.register;
  }
  
  public signIn(): void {
    let dto = {
      UserName: this.username,
      Email: this.email,
      Name: this.name, 
      Password: this.password
    };
    
    this.userService.signup(dto)
      .subscribe(response => {
        if(response.success){
          this.toggleLoginSignUp();
          this.loginSignUpMessage = "Great! You are now Registered! Sign In to start chatting!"
        }
      })
  }

}
