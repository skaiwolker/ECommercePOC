import { Component, Input, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { selectProducts } from "src/app/state-product/product.selector";
import { getProducts, invokeDeactivateProductAPI, invokeProductsAPI, } from "src/app/state-product/products.actions";
import { Product } from "../product";
import { ProductService } from "src/app/product/product.service";
import { selectAppState } from "src/app/shared/app-store/app.selector";
import { Appstate } from "src/app/shared/app-store/appstate";
import { setAPIStatus } from "src/app/shared/app-store/app.action";
import { Router } from "@angular/router";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";

declare const window: any

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit {

    constructor(private store: Store, private appStore: Store<Appstate>) { }

    products$ = this.store.pipe(select(selectProducts));
    deactivateModal: any;
    idToDelete: number = 0;

    images: string[] = [];


    ngOnInit() {
        this.deactivateModal = new window.bootstrap.Modal(
            document.getElementById("deleteModal")
        );
        this.store.dispatch(invokeProductsAPI());

        this.products$.subscribe(produtos => {
            produtos.forEach(produto => {this.images.push(produto.productImages?.at(0)?.image || '/assets/images/image-not-found.png')
            console.log(this.images);
        })
        
        });

        
        
        
    }

    openDeactivateModal(id: number = 0) {
        this.idToDelete = id;
        this.deactivateModal.show();
    }

    confirmDeactivation() {
        this.store.dispatch(invokeDeactivateProductAPI({ productId: this.idToDelete }));
        let appStatus$ = this.appStore.pipe(select(selectAppState));
        appStatus$.subscribe((data) => {
            if (data.apiStatus === 'success') {
                this.appStore.dispatch(setAPIStatus({ apiStatus: { apiStatus: '', apiResponseMessage: '' } }))
                this.deactivateModal.hide();
            }
        })
    }
}