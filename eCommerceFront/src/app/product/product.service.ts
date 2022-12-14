import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from './product';

const API = environment.ApiUrl;
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient){}

    getAll(){      
        return this.http.get<Product[]>(API + `/product`);
    }
}
