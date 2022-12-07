import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { ProductService } from "../product/product.service";
import { HomeComponent } from "./home.component";

@NgModule({
    declarations: [HomeComponent],
    imports: [CommonModule, FormsModule, RouterModule],
    providers: [ProductService]
})
export class HomeModule{}