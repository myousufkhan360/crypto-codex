import { Injectable } from "@angular/core";
import { VehicleTypeMaster } from "./vehicle-type-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class VehicleTypeMasterService {
  formData: VehicleTypeMaster;
  constructor(private http: HttpClient) {}

  getVehicleTypeMaster(): any {
    return this.http
      .get(environment.apiUrl + "/VehicleTypeMaster/")
      .toPromise();
  }
}