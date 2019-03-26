import { links } from "../../shared/settings/links";
import { RequestService, buildQuery } from "../../shared/utils/";

class HotelSearchService {
  static fetchHotels = data => {
    const query = buildQuery(data);
    const requestUrl = `${links.getHotel()}${query}`;
    return RequestService.get(requestUrl);
  };

  static fetchCities = data => {
    const query = buildQuery(data);
    const requestUrl = `${links.getCity()}${query}`;
    return RequestService.get(requestUrl);
  };

  static fetchCountries = data => {
    const query = buildQuery(data);
    const requestUrl = `${links.getCountry()}${query}`;
    return RequestService.get(requestUrl);
  };
}

export { HotelSearchService };
