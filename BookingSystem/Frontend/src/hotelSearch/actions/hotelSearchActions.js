import { createAction } from "redux-actions";
import { HotelSearchActionType as ActionType } from "./hotelSearchActionType";
import { HotelSearchService } from "../services/hotelSearchService";
import { handleError } from "../../shared/utils/handleError";

const fetchHotelsRequest = createAction(ActionType.FETCH_HOTELS_REQUEST);
const fetchHotelsSuccess = createAction(
  ActionType.FETCH_HOTELS_SUCCESS,
  data => ({ hotels: data })
);
const fetchHotelsFailure = createAction(
  ActionType.FETCH_HOTELS_FAILURE,
  error => ({ error: error })
);

class HotelSearchActions {
  static fetchHotels = query => dispatch => {
    dispatch(fetchHotelsRequest());
    HotelSearchService.fetchHotels(query)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchHotelsSuccess(jsonResult));
        return jsonResult;
      })
      .catch(error => dispatch(fetchHotelsFailure(error)));
  };
}

export { HotelSearchActions };
