import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { map, switchMap } from "rxjs";
import { ProductService } from "../product/product.service";
import { getProducts, getProductsAPI } from "./products.actions";

@Injectable()
export class ProductEffects {
    constructor(private actions$ : Actions, private productService: ProductService){}

    loadAllBooks$ = createEffect(() =>
        this.actions$.pipe(
            ofType(getProductsAPI),
            switchMap(() => {
                return this.productService.getAll().pipe(map((data) => getProducts({products: data})))
            })
        )
    )
}