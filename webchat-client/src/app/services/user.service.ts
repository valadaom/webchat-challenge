import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import User from '../models/user';
import { throwError, Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export default class UserService {
    readonly baseUrl: string = 'http://localhost:5000';
    private userId: any;

    constructor(private http: HttpClient) {}

    public login(username: string, password: string): Observable<any> {
        let dto = {UserName: username, Password: password};
        return this.http.post(`${this.baseUrl}/auth/login`, dto);
    }

    public signup(userDto: any): Observable<any>{        
        return this.http.post(`${this.baseUrl}/auth/register`, userDto);
    }

    getUserId(){
        return this.userId;
    }

    setUserId(Id){
        this.userId = Id;
    }
}