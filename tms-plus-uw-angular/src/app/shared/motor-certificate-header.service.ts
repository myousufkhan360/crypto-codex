import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { MotorCertificateHeader } from "./motor-certificate-header.model";

@Injectable({
  providedIn: "root"
})
export class MotorCertificateHeaderService {
  formData: MotorCertificateHeader;
  constructor(private http: HttpClient) {}

  saveOrUpdateData() {
    let body = {
      ...this.formData
    };

    return this.http.post(environment.apiUrl + "/InsCertificateHeader", body);
  }

  getById(Id: string): any {
    return this.http
      .get(environment.apiUrl + "/InsCertificateHeader/" + Id)
      .toPromise();
  }
}
