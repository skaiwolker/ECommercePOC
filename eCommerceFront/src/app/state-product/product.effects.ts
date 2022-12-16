import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { map, of, switchMap, withLatestFrom } from "rxjs";
import { ProductService } from "../product/product.service";
import { setAPIStatus } from "../shared/app-store/app.action";
import { Appstate } from "../shared/app-store/appstate";
import { deactivateProductAPISuccess, getProducts, invokeDeactivateProductAPI, invokeProductsAPI, invokeSaveProductAPI, invokeUpdateProductAPI, saveProductAPISuccess, updateProductAPISuccess } from "./products.actions";

@Injectable()
export class ProductEffects {
    constructor(private actions$: Actions, private productService: ProductService, private appStore: Store<Appstate>) { }

    loadAllProducts$ = createEffect(() =>
        this.actions$.pipe(
            ofType(invokeProductsAPI),
            switchMap(() => {
                return this.productService.getAll().pipe(map((data) => getProducts({ products: data })))
            })
        )
    )

    saveNewProduct$ = createEffect(() =>
        this.actions$.pipe(
            ofType(invokeSaveProductAPI),
            switchMap((action) => {
                this.appStore.dispatch(setAPIStatus({ apiStatus: { apiResponseMessage: '', apiStatus: '' } }))
                return this.productService.create(action.payload).pipe(map((data) => {
                    this.appStore.dispatch(setAPIStatus({ apiStatus: { apiResponseMessage: '', apiStatus: 'success' } }))
                    return saveProductAPISuccess({ response: data })
                }))
            })
        )
    )

    updateProduct$ = createEffect(() =>
        this.actions$.pipe(
            ofType(invokeUpdateProductAPI),
            switchMap((action) => {
                this.appStore.dispatch(setAPIStatus({ apiStatus: { apiResponseMessage: '', apiStatus: '' } }))
                return this.productService.update(action.payload).pipe(map((data) => {
                    this.appStore.dispatch(setAPIStatus({ apiStatus: { apiResponseMessage: '', apiStatus: 'success' } }))
                    return updateProductAPISuccess({ response: data })
                }))
            })
        )

    )

    deactivateProduct$ = createEffect(() =>
        this.actions$.pipe(
            ofType(invokeDeactivateProductAPI),
            switchMap((action) => {
                this.appStore.dispatch(setAPIStatus({ apiStatus: { apiResponseMessage: '', apiStatus: '' } }))
                return this.productService.deactivate(action.productId).pipe(map((data) => {
                    this.appStore.dispatch(setAPIStatus({ apiStatus: { apiResponseMessage: '', apiStatus: 'success' } }))
                    return deactivateProductAPISuccess({ productId: action.productId})
                }))
            })
        )
    )
}