import { links } from "../../shared/settings/links";
import { RequestService, buildQuery } from "../../shared/utils/";

class HotelService {
  static fetchHotel = id => {
    const requestUrl = `${links.getHotel(id)}`;
    return RequestService.get(requestUrl);
  };

  static fetchHotelRooms = id => {
    const requestUrl = `${links.getHotelRooms(id)}`;
    return RequestService.get(requestUrl);
  };
}

export { HotelService };
