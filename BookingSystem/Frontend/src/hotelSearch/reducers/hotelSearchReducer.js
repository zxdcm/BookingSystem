import { handleActions } from "redux-actions";
import { combineReducers } from "redux";
import { HotelSearchActionType as actionType } from "../actions/hotelSearchActionType";

const initialState = {
  hotels: [],
  error: null,
  isFetching: false,
  cities: []
};

const fetchHotelsReducer = handleActions(
  {
    [actionType.FETCH_HOTELS_REQUEST]: state => ({
      ...state,
      isFetching: true
    }),
    [actionType.FETCH_HOTELS_SUCCESS]: (state, action) => ({
      ...state,
      isFetching: false,
      hotels: action.payload.hotels
    }),
    [actionType.FETCH_HOTELS_FAILURE]: (state, action) => ({
      ...state,
      isFetching: false,
      error: action.payload.error
    })
  },
  initialState
);

const fetchCitiesReducer = handleActions(
  {
    [actionType.FETCH_CITIES_REQUEST]: state => ({
      ...state,
      isFetching: true
    }),
    [actionType.FETCH_CITIES_SUCCESS]: (state, action) => ({
      ...state,
      isFetching: false,
      hotels: action.payload.hotels
    }),
    [actionType.FETCH_CITIES_FAILURE]: (state, action) => ({
      ...state,
      isFetching: false,
      error: action.payload.error
    })
  },
  initialState
);

export { fetchHotelsReducer as hotelSearchReducer };
