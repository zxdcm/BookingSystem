import { links } from "../settings/links";
import { config } from "../settings/config";
import { RequestService } from "./requestService";

class ImageService {
  static getHotelImageLink(hotelId) {
    RequestService.get(links.getHotelImage(hotelId));
  }
}

export { ImageService };
