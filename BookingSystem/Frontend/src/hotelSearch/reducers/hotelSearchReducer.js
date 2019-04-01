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
  pageInfo: { page: 1, pageSize: config.pageSize, totalItems: 0 },
  error: null,
  isFetching: false
};

const pageMap = {
  [actionType.SET_PAGE]: (state, action) => ({
    ...state,
    pageInfo: { ...state.pageInfo, page: action.payload.page }
  }),
  [actionType.RESET_PAGE]: (state, action) => ({
    ...state,
    pageInfo: { page: 1, pageSize: config.pageSize, totalItems: 0 }
  })
};

const fetchHotelsReducer = handleActions(
  {
    ...fetchHotelsMap,
    ...pageMap
  },
  hotelsInitialState
);

const searchFormInitialState = {
  startDate: new Date(),
  endDate: new Date(),
  roomSize: { label: 1, value: 1 },
  city: "",
  country: "",
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

const resetMap = {
  [actionType.RESET_CITY_OPTIONS]: state => ({
    ...state,
    cityOptions: []
  }),
  [actionType.RESET_COUNTRY_OPTIONS]: state => ({
    ...state,
    countryOptions: []
  }),
  [actionType.RESET_SEARCH_FORM]: state => ({
    ...state,
    startDate: new Date(),
    endDate: new Date(),
    roomSize: { label: 1, value: 1 },
    city: "",
    country: "",
    countriesOptions: [],
    cityOptions: [],
    roomSizeOptions: []
  })
};

const setMap = {
  [actionType.SET_CITY]: (state, action) => ({
    ...state,
    city: action.payload.city
  }),
  [actionType.SET_COUNTRY]: (state, action) => ({
    ...state,
    country: action.payload.country
  }),
  [actionType.SET_START_DATE]: (state, action) => ({
    ...state,
    startDate: action.payload.startDate,
    endDate: action.payload.startDate
  }),
  [actionType.SET_END_DATE]: (state, action) => ({
    ...state,
    endDate: action.payload.endDate
  }),
  [actionType.SET_ROOM_SIZE]: (state, action) => ({
    ...state,
    roomSize: action.payload.roomSize
  }),
  [actionType.SET_CITY]: (state, action) => ({
    ...state,
    city: action.payload.city
  }),
  [actionType.SET_COUNTRY]: (state, action) => ({
    ...state,
    country: action.payload.country,
    city: "",
    cityOptions: []
  })
};

const searchFormReducer = handleActions(
  {
    ...searchFormCityOptionsMap,
    ...searchFormCountryOptionsMap,
    ...searchFormRoomSizeOptionsMap,
    ...setMap,
    ...resetMap
  },
  searchFormInitialState
);

const hotelSearchReducer = combineReducers({
  hotels: fetchHotelsReducer,
  searchForm: searchFormReducer
});

export { hotelSearchReducer };
