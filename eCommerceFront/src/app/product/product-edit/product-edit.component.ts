import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { Observable, Subscriber, switchMap } from "rxjs";
import { setAPIStatus } from "src/app/shared/app-store/app.action";
import { selectAppState } from "src/app/shared/app-store/app.selector";
import { Appstate } from "src/app/shared/app-store/appstate";
import { selectProductById } from "src/app/state-product/product.selector";
import { invokeSaveProductAPI, invokeUpdateProductAPI } from "src/app/state-product/products.actions";
import { FileHandle } from "../file-handler";
import { Product } from "../product";

@Component({
    selector: 'product-edit',
    templateUrl: 'product-edit.component.html'
})
export class ProductEditComponent implements OnInit{

    constructor(private store:Store, private appStore: Store<Appstate>, private router: Router, private route: ActivatedRoute){}

    selectedImages: Observable<any>[] = [];
    indexImage!: number;

    productForm:Product = {
        id:0,
        name: '',
        description: '',
        department: 1,
        userId: 1,
        amount: 0,
        price: 0,
        productImages : []
    } 

    ngOnInit(): void {
        const fetchFormData$ = this.route.paramMap.pipe(
            switchMap((param) =>{
                const id = Number(param.get('id'));
                return this.store.pipe(select(selectProductById(id)));
            })
        )
        fetchFormData$.subscribe((data) => {
            if(data){
                this.productForm = {...data};
            }
            else{
                this.router.navigate(['/']);
            }
        })
        
    }

    update(){
        this.store.dispatch(invokeUpdateProductAPI({payload: {...this.productForm}}))
        let appStatus$ = this.appStore.pipe(select(selectAppState));
        appStatus$.subscribe((data) => {
            if(data.apiStatus === 'success'){
                this.appStore.dispatch(setAPIStatus({apiStatus: {apiStatus: '', apiResponseMessage: ''}}))
                this.router.navigate(['/']);
            }
        })
    }
    // onChange($event: Event){
    //     const target = $event.target as HTMLInputElement;

    //     const file: File = (target.files as FileList)[0];
        
    //     this.convertToBase64(file)
    // }

    // convertToBase64(file: File){
    //     const observable = new Observable((subscriber: Subscriber<any>) => {
    //         this.readFile(file, subscriber)
    //     })

    //     observable.subscribe((data) => {
            
    //         const fileHandle: FileHandle = {
    //             id: 0,
    //             image: data               
    //         }

    //         this.productForm.productImages = Object.assign([], this.productForm.productImages);
    //         this.productForm.productImages?.push(fileHandle); 

    //         console.log("convert",this.productForm.productImages);
            
            
    //         this.selectedImages[this.indexImage] = data;
    //         this.indexImage += 1;          
            
            
    //     })
    // }

    // readFile(file: File,subscriber: Subscriber<any>){
    //     const filereader = new FileReader();

    //     filereader.readAsDataURL(file)
        
    //     filereader.onload = () => {
    //         subscriber.next(filereader.result);

    //         subscriber.complete()
    //     }

    //     filereader.onerror = () => {
    //         subscriber.error()

    //         subscriber.complete()
    //     }
        
    // }

}