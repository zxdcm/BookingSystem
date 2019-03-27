import { links } from "../../shared/settings/links";
import { RequestService, buildQuery } from "../../shared/utils/";

class BookingService {
  static fetchBooking = id => {
    const requestUrl = `${links.HOTEL_PAGE(id)}`;
    return RequestService.get(requestUrl);
  };
}

export { BookingService };
