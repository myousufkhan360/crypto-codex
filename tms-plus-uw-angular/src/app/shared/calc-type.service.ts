import { Injectable } from "@angular/core";
import { CalcType } from "./calc-type.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class CalcTypeService {
  formData: CalcType;
  constructor(private http: HttpClient) {}

  getCalcTypeMaster(): any {
    return this.http.get(environment.apiUrl + "/CalcTypeMaster/").toPromise();
  }
}
