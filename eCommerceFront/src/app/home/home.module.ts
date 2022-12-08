import { CommonModule } from "@angular/common";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { StoreModule } from "@ngrx/store";
import { ProductListComponent } from "../product/product-list/product-list.component";
import { productReducer } from "../state-product/product.reducer";
import { HomeComponent } from "./home.component";

@NgModule({
    declarations: [HomeComponent, ProductListComponent],
    imports: [BrowserModule, StoreModule.forFeature('products', productReducer), HttpClientModule],
    providers: []
})
export class HomeModule{}