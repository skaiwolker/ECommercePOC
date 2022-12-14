import { createReducer, on } from "@ngrx/store";
import { Product } from "../product/product";
import { getProducts } from "./products.actions";
import { state } from '@angular/animations'

export const initialState: ReadonlyArray<Product> = [];

export const productReducer = createReducer(
    initialState,
    on(getProducts, (state, { products }) => {
        return products
    })
)