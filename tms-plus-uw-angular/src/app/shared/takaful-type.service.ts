import { Injectable } from "@angular/core";
import { TakafulType } from "./takaful-type.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class TakafulTypeService {
  formData: TakafulType;
  constructor(private http: HttpClient) {}

  getTakafulTypeMaster(): any {
    return this.http
      .get(environment.apiUrl + "/TakafulTypeMaster/")
      .toPromise();
  }
}
