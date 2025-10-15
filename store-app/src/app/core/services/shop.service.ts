import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Store } from '../models/store.model';

@Injectable({
  providedIn: 'root'
})
  export class ShopService {
    constructor(
      private httpClient : HttpClient
    ) {}

    getAllStores(){
      console.log("Trayendome las Tiendas");
      const result = this.httpClient.get<Store[]>(`${environment.API_URL}/Store`);
      return result;
    }
  }
