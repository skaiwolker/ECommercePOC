import { createAction, createActionGroup, props } from "@ngrx/store";
import { Product } from "../product/product";


export const invokeProductsAPI = createAction(
    "[Product] invoke products API",
);

export const getProducts = createAction(
      "[Product] get all success",
      props<{ products : Product[]}>(),
);

export const invokeSaveProductAPI = createAction(
    "[Product] invoke save products API",
    props<{payload: Product}>()
)

export const saveProductAPISuccess = createAction(
    "[Product] save product API success",
    props<{response: Product}>()
)

export const invokeUpdateProductAPI = createAction(
    "[Product] invoke update products API",
    props<{payload: Product}>()
)

export const updateProductAPISuccess = createAction(
    "[Product] update product API success",
    props<{response: Product}>()
)

export const invokeDeactivateProductAPI = createAction(
    "[Product] invoke deactivate products API",
    props<{productId: number}>()
)

export const deactivateProductAPISuccess = createAction(
    "[Product] deactivate product API success",
    props<{productId: number}>()
)
