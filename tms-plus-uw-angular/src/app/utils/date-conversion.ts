import * as _ from "lodash";
import * as moment from "moment";

export function ConvertDMYStringToDate(dmyString: string): Date {
  let dateArray;
  dateArray = _.split(dmyString, "/");

  let result = new Date(dateArray[2] + "-" + dateArray[1] + "-" + dateArray[0]);

  return result;
}

export function IsGreaterThanToday(_date): boolean {
  let _thisDate;

  if (_date == "string") {
    _thisDate = moment(_date, "DD/MM/YYYY").format("YYYYMMDD");
  } else {
    _thisDate = moment(_date).format("YYYYMMDD");
  }

  console.log(_thisDate, moment.utc().format("YYYYMMDD"));

  if (_thisDate > moment.utc().format("YYYYMMDD")) {
    return false;
  } else {
    return true;
  }
}
