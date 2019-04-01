const links = {
  getHotel: () => "/hotel/",
  getCity: () => "/city/",
  getCountry: () => "/country/",
  getRoom: () => "/room/",
  getExtraService: () => "/extraservice/",
  getHotelRooms: id => `hotel/${id}/rooms`,
  getHotelSearch: () => "/search/",
  getHotelImage: id => `/hotel/${id}/image`,
  getHotelImages: id => `/hotel/${id}/images`,
  getRoomSizes: () => "/room/roomSizes/"
};

export { links };
