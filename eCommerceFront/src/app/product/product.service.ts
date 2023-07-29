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

    create(payload:Product){
        return this.http.post<Product>(API + `/product`, payload);
    }

    update(payload: Product){
        return this.http.put<Product>(API + `/product`, payload);
    }

    deactivate(id: number){
      return this.http.put(API + `/product/deactivate/${id}`, id);
    }
}
