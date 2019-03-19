import { links } from "../../shared/settings/links";
import { RequestService } from "../../shared/utils/requestService";

class HotelSearchService {
  static fetchHotels = query => {
    const requestUrl = `${links.HOTEL_SEARCH}`;
    return RequestService.get(requestUrl);
  };

  static fetchHotelById = id => {
    const requestUrl = `${links.HOTEL_PAGE(id)}`;
    return RequestService.get(requestUrl);
  };
}

export { HotelSearchService };
