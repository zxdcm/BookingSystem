import { createAction } from "redux-actions";
import { hotelActionType as actionType } from "./hotelActionType";
import { HotelService } from "../services/";
import { handleError } from "../../shared/utils/";

const fetchHotelRequest = createAction(actionType.FETCH_HOTEL_REQUEST);
const fetchHotelSuccess = createAction(
  actionType.FETCH_HOTEL_SUCCESS,
  data => ({ hotel: data })
);
const fetchHotelFailure = createAction(
  actionType.FETCH_HOTEL_FAILURE,
  error => ({ error: error })
);

const fetchRoomsRequest = createAction(actionType.FETCH_ROOMS_REQUEST);
const fetchRoomsSuccess = createAction(
  actionType.FETCH_ROOMS_SUCCESS,
  data => ({ rooms: data })
);
const fetchRoomsFailure = createAction(
  actionType.FETCH_ROOMS_FAILURE,
  error => ({ error: error })
);

class HotelActions {
  static fetchHotel = id => dispatch => {
    dispatch(fetchHotelRequest);
    return HotelService.fetchHotel(id)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchHotelSuccess(jsonResult));
        return jsonResult;
      })
      .catch(error => dispatch(fetchHotelFailure(error)));
  };
  static fetchAvailableRooms = id => dispatch => {
    dispatch(fetchRoomsRequest);
    return HotelService.fetchHotelRooms(id)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchRoomsSuccess(jsonResult));
        return jsonResult;
      })
      .catch(error => dispatch(fetchRoomsFailure(error)));
  };
}

export { HotelActions };
