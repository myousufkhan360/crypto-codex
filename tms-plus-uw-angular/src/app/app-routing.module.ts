import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { MotorUwHomeComponent } from "./motor-uw-home/motor-uw-home.component";
import { LoginComponent } from "./login/login.component";
import { MotorOpenPolicyHeaderComponent } from "./motor-uw-home/motor-open-policy-header/motor-open-policy-header.component";
import { MotorCertificateHeaderComponent } from "./motor-uw-home/motor-certificate-header/motor-certificate-header.component";
import { MotorRiskDetailComponent } from "./motor-uw-home/motor-risk-detail/motor-risk-detail.component";



const routes: Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "login", component: LoginComponent },
  {
    path: "motor-uw-home",
    children: [
      { path: "", component: MotorUwHomeComponent },
      {
        path: "motor-open-policy-header",
        component: MotorOpenPolicyHeaderComponent
      },
      {
        path: "motor-open-policy-header/:id",
        component: MotorOpenPolicyHeaderComponent
      },
      {
        path: "motor-certificate-header",
        component: MotorCertificateHeaderComponent
      },
      {
        path: "motor-certificate-header/:id",
        component: MotorCertificateHeaderComponent
      },
      {
        path: "motor-risk-detail",
        component: MotorRiskDetailComponent
      },
      {
        path: "motor-risk-detail/:id",
        component: MotorRiskDetailComponent
      },
      { path: "login", component: LoginComponent }
    ]
  },
  {
    path: "motor-open-policy-header",
    component: MotorOpenPolicyHeaderComponent
  },
  {
    path: "motor-open-policy-header/:id",
    component: MotorOpenPolicyHeaderComponent
  },
   {
    path: "motor-certificate-header",
    component: MotorCertificateHeaderComponent
  },
  {
    path: "motor-certificate-header/:id",
    component: MotorCertificateHeaderComponent
  },
  {
    path: "motor-risk-detail",
    component: MotorRiskDetailComponent
  },
  {
    path: "motor-risk-detail/:id",
    component: MotorRiskDetailComponent
  },
  { path: "**", component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
