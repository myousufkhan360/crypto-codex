import { Injectable } from "@angular/core";
import { Client } from "./client.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class ClientService {
  formData: Client;
  constructor(private http: HttpClient) {}

  getClientMaster(): any {
    return this.http.get(environment.apiUrl + "/ClientMaster/").toPromise();
  }
}
