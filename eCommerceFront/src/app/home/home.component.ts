import { Component, OnInit } from "@angular/core";
import { Store, select } from "@ngrx/store";
import { selectProducts } from "../state-product/product.selector";
import { getProducts, getProductsAPI } from "../state-product/products.actions";


@Component({
    templateUrl: './home.component.html'
})
export class HomeComponent{
}