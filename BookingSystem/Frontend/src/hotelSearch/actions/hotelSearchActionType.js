const FetchHotelsActionsType = {
  FETCH_HOTELS_REQUEST: "FETCH_HOTELS_REQUEST",
  FETCH_HOTELS_SUCCESS: "FETCH_HOTELS_SUCCESS",
  FETCH_HOTELS_FAILURE: "FETCH_HOTELS_FAILURE"
};

const HotelSearchActionType = {
  ...FetchHotelsActionsType
};

export { HotelSearchActionType };
