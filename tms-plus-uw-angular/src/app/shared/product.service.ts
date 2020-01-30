import { Injectable } from "@angular/core";
import { Product } from "./product.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class ProductService {
  formData: Product;
  constructor(private http: HttpClient) {}

  GetClientBasedProduct(): any {
    return this.http
      .get(environment.apiUrl + "/ProductMaster/GetClientBasedProduct")
      .toPromise();
  }

  GetNonClientBasedProduct(): any {
    return this.http
      .get(environment.apiUrl + "/ProductMaster/GetNonClientBasedProduct")
      .toPromise();
  }
}
