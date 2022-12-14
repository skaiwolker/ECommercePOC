import { Component, Input, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { selectProducts } from "src/app/state-product/product.selector";
import { getProducts, getProductsAPI, } from "src/app/state-product/products.actions";
import { Product } from "../product";
import { ProductService } from "src/app/product/product.service";

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit{

    constructor(private store: Store) { }

    products$ = this.store.pipe(select(selectProducts));


    ngOnInit() {
        this.store.dispatch(getProductsAPI());
    }
}