import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Minute } from "./minute.model";

@Injectable({
  providedIn: "root"
})
export class MinuteService {
  formData: Minute;
  constructor(private http: HttpClient) {}

  getMinutes(): any {
    return this.http.get(environment.apiUrl + "/Minute/").toPromise();
  }
}
