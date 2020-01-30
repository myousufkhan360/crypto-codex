import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { MotorClaimVehicle } from "./motor-claim-vehicle.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class MotorClaimVehicleService {
  formData: MotorClaimVehicle;
  constructor(private http: HttpClient) {}

  getMotorClaimRegById(id): any {
    return this.http
      .get(environment.apiUrl + "/MotorClaimVehicleDetails/" + id)
      .toPromise();
  }
}
