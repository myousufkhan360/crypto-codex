import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MotorRiskDetail } from "./motor-risk-detail.model";

@Injectable({
  providedIn: "root"
})
export class MotorRiskDetailService {
  formData: MotorRiskDetail;
  constructor(private http: HttpClient) {}

  saveOrUpdateData() {
    let body = {
      ...this.formData
    };

    return this.http.post(environment.apiUrl + "/InsMotorRiskDetail", body);
  }

  getById(Id: string): any {
    return this.http
      .get(environment.apiUrl + "/InsMotorRiskDetail/" + Id)
      .toPromise();
  }

  getByHeaderId(Id: string): any {
    return this.http
      .get(environment.apiUrl + "/InsCertificateHeader/" + Id)
      .toPromise();
  }
}