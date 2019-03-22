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
  currentCity: "",
  currentCountry: "",
  isFetching: false
};

const searchFormCitiesMap = {
  [actionType.FETCH_CITIES_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.FETCH_CITIES_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    cities: action.payload.cities
  }),
  [actionType.FETCH_CITIES_WITH_MERGE_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    cities: { ...state.cities, ...action.payload.cities }
  }),
  [actionType.FETCH_CITIES_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const searchFormCountriesMap = {
  [actionType.FETCH_COUNTRIES_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.FETCH_COUNTRIES_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    countries: action.payload.countries
  }),
  [actionType.FETCH_COUNTIRES_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const searchFormMap = {
  [actionType.SET_COUNTRY]: (state, action) => ({
    ...state,
    currentCity: "",
    currentCountry: action.payload.country
  }),
  [actionType.SET_CITY]: (state, action) => ({
    ...state,
    currentCity: action.payload.city
  })
};

const searchFormOptionsMap = {
  [actionType.SET_CITY_OPTIONS]: (state, action) => ({
    ...state,
    cityOptions: action.payload.cityOptions
  })
};

const searchFormReducer = handleActions(
  {
    ...searchFormCitiesMap,
    ...searchFormCountriesMap,
    ...searchFormMap,
    ...searchFormOptionsMap
  },
  searchFormInitialState
);

const hotelSearchReducer = combineReducers({
  hotels: fetchHotelsReducer,
  searchForm: searchFormReducer
});

export { hotelSearchReducer };
