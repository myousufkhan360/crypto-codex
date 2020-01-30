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

import { MotorRiskDetailService } from "src/app/shared/motor-risk-detail.service";
import { MotorRiskDetail } from "src/app/shared/motor-risk-detail.model";

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
import { OpenPolMaster } from "src/app/shared/open-pol-master.model";
import { InsCertTypeService } from "src/app/shared/ins-cert-type.service";
import { CalcTypeService } from "src/app/shared/calc-type.service";
import { IsRenewalService } from "src/app/shared/is-renewal.service";
import { OpenPolMasterService } from "src/app/shared/open-pol-master.service";
import { ProductBus } from "src/app/shared/product-bus.model";
import { ProductBusService } from "src/app/shared/product-bus.service";
import { OpenPolBus } from "src/app/shared/open-pol-bus.model";
import { OpenPolBusService } from "src/app/shared/open-pol-bus.service";
import { CityMasterService } from "src/app/shared/city-master.service";
import { CityMaster } from "src/app/shared/city-master.model";
import { DistrictMasterService } from "src/app/shared/district-master.service";
import { DistrictMaster } from "src/app/shared/district-master.model";
import { GendersMasterService } from "src/app/shared/genders-master.service";
import { GendersMaster } from "src/app/shared/genders-master.model";
import { VehicleMasterService } from "src/app/shared/vehicle-master.service";
import { VehicleMaster } from "src/app/shared/vehicle-master.model";
import { VehicleTypeMasterService } from "src/app/shared/vehicle-type-master.service";
import { VehicleTypeMaster } from "src/app/shared/vehicle-type-master.model";
import { VeodMasterService } from "src/app/shared/veod-master.service";
import { VeodMaster } from "src/app/shared/veod-master.model";
import { ColorMasterService } from "src/app/shared/color-master.service";
import { ColorMaster } from "src/app/shared/color-master.model";
import { RatingFactorMasterService } from "src/app/shared/rating-factor-master.service";
import { RatingFactorMaster } from "src/app/shared/rating-factor-master.model";

@Component({
  selector: 'app-motor-risk-detail',
  templateUrl: './motor-risk-detail.component.html',
  styleUrls: ['./motor-risk-detail.component.css']
})
export class MotorRiskDetailComponent implements OnInit {
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
  openPolAssortedCodeList : OpenPolMaster[];
  cityList: CityMaster[];
  districtList: DistrictMaster[];
  gendersList: GendersMaster[];
  vehicleList: VehicleMaster[];
  vehicleTypeList: VehicleTypeMaster[];
  colorList: ColorMaster[];
  ratingFactorList:RatingFactorMaster[];
  veodList: VeodMaster[];
  productBus: ProductBus;
  assortedCode: string;
  openPolBus: OpenPolBus;
  CertHeaderAssortedCode;

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
    public service: MotorRiskDetailService,
    private policyTypeService: PolicyTypeService,
    private productService: ProductService,
    private clientService: ClientService,
    private agencyService: AgencyService,
    private takafulTypeService: TakafulTypeService,
    private insCertTypeService: InsCertTypeService,
    private calcTypeService: CalcTypeService,
    private isRenewalService: IsRenewalService,
    private openPolMasterService: OpenPolMasterService,
    private productBusService: ProductBusService,
    private OpenPolBusService: OpenPolBusService,
    private cityMasterService: CityMasterService,
    private districtMasterService: DistrictMasterService,
    private gendersMasterService: GendersMasterService,
    private vehicleMasterService: VehicleMasterService,
    private vehicleTypeMasterService: VehicleTypeMasterService,
    private veodMasterService: VeodMasterService,
    private colorMasterService: ColorMasterService,
    private ratingFactorMasterService: RatingFactorMasterService
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

      this.openPolMasterService
      .getOpenPolMaster()
      .then(res => (this.openPolAssortedCodeList = res as OpenPolMaster[]));

    this.insCertTypeService
      .getInsCertTypeMaster()
      .then(res => (this.insCertTypeList = res as InsCertType[]));

    this.clientService
      .getClientMaster()
      .then(res => (this.clientList = res as Client[]));

      this.cityMasterService
      .getCityMaster()
      .then(res => (this.cityList = res as CityMaster[]));

      this.districtMasterService
      .getDistrictMaster()
      .then(res => (this.districtList = res as DistrictMaster[]));

      this.gendersMasterService
      .getGendersMaster()
      .then(res => (this.gendersList = res as GendersMaster[]));

      this.vehicleMasterService
      .getVehicleMaster()
      .then(res => (this.vehicleList = res as VehicleMaster[]));

      this.vehicleTypeMasterService
      .getVehicleTypeMaster()
      .then(res => (this.vehicleTypeList = res as VehicleTypeMaster[]));

      this.veodMasterService
      .getVeodMaster()
      .then(res => (this.veodList = res as VeodMaster[]));

      this.colorMasterService
      .getColorMaster()
      .then(res => (this.colorList = res as ColorMaster[]));

      this.ratingFactorMasterService
      .getRatingFactorMaster()
      .then(res => (this.ratingFactorList = res as RatingFactorMaster[]));

