import { dateFormat } from "../settings/dateFormat";
import { isEmpty } from "lodash";
import moment from "moment";

class QueryService {
  static hotelQueryFromData = data => {
    if (isEmpty(data)) return "";
    const formattedData = {};
    formattedData.startDate = moment(data.startDate).format(
      dateFormat.REQUEST_DATE_FORMAT
    );
    formattedData.endDate = moment(data.endDate).format(
      dateFormat.REQUEST_DATE_FORMAT
    );
    if (data.roomSize) {
      formattedData.roomSize = data.roomSize;
    }
    if (data.page) {
      formattedData.page = data.page;
      formattedData.pageSize = data.pageSize;
    }
    return QueryService.buildQuery(formattedData);
  };

  static buildQuery = data =>
    "?" +
    Object.keys(data)
      .filter(key => data[key] != null)
      .map(key => [key, data[key]].map(encodeURIComponent).join("="))
      .join("&");
}

export { QueryService };
