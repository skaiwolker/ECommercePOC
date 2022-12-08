import { createReducer, on } from "@ngrx/store";
import { Product } from "../product/product";
import { getProducts } from "./products.actions";
import { state } from '@angular/animations'

export const initialState: Product = [];

export const productReducer = createReducer(
    initialState,
    on(getProducts, (state, { products }) => {
        console.log('reducer', products)
        return products
    })
)