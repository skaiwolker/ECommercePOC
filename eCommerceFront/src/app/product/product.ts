import { FileHandle } from "./file-handler";

export interface Product{
    
    id?: number;
    name?: string;
    description?: string;
    department?: number;
    userId?: number;
    amount?: number;
    price?: number;
    productImages?: FileHandle[];
    [key: string]: any;
}

export interface ProductState{
    products: Product[]
}