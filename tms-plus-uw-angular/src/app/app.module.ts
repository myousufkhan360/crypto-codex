import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { DatePipe } from "@angular/common";
import { NgSelectModule } from "@ng-select/ng-select";

import { ToastrModule } from "ngx-toastr";
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule } from "@angular/common/http";
import { BsDatepickerModule } from "ngx-bootstrap/datepicker";
import { TimepickerModule } from "ngx-bootstrap/timepicker";

import { AppComponent } from "./app.component";
import { MotorUwHomeComponent } from "./motor-uw-home/motor-uw-home.component";
import { MotorOpenPolicyHeaderComponent } from "./motor-uw-home/motor-open-policy-header/motor-open-policy-header.component";
import { LoginComponent } from "./login/login.component";
import { MotorClaimTopmenuComponent } from "./motor-uw-home/motor-claim-topmenu/motor-claim-topmenu.component";
import { MotorClaimMenuComponent } from "./motor-uw-home/motor-claim-menu/motor-claim-menu.component";
import { MotorCertificateHeaderComponent } from './motor-uw-home/motor-certificate-header/motor-certificate-header.component';
import { MotorRiskDetailComponent } from './motor-uw-home/motor-risk-detail/motor-risk-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    MotorUwHomeComponent,
    MotorOpenPolicyHeaderComponent,
    MotorClaimTopmenuComponent,
    MotorClaimMenuComponent,
    LoginComponent,
    MotorCertificateHeaderComponent,
    MotorRiskDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    FormsModule,
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
    BrowserAnimationsModule,
    NgSelectModule
  ],
  // entryComponents: [MotorOpenPolicyHeaderComponent],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule {}
