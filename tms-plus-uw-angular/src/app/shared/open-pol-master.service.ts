import { Injectable } from "@angular/core";
import { OpenPolMaster } from "./open-pol-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class OpenPolMasterService {
  formData: OpenPolMaster;
  constructor(private http: HttpClient) {}

  getOpenPolMaster(): any {
    return this.http.get(environment.apiUrl + "/InsOpenPolMaster/").toPromise();
  }

  getByClientCode(ClientCode: string): any {
    return this.http
      .get(environment.apiUrl + "/InsOpenPolMaster/" + ClientCode)
      .toPromise();
  }
}
