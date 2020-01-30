import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { HourMinute } from "./hour-minute.model";

@Injectable({
  providedIn: "root"
})
export class HourMinuteService {
  formData: HourMinute;
  constructor(private http: HttpClient) {}

  getHourMinute(): any {
    return this.http.get(environment.apiUrl + "/HourMinute/").toPromise();
  }
}
