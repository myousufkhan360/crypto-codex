import { Injectable } from "@angular/core";
import { PolicyType } from "./policy-type.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class PolicyTypeService {
  formData: PolicyType;
  constructor(private http: HttpClient) {}

  getPolicyTypeMaster(): any {
    return this.http.get(environment.apiUrl + "/PolicyTypeMaster/").toPromise();
  }
}
