import { links } from "../../shared/settings/links";
import { RequestService } from "../../shared/utils/requestService";

class HotelSearchService {
  static FetchHotels = query => {
    const requestUrl = `${links.HOTEL_SEARCH}`;
    return RequestService.get(requestUrl);
  };

  static FetchHotelById = id => {
    const requestUrl = `${links.HOTEL_PAGE(id)}`;
    return RequestService.get(requestUrl);
  };
}

export { HotelSearchService };
