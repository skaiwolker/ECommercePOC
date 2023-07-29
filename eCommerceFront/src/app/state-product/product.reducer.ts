import { createReducer, on } from "@ngrx/store";
import { Product } from "../product/product";
import { deactivateProductAPISuccess, getProducts, saveProductAPISuccess, updateProductAPISuccess } from "./products.actions";
import { state } from '@angular/animations'

export const initialState: ReadonlyArray<Product> = [];

export const productReducer = createReducer(
    initialState,
    on(getProducts, (state, { products }) => {    
        return products
    }),
    on(saveProductAPISuccess,(state, {response}) => {
        let newState = [...state];
        newState.unshift(response);
        return newState;
    }),
    on(updateProductAPISuccess,(state, {response}) => {
        let newState = state.filter(_ => _.id !== response.id);
        newState.unshift(response);
        return newState;
    }),
    on(deactivateProductAPISuccess,(state, {productId}) => {
        let newState = state.filter(_ => _.id !== productId);
        return newState;
    })
);