import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { EffectsModule } from "@ngrx/effects";
import { StoreModule } from "@ngrx/store";
import { ProductAddComponent } from "../product/product-add/product-add.component";
import { ProductEditComponent } from "../product/product-edit/product-edit.component";
import { ProductListComponent } from "../product/product-list/product-list.component";
import { ProductEffects } from "../state-product/product.effects";
import { productReducer } from "../state-product/product.reducer";
import { UserEffects } from "../state-user/user.effects";
import { userReducer } from "../state-user/user.reducer";
import { HomeRoutingModule } from "./home-routing.module";
import { HomeComponent } from "./home.component";
@NgModule({
    declarations: [HomeComponent,ProductListComponent, ProductAddComponent, ProductEditComponent],
    imports: [
        CommonModule,
        HomeRoutingModule,
        FormsModule,
        StoreModule.forFeature('products', productReducer),
        EffectsModule.forFeature([ProductEffects]),
        StoreModule.forFeature('user', userReducer),
        EffectsModule.forFeature([UserEffects])
    ],
    providers: []
})
export class HomeModule{}