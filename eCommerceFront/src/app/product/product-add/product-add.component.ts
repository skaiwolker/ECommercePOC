import { Component, OnInit } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";
import { Router } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { Observable, Subscriber } from "rxjs";
import { setAPIStatus } from "src/app/shared/app-store/app.action";
import { selectAppState } from "src/app/shared/app-store/app.selector";
import { Appstate } from "src/app/shared/app-store/appstate";
import { invokeSaveProductAPI } from "src/app/state-product/products.actions";
import { FileHandle } from "../file-handler";
import { Product } from "../product";

@Component({
    selector: 'product-add',
    templateUrl: 'product-add.component.html'
})
export class ProductAddComponent{

    constructor(private store:Store, private appStore: Store<Appstate>, private router: Router){}
    selectedImages: Observable<any>[] = [];
    indexImage: number = 0;

    productForm:Product = {
        id:0,
        name: '',
        description: '',
        department: 1,
        userId: 1,
        amount: undefined,
        price: undefined,
        productImages: []
    } 

    onChange($event: Event){
        const target = $event.target as HTMLInputElement;

        const file: File = (target.files as FileList)[0];

        this.convertToBase64(file)
    }

    convertToBase64(file: File){
        const observable = new Observable((subscriber: Subscriber<any>) => {
            this.readFile(file, subscriber)
        })

        observable.subscribe((data) => {
            
            const fileHandle: FileHandle = {
                id: 0,
                image: data               
            }

            this.productForm.productImages?.push(fileHandle); 

            this.selectedImages[this.indexImage] = data;
            this.indexImage += 1;
            
        })
    }

    readFile(file: File,subscriber: Subscriber<any>){
        const filereader = new FileReader();

        filereader.readAsDataURL(file)
        
        filereader.onload = () => {
            subscriber.next(filereader.result);

            subscriber.complete()
        }

        filereader.onerror = () => {
            subscriber.error()

            subscriber.complete()
        }
        
    }

    save(){
        this.store.dispatch(invokeSaveProductAPI({payload: {...this.productForm}}))
        let appStatus$ = this.appStore.pipe(select(selectAppState));
        appStatus$.subscribe((data) => {
            if(data.apiStatus === 'success'){
                this.appStore.dispatch(setAPIStatus({apiStatus: {apiStatus: '', apiResponseMessage: ''}}))
                this.router.navigate(['/']);
            }
        })
    }

}