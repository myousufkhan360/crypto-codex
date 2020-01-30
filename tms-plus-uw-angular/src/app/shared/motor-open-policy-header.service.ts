import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MotorOpenPolicyHeader } from "./motor-open-policy-header.model";

@Injectable({
  providedIn: "root"
})
export class MotorOpenPolicyHeaderService {
  formData: MotorOpenPolicyHeader;
  constructor(private http: HttpClient) {}

  saveOrUpdateData() {
    let body = {
      ...this.formData
    };

    return this.http.post(environment.apiUrl + "/InsOpenPolicyHeader", body);
  }

  getById(Id: string): any {
    return this.http
      .get(environment.apiUrl + "/InsOpenPolicyHeader/" + Id)
      .toPromise();
  }
}
