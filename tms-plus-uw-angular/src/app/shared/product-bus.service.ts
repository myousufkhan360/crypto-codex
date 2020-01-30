import { Injectable } from "@angular/core";
import { ProductBus } from "./product-bus.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class ProductBusService {
  formData: ProductBus;
  constructor(private http: HttpClient) {}

  GetProductBusByCode(id: string): any {
    return this.http
      .get(environment.apiUrl + "/MasterProductBus/" + id)
      .toPromise();
  }
}
