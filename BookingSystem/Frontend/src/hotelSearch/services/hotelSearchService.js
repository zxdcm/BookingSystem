import { links } from "../../shared/settings/links";
import { RequestService, QueryService } from "../../shared/utils/";
class HotelSearchService {
  static fetchHotels = data => {
    const query = QueryService.hotelQueryFromData(data);
    const requestUrl = `${links.getHotel()}${query}`;
    return RequestService.get(requestUrl);
  };

  static fetchCities = data => {
    const query = QueryService.buildQuery(data);
    const requestUrl = `${links.getCity()}${query}`;
    return RequestService.get(requestUrl);
  };

  static fetchCountries = data => {
    const query = QueryService.buildQuery(data);
    const requestUrl = `${links.getCountry()}${query}`;
    return RequestService.get(requestUrl);
  };

  static fetchRoomSizes = () => {
    const requestUrl = links.getRoomSizes();
    return RequestService.get(requestUrl);
  };
}

export { HotelSearchService };
