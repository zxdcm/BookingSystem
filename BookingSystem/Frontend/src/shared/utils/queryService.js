import { dateFormat } from "../settings/dateFormat";
import { isEmpty } from "lodash";
import moment from "moment";

class QueryService {
  static hotelQueryFromData = data => {
    if (isEmpty(data)) return "";
    const formattedData = { ...data };
    formattedData.startDate = moment(data.startDate).format(
      dateFormat.REQUEST_DATE_FORMAT
    );
    formattedData.endDate = moment(data.endDate).format(
      dateFormat.REQUEST_DATE_FORMAT
    );
    return QueryService.buildQuery(formattedData);
  };

  static buildQuery = data =>
    "?" +
    Object.keys(data)
      .filter(key => data[key])
      .map(key => [key, data[key]].map(encodeURIComponent).join("="))
      .join("&");
}

export { QueryService };
