import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

const API = environment.ApiUrl;
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient){}

    getAll(){      
        return this.http.get(API + `/product`);
    }
}
