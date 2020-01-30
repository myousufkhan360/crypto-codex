import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Relation } from "./relation.model";

@Injectable({
  providedIn: "root"
})
export class RelationService {
  formData: Relation;
  constructor(private http: HttpClient) {}

  getRelations(): any {
    return this.http.get(environment.apiUrl + "/Relation/").toPromise();
  }
}
