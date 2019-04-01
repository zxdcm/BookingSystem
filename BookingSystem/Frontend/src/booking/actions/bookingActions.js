import { createAction } from "redux-actions";
import { bookingActionType as actionType } from "./bookingActionType";
import { BookingService } from "../services";
import { handleError } from "../../shared/utils";

const fetchBookingRequest = createAction(actionType.FETCH_BOOKING_REQUEST);
const fetchBookingSuccess = createAction(
  actionType.FETCH_BOOKING_SUCCESS,
  data => ({ booking: data })
);
const fetchBookingFailure = createAction(
  actionType.FETCH_BOOKING_FAILURE,
  error => ({ error: error })
);

class BookingActions {
  static fetchBooking = id => dispatch => {
    dispatch(fetchBookingRequest);
    BookingService.fetchBooking(id)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchBookingSuccess(jsonResult));
        return jsonResult;
      })
      .catch(error => dispatch(fetchBookingFailure(error)));
  };
}

export { BookingActions };
