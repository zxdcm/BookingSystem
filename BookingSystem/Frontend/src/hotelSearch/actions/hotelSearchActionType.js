const fetchHotelsActionsType = {
  FETCH_HOTELS_REQUEST: "FETCH_HOTELS_REQUEST",
  FETCH_HOTELS_SUCCESS: "FETCH_HOTELS_SUCCESS",
  FETCH_HOTELS_FAILURE: "FETCH_HOTELS_FAILURE"
};

const loadCitiesOptionsActionType = {
  LOAD_CITY_OPTIONS_REQUEST: "LOAD_CITY_OPTIONS_REQUEST",
  LOAD_CITY_OPTIONS_SUCCESS: "LOAD_CITY_OPTIONS_SUCCESS",
  LOAD_CITY_OPTIONS_FAILURE: "LOAD_CITY_OPTIONS_FAILURE"
};

const loadCountryOptionsActionType = {
  LOAD_COUNTRY_OPTIONS_REQUEST: "LOAD_COUNTRY_OPTIONS_REQUEST",
  LOAD_COUNTRY_OPTIONS_SUCCESS: "LOAD_COUNTRY_OPTIONS_SUCCESS",
  LOAD_COUNTRY_OPTIONS_FAILURE: "LOAD_COUNTRY_OPTIONS_FAILURE"
};

const loadRoomSizeOptionsActionType = {
  LOAD_ROOM_SIZE_OPTIONS_REQUEST: "LOAD_ROOM_SIZE_OPTIONS_REQUEST",
  LOAD_ROOM_SIZE_OPTIONS_SUCCESS: "LOAD_ROOM_SIZE_OPTIONS_SUCCESS",
  LOAD_ROOM_SIZE_OPTIONS_FAILURE: "LOAD_ROOM_SIZE_OPTIONS_FAILURE"
};

const hotelSearchActionType = {
  ...fetchHotelsActionsType,
  ...loadCitiesOptionsActionType,
  ...loadCountryOptionsActionType,
  ...loadRoomSizeOptionsActionType,
  SET_CITY_OPTIONS: "SET_CITY_OPTIONS",
  SET_COUNTRY_OPTIONS: "SET_COUNTRY_OPTIONS"
};

export { hotelSearchActionType };
