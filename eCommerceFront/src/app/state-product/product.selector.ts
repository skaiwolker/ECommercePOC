import { createFeatureSelector } from "@ngrx/store";
import { Product } from "../product/product";

export const selectProducts = createFeatureSelector<Product[]>('products');
