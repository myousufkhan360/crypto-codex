import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { DatePipe, formatDate } from "@angular/common";
import { ToastrService } from "ngx-toastr";
import {
  BsDatepickerModule,
  MonthPickerComponent
} from "ngx-bootstrap/datepicker";
import * as _ from "lodash";
import * as moment from "moment";

import { MotorOpenPolicyHeaderService } from "src/app/shared/motor-open-policy-header.service";
import { MotorOpenPolicyHeader } from "src/app/shared/motor-open-policy-header.model";

import { THIS_EXPR } from "@angular/compiler/src/output/output_ast";
import {
  ConvertDMYStringToDate,
  IsGreaterThanToday
} from "src/app/utils/date-conversion";
import { concat } from "rxjs";
import { PolicyTypeService } from "src/app/shared/policy-type.service";
import { PolicyType } from "src/app/shared/policy-type.model";
import { Product } from "src/app/shared/product.model";
import { ProductService } from "src/app/shared/product.service";
import { Agency } from "src/app/shared/agency.model";
import { Client } from "src/app/shared/client.model";
import { ClientService } from "src/app/shared/client.service";
import { AgencyService } from "src/app/shared/agency.service";
import { TakafulType } from "src/app/shared/takaful-type.model";
import { TakafulTypeService } from "src/app/shared/takaful-type.service";
import { InsCertType } from "src/app/shared/ins-cert-type.model";
import { CalcType } from "src/app/shared/calc-type.model";
import { IsRenewal } from "src/app/shared/is-renewal.model";
import { InsCertTypeService } from "src/app/shared/ins-cert-type.service";
import { CalcTypeService } from "src/app/shared/calc-type.service";
import { IsRenewalService } from "src/app/shared/is-renewal.service";
import { ProductBus } from "src/app/shared/product-bus.model";
import { ProductBusService } from "src/app/shared/product-bus.service";

@Component({
  selector: "app-motor-open-policy-header",
  templateUrl: "./motor-open-policy-header.component.html",
  styleUrls: ["./motor-open-policy-header.component.css"]
})
export class MotorOpenPolicyHeaderComponent implements OnInit {
  isValid: boolean = true;
  IsFormSubmitted: boolean = true;
  policyTypeList: PolicyType[];
  productList: Product[];
  agencyList: Agency[];
  clientList: Client[];
  takafulTypeList: TakafulType[];
  insCertTypeList: InsCertType[];
  calcTypeList: CalcType[];
  isRenewalList: IsRenewal[];
  productBus: ProductBus;
  assortedCode: string;

  calculateExpiryDate(): Date {
    let uwDay = formatDate(new Date(), "dd", "en");
    let uwMonth = formatDate(new Date(), "MM", "en");
    let uwNextYear = parseInt(formatDate(new Date(), "yyy", "en")) + 1;
    let newExpiryDateString = concat(
      uwDay,
      "/",
      uwMonth,
      "/",
      uwNextYear.toString()
    );
    return moment(new Date(uwNextYear, parseInt(uwMonth), parseInt(uwDay)))
      .subtract("day", 1)
      .toDate();
  }

  constructor(
    private toastr: ToastrService,
    private router: Router,
    private currentRoute: ActivatedRoute,
    private datePipe: DatePipe,
    public service: MotorOpenPolicyHeaderService,
    private policyTypeService: PolicyTypeService,
    private productService: ProductService,
    private clientService: ClientService,
    private agencyService: AgencyService,
    private takafulTypeService: TakafulTypeService,
    private insCertTypeService: InsCertTypeService,
    private calcTypeService: CalcTypeService,
    private isRenewalService: IsRenewalService,
    private productBusService: ProductBusService
  ) {}

