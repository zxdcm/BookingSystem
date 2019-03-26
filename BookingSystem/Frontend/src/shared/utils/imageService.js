import { links } from "../settings/links";
import { RequestService } from "./requestService";

class ImageService {
  static getHotelImageLink(hotelId) {
    return links.getHotelImage(hotelId);
  }
}

export { ImageService };
