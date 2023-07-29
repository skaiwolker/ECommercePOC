import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

const API = environment.ApiUrl;

@Injectable({
    providedIn: 'root'
})
export class AuthService{
    constructor(private http: HttpClient){}

    authenticate(userName: string, password: string){
             
        return this.http.post(API + `/login/login`,{userName, password});
    }
}