    if (localStorage.getItem('CertAssortedCode') == null || localStorage.getItem('CertAssortedCode') == "0") {
      this.resetForm();
    } else {
      this.service.getByHeaderId(localStorage.getItem('CertAssortedCode'))
      // .then(res => (this.service.formData = res));
      .then(res => {
        this.service.formData = Object.assign([], res);
        console.log(res);
      });
    }



    this.assortedCode = this.currentRoute.snapshot.paramMap.get("id");
    // console.log(this.assortedCode);

  
    if (this.assortedCode != null) {
      this.service
        .getById(this.assortedCode)
        .then(res => (this.service.formData = res));
    }

    // this.CertHeaderAssortedCode = parseInt(this.currentRoute.snapshot.paramMap.get("id"));
    // SecurityPolicyViolationEvent;
    // if (this.CertHeaderAssortedCode == null || this.CertHeaderAssortedCode == 0) {
    //   this.resetForm();
    // } else {
    //   this.service.getByHeaderId(this.CertHeaderAssortedCode).then(res => {
    //     this.service.formData = Object.assign([], res);
    //     // console.log(res);
    //   });
    // }

  }

  onSubmit(form: NgForm) {
    try {
      this.IsFormSubmitted = true;
      console.log(this.service.formData.MotorRiskCode);
      if (this.isValid) {
        this.service.saveOrUpdateData().subscribe(res => {
          this.resetForm(form);
          this.service.formData = Object.assign(
            {},
            res as MotorRiskDetail
          );

          console.log(this.service.formData);
          this.router.navigate([
            "/motor-risk-detail/", //change path for routing
            this.service.formData.MotorRiskCode
          ]);

          this.toastr.success("Submitted successfully", "Tms-Plus");
          this.IsFormSubmitted = false;
        });
      }
      localStorage.removeItem('CertAssortedCode');
    } catch (error) {
      console.error(error);
    }
  }

  validateForm() {
    this.isValid = true;
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
      TakafulTypeCode: 0,
      PolicyTypeCode: "",
      CertificateCode: "",
      IsRenewCode: "0",
      CalcTypeCode: "",
      Remarks: "",
      OpenPolAssortedCode : "",
      VehicleCode: "",
      VehicleMakeCode:"",
      VehicleModel:0,
      RatingFactorCode:0,
      PreviousValue:0,
      UpdatedValue:0,
      Rate:0,
      NetContribution:0,
      Mileage:0,
      ColorCode:0,
      RegistrationNumber:"",
      EngineNumber:"",
      ChasisNumber:"",
      VehicleTypeCode:0,
      CertTypeCode:0,
      ParticipantName:"",
      ParticipantAddress:"",
      CityCode:0,
      DistrictCode:0,
      CnicNumber:"",
      BirthDate: formatDate(new Date(), "dd/MM/yyyy", "en"),
      GenderCode:0,
      MobileNumber:"",
      ResNumber:"",
      OfficeNumber:"",
      EmailAddress:"",
      PoDate: formatDate(new Date(), "dd/MM/yyyy", "en"),
      PoNumber:"",
      Tenure:0,
      VeodCode:0,
      CommisionRate:0,
      Deductible:0,
      ContractMatDate : formatDate(new Date(), "dd/MM/yyyy", "en"),
      MotorRiskCode: -1,
      MotorRiskSerial: 0,
      PolicyDate: formatDate(new Date(), "dd/MM/yyyy", "en") ,
      IsActive:0,
      IsCanceled:0,
      PreviousMotorRiskCode : 0

    };
  }


  async onChangeOfCity($event) {
    await this.districtMasterService
      .getByCityCode($event.CityCode)
      .then(res => (this.districtList = res as DistrictMaster[]));
       let cityCode = $event.CityCode;
      console.log(cityCode);
  }

  async onChangeOfClient($event) {
    await this.openPolMasterService
      .getByClientCode($event.ClientCode)
      .then(res => (this.openPolAssortedCodeList = res as OpenPolMaster[]));
       let clientCode = $event.ClientCode;
      console.log($event.ClientCode);
  }

  async onChangeOfOpenPol($event) {
    await this.OpenPolBusService
      .GetOpenPolBusByCode($event.OpenPolAssortedCode)
      .then(res => (this.openPolBus = res as OpenPolBus));
    let openPolAssortedCode = $event.OpenPolAssortedCode;

    console.log(openPolAssortedCode);
    this.service.formData.ProductCode = this.openPolBus.ProductCode;
    // this.service.formData.AgencyCode = this.openPolBus.AgencyCode;
    // this.service.formData.PolicyTypeCode = this.openPolBus.PolicyTypeCode;
    // this.service.formData.CertificateCode = this.openPolBus.InsCertTypeCode;
    // this.service.formData.CommRate = this.openPolBus.CommRate;
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

    // this.service.formData.ClientCode = this.productBus.ClientCode;
    // this.service.formData.AgencyCode = this.productBus.AgencyCode;
    // this.service.formData.PolicyTypeCode = this.productBus.PolicyTypeCode;
    // this.service.formData.CertificateCode = this.productBus.InsCertTypeCode;
    // this.service.formData.CommRate = this.productBus.CommRate;
  }


 

  onBtnNew() {
    this.router.navigate(["/motor-risk-detail/"]);
  }
}
