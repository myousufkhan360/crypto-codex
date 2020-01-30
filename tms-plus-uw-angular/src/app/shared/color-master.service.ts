import { Injectable } from "@angular/core";
import { ColorMaster } from "./color-master.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class ColorMasterService {
  formData: ColorMaster;
  constructor(private http: HttpClient) {}

  getColorMaster(): any {
    return this.http
      .get(environment.apiUrl + "/ColorMaster/")
      .toPromise();
  }
}