  ngOnInit() {
    this.IsFormSubmitted = false;

    this.resetForm();

    this.agencyService
      .getAgencyMaster()
      .then(res => (this.agencyList = res as Agency[]));

    this.productService
      .GetClientBasedProduct()
      .then(res => (this.productList = res as Product[]));

    this.takafulTypeService
      .getTakafulTypeMaster()
      .then(res => (this.takafulTypeList = res as TakafulType[]));

    this.policyTypeService
      .getPolicyTypeMaster()
      .then(res => (this.policyTypeList = res as PolicyType[]));

    this.isRenewalService
      .getIsRenewalMaster()
      .then(res => (this.isRenewalList = res as IsRenewal[]));

    this.calcTypeService
      .getCalcTypeMaster()
      .then(res => (this.calcTypeList = res as CalcType[]));

    this.insCertTypeService
      .getInsCertTypeMaster()
      .then(res => (this.insCertTypeList = res as InsCertType[]));

    this.clientService
      .getClientMaster()
      .then(res => (this.clientList = res as Client[]));

    this.assortedCode = this.currentRoute.snapshot.paramMap.get("id");
    // console.log(this.assortedCode);

    if (this.assortedCode != null) {
      this.service
        .getById(this.assortedCode)
        .then(res => (this.service.formData = res));
    }
  }

  onSubmit(form: NgForm) {
    try {
      this.IsFormSubmitted = true;
      if (this.isValid) {
        this.service.saveOrUpdateData().subscribe(res => {
          this.resetForm(form);
          this.service.formData = Object.assign(
            {},
            res as MotorOpenPolicyHeader
          );

          console.log(this.service.formData);
          this.router.navigate([
            "/motor-open-policy-header/", //change path for routing
            this.service.formData.AssortedCode
          ]);

          this.toastr.success("Submitted successfully", "Tms-Plus");
          this.IsFormSubmitted = false;
        });
      }
    } catch (error) {
      console.error(error);
    }
  }

  validateForm() {
    this.isValid = true;
    // if (!this.IsLossDateGreater) {
    //   this.isValid = false;
    // } else if (this.service.formData.WorkshopCode == 0) {
    //   this.isValid = false;
    // } else if (this.service.formData.WorkshopTypeCode == 0) {
    //   this.isValid = false;
    // } else if (this.service.formData.CityCode == 0) {
    //   this.isValid = false;
    // } else if (this.service.formData.RelationCode == 0) {
    //   this.isValid = false;
    // } else if (this.service.formData.DriverName == null) {
    //   this.isValid = false;
    // }
    return this.isValid;
  }

  resetForm(form?: NgForm) {
    if (form != null) form.resetForm();

    this.service.formData = {
      AssortedCode: "-1",
      BranchCode: "01",
      DocTypeCode: "06",
      DocNo: 0,
      DocYear: parseInt(formatDate(new Date(), "yyyy", "en")),
      DocMonth: formatDate(new Date(), "MM", "en"),
      CancelBy: "",
      CancelDate: "",
      IsCancelled: 0,
      ClassCode: "02",
      GenerateAgainst: "",
      TmsAssortedCode: "",
      TmsGenerateAgainst: "",
      DocString: "",
      CreatedBy: "",
      CreatedDate: formatDate(new Date(), "dd/MM/yyyy", "en"),
      PostBy: "",
      PostDate: "",
      IssueDate: formatDate(new Date(), "dd/MM/yyyy", "en"),
      EffectiveDate: formatDate(new Date(), "dd/MM/yyyy", "en"),
      // ExpiryDate: formatDate(this.defaultExpiryDate, "dd/MM/yyyy", "en"),
      ExpiryDate: formatDate(this.calculateExpiryDate(), "dd/MM/yyyy", "en"),
      ProductCode: "",
      ClientCode: "",
      AgencyCode: "",
      CommRate: 0,
      TakafulTypeCode: "0",
      PolicyTypeCode: "",
      CertificateCode: "",
      IsRenewCode: "0",
      CalcTypeCode: "",
      Remarks: ""
    };
  }

  async onChange($event) {
    await this.productBusService
      .GetProductBusByCode($event.ProductCode)
      .then(res => (this.productBus = res as ProductBus));

    let productCode = $event.ProductCode;

    console.log(this.productBus);
    this.productBusService
      .GetProductBusByCode(productCode)
      .then(res => (this.productBus = res as ProductBus));
    console.log(this.productBus);

    this.service.formData.ClientCode = this.productBus.ClientCode;
    this.service.formData.AgencyCode = this.productBus.AgencyCode;
    this.service.formData.PolicyTypeCode = this.productBus.PolicyTypeCode;
    this.service.formData.CertificateCode = this.productBus.InsCertTypeCode;
    this.service.formData.CommRate = this.productBus.CommRate;
  }

  onBtnNew() {
    this.router.navigate(["/motor-open-policy-header/"]);
  }
}
