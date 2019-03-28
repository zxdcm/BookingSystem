import { links } from "../settings/links";
import { RequestService } from "./requestService";

class ImageService {
  static getHotelImageLink(hotelId) {
    console.log("called");
    if (hotelId === 1)
      return "https://s-ec.bstatic.com/xdata/images/hotel/max500/74529578.jpg";
    else
      return "https://t-ec.bstatic.com/xdata/images/hotel/max500/62261541.jpg";
    return links.getHotelImage(hotelId);
  }
}

export { ImageService };
