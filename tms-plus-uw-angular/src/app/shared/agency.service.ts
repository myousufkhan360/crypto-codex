import { Injectable } from "@angular/core";
import { Agency } from "./agency.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class AgencyService {
  formData: Agency;
  constructor(private http: HttpClient) {}

  getAgencyMaster(): any {
    return this.http.get(environment.apiUrl + "/AgencyMaster/").toPromise();
  }
}
