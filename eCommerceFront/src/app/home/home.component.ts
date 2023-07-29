import { Component, EventEmitter, Input, Output, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { invokeLoggedUserAPI } from "../state-user/user.action";
import { selectLoggedUser } from "../state-user/user.selector";
import { User } from "../user/user";

@Component({
    selector: 'home',
  templateUrl: './home.component.html',
})
export class HomeComponent{

    constructor(private router: Router,private store: Store<User>){}

    users$ = this.store.pipe(select(selectLoggedUser));
    
    loggedUser?: User;
 
    searchValue: string = '';
    @ViewChild('search') inputSearch: any;

    filterProduct(value:string){
        console.log(value);    
        this.searchValue = value;
        this.inputSearch.nativeElement.value = '';
    }

    redirectToSignin(){
        this.router.navigate(['/signin']);
    }

    ngOnInit(){
        this.store.dispatch(invokeLoggedUserAPI());

        this.users$.subscribe((user) => (this.loggedUser = user));

        console.log('user', this.loggedUser);
        
    }
}