import { Injectable } from "@angular/core";
import { IsRenewal } from "./is-renewal.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class IsRenewalService {
  formData: IsRenewal;
  constructor(private http: HttpClient) {}

  getIsRenewalMaster(): any {
    return this.http.get(environment.apiUrl + "/IsRenewalMaster/").toPromise();
  }
}
