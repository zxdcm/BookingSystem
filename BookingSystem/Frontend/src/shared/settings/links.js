const links = {
  getHotel: () => "/hotel/",
  getCity: () => "/city/",
  getCountry: () => "/country/",
  getRoom: () => "/room/",
  getExtraService: () => "/extraservice/",
  getHotelRooms: id => `hotel/${id}/rooms`
};

export { links };