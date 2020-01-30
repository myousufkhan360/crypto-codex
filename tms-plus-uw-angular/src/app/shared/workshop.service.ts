import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Workshop } from "./workshop.model";

@Injectable({
  providedIn: "root"
})
export class WorkshopService {
  formData: Workshop;
  constructor(private http: HttpClient) {}

  getWorkshops(): any {
    return this.http.get(environment.apiUrl + "/Workshop/").toPromise();
  }
}
