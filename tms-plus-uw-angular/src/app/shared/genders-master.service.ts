import { Injectable } from "@angular/core";
import { GendersMaster } from "./genders-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class GendersMasterService {
  formData: GendersMaster;
  constructor(private http: HttpClient) {}

  getGendersMaster(): any {
    return this.http.get(environment.apiUrl + "/GendersMaster/").toPromise();
  }
}
