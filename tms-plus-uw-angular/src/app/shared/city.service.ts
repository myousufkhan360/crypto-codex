import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { City } from "./city.model";

@Injectable({
  providedIn: "root"
})
export class CityService {
  formData: City;
  constructor(private http: HttpClient) {}

  getCities(): any {
    return this.http.get(environment.apiUrl + "/City/").toPromise();
  }
}
