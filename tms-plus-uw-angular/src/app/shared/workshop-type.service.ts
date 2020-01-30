import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { WorkshopType } from "./workshop-type.model";

@Injectable({
  providedIn: "root"
})
export class WorkshopTypeService {
  formData: WorkshopType;
  constructor(private http: HttpClient) {}

  getWorkshopTypes(): any {
    return this.http.get(environment.apiUrl + "/WorkshopType/").toPromise();
  }
}
