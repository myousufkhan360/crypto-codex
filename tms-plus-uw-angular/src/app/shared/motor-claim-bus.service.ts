import { Injectable } from "@angular/core";
import { MotorClaimBus } from "./motor-claim-bus.model";
import { environment } from "src/environments/environment";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class MotorClaimBusService {
  formData: MotorClaimBus;
  constructor(private http: HttpClient) {}

  setBusValues(motorClaimBus: MotorClaimBus) {
    this.formData = Object.assign({}, motorClaimBus);
  }

  getBusValues(): MotorClaimBus {
    return this.formData;
  }

  getBusValuesFromDb(Id: string): any {
    return this.http
      .get(environment.apiUrl + "/MotorClaimBus/" + Id)
      .toPromise();
  }
}
