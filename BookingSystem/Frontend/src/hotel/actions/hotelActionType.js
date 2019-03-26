const fetchHotelActionsType = {
  FETCH_HOTEL_REQUEST: "FETCH_HOTELS_REQUEST",
  FETCH_HOTEL_SUCCESS: "FETCH_HOTELS_SUCCESS",
  FETCH_HOTEL_FAILURE: "FETCH_HOTELS_FAILURE"
};

const fetchRoomsActionsType = {
  FETCH_ROOMS_REQUEST: "FETCH_ROOMS_REQUEST",
  FETCH_ROOMS_SUCCESS: "FETCH_ROOMS_SUCCESS",
  FETCH_ROOMS_FAILURE: "FETCH_ROOMS_FAILURE"
};

const hotelActionType = {
  ...fetchHotelActionsType,
  ...fetchRoomsActionsType
};

export { hotelActionType };
