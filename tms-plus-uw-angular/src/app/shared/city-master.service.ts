import { Injectable } from "@angular/core";
import { CityMaster } from "./city-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class CityMasterService {
  formData: CityMaster;
  constructor(private http: HttpClient) {}

  getCityMaster(): any {
    return this.http.get(environment.apiUrl + "/CityMaster/").toPromise();
  }
}
