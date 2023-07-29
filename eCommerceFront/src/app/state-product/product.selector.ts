import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Product } from "../product/product";

export const selectProducts = createFeatureSelector<Product[]>('products');

export const selectProductById = (productId: number) => {
    return createSelector(selectProducts, (products: Product[]) => {
        const productById = products.filter(_ => _.id == productId);
        if(productById.length == 0){
            return null;
        }
        return productById[0];
    });
}

