import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SigninComponent } from "./signin/signin.component";

@NgModule({
    declarations: [SigninComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: []
})
export class CoreModule{}