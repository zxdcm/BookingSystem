const FetchHotelsActionsType = {
  FETCH_HOTELS_REQUEST: "FETCH_HOTELS_REQUEST",
  FETCH_HOTELS_SUCCESS: "FETCH_HOTELS_SUCCESS",
  FETCH_HOTELS_FAILURE: "FETCH_HOTELS_FAILURE"
};

const FetchCitiesActionsType = {
  FETCH_CITIES_REQUEST: "FETCH_CITIES_REQUEST",
  FETCH_CITIES_SUCCESS: "FETCH_CITIES_SUCCESS",
  FETCH_CITIES_FAILURE: "FETCH_HOTELS_FAILURE"
};

const HotelSearchActionType = {
  ...FetchHotelsActionsType,
  ...FetchCitiesActionsType
};

export { HotelSearchActionType };
