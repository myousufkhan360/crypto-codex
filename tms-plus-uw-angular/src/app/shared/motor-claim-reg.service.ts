import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { MotorClaimReg } from "./motor-claim-reg.model";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class MotorClaimRegService {
  formData: MotorClaimReg;
  constructor(private http: HttpClient) {}

  getMotorClaimRegById(id: string): any {
    return this.http
      .get(environment.apiUrl + "/MotorClaimRegSearch/" + id)
      .toPromise();
  }
}
