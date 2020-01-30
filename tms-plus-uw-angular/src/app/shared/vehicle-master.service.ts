import { Injectable } from "@angular/core";
import { VehicleMaster } from "./vehicle-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class VehicleMasterService {
  formData: VehicleMaster;
  constructor(private http: HttpClient) {}

  getVehicleMaster(): any {
    return this.http
      .get(environment.apiUrl + "/VehicleMaster/")
      .toPromise();
  }
}

