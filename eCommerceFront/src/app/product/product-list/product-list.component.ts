import { Component, Input } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { selectProducts } from "src/app/state-product/product.selector";
import { getProducts, } from "src/app/state-product/products.actions";
import { Product } from "../product";
import { ProductService } from "src/app/service/product.service";

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html',
})
export class ProductListComponent {

    constructor(private productService: ProductService, private store: Store) { }

    products$ = this.store.pipe(select(selectProducts));


    ngOnInit() {
        this.productService
            .getAll()
            .subscribe((products: any) => {
                console.log(products);
                this.store.dispatch(getProducts({products}))
            }
            );
    }
}