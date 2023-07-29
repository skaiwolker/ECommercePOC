import { Component, ElementRef, ViewChild } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../auth/auth.service";

@Component({
    selector: 'signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css']
})
export class SigninComponent{
    
    constructor(private authService: AuthService, private router: Router){}

    loginForm = new FormGroup({
        username: new FormControl(),
        password: new FormControl()        
    });

    ngOnInit(): void {

        
    }

    login(){
        this.authService.authenticate(this.loginForm.value.username, this.loginForm.value.password);
        //this.router.navigate(['/']);
    }
}