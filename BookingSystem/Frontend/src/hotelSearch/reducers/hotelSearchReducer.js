import { handleActions } from "redux-actions";
import { combineReducers } from "redux";
import { hotelSearchActionType as actionType } from "../actions/";
import { config } from "../../shared/settings/config";
const fetchHotelsMap = {
  [actionType.FETCH_HOTELS_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.FETCH_HOTELS_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    hotels: action.payload.data.items,
    pageInfo: action.payload.data.pageInfo
  }),
  [actionType.FETCH_HOTELS_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const hotelsInitialState = {
  hotels: [],
  pageInfo: { page: 1, pageSize: config.pageSize, totalPages: 1 },
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
  roomSizeOptions: [],
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

const searchFormRoomSizeOptionsMap = {
  [actionType.LOAD_ROOM_SIZE_OPTIONS_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.LOAD_ROOM_SIZE_OPTIONS_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    roomSizeOptions: action.payload.roomSizeOptions
  }),
  [actionType.LOAD_ROOM_SIZE_OPTIONS_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const resetOptionsMap = {
  [actionType.RESET_CITY_OPTIONS]: state => ({
    ...state,
    cityOptions: []
  }),
  [actionType.RESET_COUNTRY_OPTIONS]: state => ({
    ...state,
    countryOptions: []
  })
};

const searchFormReducer = handleActions(
  {
    ...searchFormCityOptionsMap,
    ...searchFormCountryOptionsMap,
    ...searchFormRoomSizeOptionsMap,
    ...resetOptionsMap
  },
  searchFormInitialState
);

const hotelSearchReducer = combineReducers({
  hotels: fetchHotelsReducer,
  searchForm: searchFormReducer
});

export { hotelSearchReducer };
