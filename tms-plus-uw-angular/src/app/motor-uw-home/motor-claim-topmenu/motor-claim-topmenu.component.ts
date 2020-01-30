import { Component, OnInit } from "@angular/core";
import { LoginService } from "src/app/shared/login.service";
import { logOut } from "../../utils/login-util";
import { Router } from "@angular/router";

@Component({
  selector: "app-motor-claim-topmenu",
  templateUrl: "./motor-claim-topmenu.component.html",
  styleUrls: ["./motor-claim-topmenu.component.css"]
})
export class MotorClaimTopmenuComponent implements OnInit {
  tokenInfo;
  constructor(private loginService: LoginService, private router: Router) {}

  ngOnInit() {
    this.tokenInfo = this.loginService.getCurrentUser();
    if (this.tokenInfo == null) {
      this.onLogOut();
    }
  }

  onLogOut() {
    localStorage.removeItem("token");
    localStorage.removeItem("userid");
    this.router.navigate(["/login"]);
  }
}
