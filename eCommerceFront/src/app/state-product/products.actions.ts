import { createAction, createActionGroup, props } from "@ngrx/store";
import { Product } from "../product/product";


export const getProductsAPI = createAction(
    "[Product] get all API",
);

export const getProducts = createAction(
      "[Product] get all success",
      props<{ products : Product[]}>(),
);
