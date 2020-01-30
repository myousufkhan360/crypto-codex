import { Injectable } from "@angular/core";
import { Login } from "./login.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { JwtHelper } from "angular2-jwt";
import "rxjs/add/operator/map";

@Injectable({
  providedIn: "root"
})
export class LoginService {
  formData: Login;
  constructor(private http: HttpClient) {}

  getToken(username: string, password: string): any {
    try {
      return this.http
        .get(
          environment.apiUrl +
            "/token/?username=" +
            username +
            "&password=" +
            password
        )
        .toPromise();
    } catch (ex) {
      return null;
    }
  }

  getCurrentUser() {
    let token = localStorage.getItem("token");
    if (!token) return null;

    return new JwtHelper().decodeToken(token);
  }
}
