import { Component, EventEmitter, Input, Output, ViewChild } from "@angular/core";

@Component({
    selector: 'home',
  templateUrl: './home.component.html',
})
export class HomeComponent{
 
    searchValue: string = '';
    @ViewChild('search') inputSearch: any;

    filterProduct(value:string){
        console.log(value);    
        this.searchValue = value;
        this.inputSearch.nativeElement.value = '';
    }
}