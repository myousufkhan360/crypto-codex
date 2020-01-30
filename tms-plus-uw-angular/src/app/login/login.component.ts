import { Component, OnInit } from "@angular/core";
import { Login } from "./../shared/login.model";
import { LoginService } from "../shared/login.service";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  formData: Login;
  isValid: boolean = true;

  constructor(
    public service: LoginService,
    private router: Router,
    private currentRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.resetForm();
  }

  loginUser() {
    let token: string;

    this.service
      .getToken(this.service.formData.username, this.service.formData.password)
      .then(res => {
        if (res != null) {
          this.isValid = true;
          token = res;
          localStorage.setItem("token", token);
          localStorage.setItem("userid", this.service.formData.username);
          this.router.navigate(["/motor-uw-home"]);
        } else {
          this.isValid = false;
          localStorage.removeItem("token");
          this.router.navigate(["/login"]);
        }
      });
  }

  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();

    this.service.formData = {
      username: "",
      password: ""
    };
  }
}
