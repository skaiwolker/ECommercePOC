import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { User } from "./user";

const API = environment.ApiUrl;

@Injectable({
    providedIn: 'root'
})
export class UserService{
    constructor(private http: HttpClient){}

    getLoggedUser(){
        return this.http.get<User>(API + `/login/infos`);
    }
}