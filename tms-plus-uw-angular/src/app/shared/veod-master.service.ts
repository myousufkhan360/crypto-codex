import { Injectable } from "@angular/core";
import { VeodMaster } from "./veod-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class VeodMasterService {
  formData: VeodMaster;
  constructor(private http: HttpClient) {}

  getVeodMaster(): any {
    return this.http
      .get(environment.apiUrl + "/VeodMaster/")
      .toPromise();
  }
}

