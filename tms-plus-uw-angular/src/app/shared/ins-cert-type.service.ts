import { Injectable } from "@angular/core";
import { InsCertType } from "./ins-cert-type.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class InsCertTypeService {
  formData: InsCertType;
  constructor(private http: HttpClient) {}

  getInsCertTypeMaster(): any {
    return this.http
      .get(environment.apiUrl + "/InsCertTypeMaster/")
      .toPromise();
  }
}
