import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Hour } from "./hour.model";

@Injectable({
  providedIn: "root"
})
export class HourService {
  formData: Hour;
  constructor(private http: HttpClient) {}

  getHours(): any {
    return this.http.get(environment.apiUrl + "/Hour/").toPromise();
  }
}
