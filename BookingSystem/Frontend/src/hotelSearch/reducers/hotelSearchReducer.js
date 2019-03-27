import { handleActions } from "redux-actions";
import { combineReducers } from "redux";
import { hotelSearchActionType as actionType } from "../actions/";

const fetchHotelsMap = {
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
};

const hotelsInitialState = {
  hotels: [],
  error: null,
  isFetching: false
};

const fetchHotelsReducer = handleActions(
  {
    ...fetchHotelsMap
  },
  hotelsInitialState
);

const searchFormInitialState = {
  cities: [],
  countries: [],
  cityOptions: [],
  countryOptions: [],
  error: null,
  isFetching: false
};


const searchFormCountryOptionsMap = {
  [actionType.LOAD_COUNTRY_OPTIONS_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.LOAD_COUNTRY_OPTIONS_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    countryOptions: action.payload.countryOptions
  }),
  [actionType.LOAD_COUNTRY_OPTIONS_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const searchFormCityOptionsMap = {
  [actionType.LOAD_CITY_OPTIONS_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.LOAD_CITY_OPTIONS_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    cityOptions: action.payload.cityOptions
  }),
  [actionType.LOAD_CITY_OPTIONS_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const searchFormReducer = handleActions(
  {
    ...searchFormCityOptionsMap,
    ...searchFormCountryOptionsMap
  },
  searchFormInitialState
);

const hotelSearchReducer = combineReducers({
  hotels: fetchHotelsReducer,
  searchForm: searchFormReducer
});

export { hotelSearchReducer };
