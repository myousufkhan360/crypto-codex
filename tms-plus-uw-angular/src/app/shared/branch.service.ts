import { Injectable } from "@angular/core";
import { Branch } from "./branch.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class BranchService {
  formData: Branch;
  constructor(private http: HttpClient) {}

  getBranchMaster(): any {
    return this.http.get(environment.apiUrl + "/BranchMaster/").toPromise();
  }
}
