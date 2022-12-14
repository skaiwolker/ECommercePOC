import { CommonModule } from "@angular/common";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { EffectsModule } from "@ngrx/effects";
import { StoreModule } from "@ngrx/store";
import { ProductListComponent } from "../product/product-list/product-list.component";
import { ProductEffects } from "../state-product/product.effects";
import { productReducer } from "../state-product/product.reducer";
import { HomeRoutingModule } from "./home-routing.module";
import { HomeComponent } from "./home.component";

@NgModule({
    declarations: [HomeComponent, ProductListComponent],
    imports: [
        CommonModule,
        HomeRoutingModule,
        StoreModule.forFeature('products', productReducer),
        EffectsModule.forFeature([ProductEffects])
    ],
    providers: []
})
export class HomeModule{}