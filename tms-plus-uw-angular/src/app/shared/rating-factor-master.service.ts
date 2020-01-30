import { Injectable } from "@angular/core";
import { RatingFactorMaster } from "./rating-factor-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class RatingFactorMasterService {
  formData: RatingFactorMaster;
  constructor(private http: HttpClient) {}

  getRatingFactorMaster(): any {
    return this.http
      .get(environment.apiUrl + "/RatingFactorMaster/")
      .toPromise();
  }
}
