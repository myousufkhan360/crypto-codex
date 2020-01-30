import { Injectable } from "@angular/core";
import { DistrictMaster } from "./district-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class DistrictMasterService {
  formData: DistrictMaster;
  constructor(private http: HttpClient) {}

  getDistrictMaster(): any {
    return this.http.get(environment.apiUrl + "/DistrictMaster/").toPromise();
  }
  
  getByCityCode(CityCode): any {
    return this.http
      .get(environment.apiUrl + "/DistrictMaster/?pCityCode=" + CityCode)
      .toPromise();
  }
}
