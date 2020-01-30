import { Injectable } from "@angular/core";
import { OpenPolBus } from "./open-pol-bus.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root"
})
export class OpenPolBusService {
  formData: OpenPolBus;
  constructor(private http: HttpClient) {}

  GetOpenPolBusByCode(id: string): any {
    return this.http
      .get(environment.apiUrl + "/OpenPolBus?OpenPolAssortedCode=" + id)
      .toPromise();
  }
}
