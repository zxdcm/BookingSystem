import { handleActions } from "redux-actions";
import { combineReducers } from "redux";
import { hotelActionType as actionType } from "../actions/";

const hotelInitialState = {
  hotel: null,
  rooms: [],
  isFetching: false,
  error: null
};

const fetchHotelMap = {
  [actionType.FETCH_HOTEL_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.FETCH_HOTEL_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    hotel: action.payload.hotel
  }),
  [actionType.FETCH_HOTEL_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const fetchRoomsMap = {
  [actionType.FETCH_ROOMS_REQUEST]: state => ({
    ...state,
    isFetching: true
  }),
  [actionType.FETCH_ROOMS_SUCCESS]: (state, action) => ({
    ...state,
    isFetching: false,
    rooms: action.payload.rooms
  }),
  [actionType.FETCH_ROOMS_FAILURE]: (state, action) => ({
    ...state,
    isFetching: false,
    error: action.payload.error
  })
};

const hotelReducer = handleActions(
  {
    ...fetchHotelMap,
    ...fetchRoomsMap
  },
  hotelInitialState
);

export { hotelReducer };
