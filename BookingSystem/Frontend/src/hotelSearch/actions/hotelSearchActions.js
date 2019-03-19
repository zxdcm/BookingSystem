import { createAction } from "redux-actions";
import { HotelSearchActionType as ActionType } from "./hotelSearchActionType";
import { HotelSearchService } from "../services/hotelSearchService";
import { handleError } from "../../shared/utils/handleError";

class HotelSearchActions {
  static FetchHotels = query => {
    const fetchHotelsRequest = createAction(ActionType.FETCH_HOTELS_REQUEST);
    const fetchHotelsSuccess = createAction(
      ActionType.FETCH_HOTELS_SUCCESS,
      data => ({ hotels: data })
    );

    const fetchHotelsFailure = createAction(
      ActionType.FETCH_HOTELS_FAILURE,
      error => ({ error: error })
    );

    return dispatch => {
      dispatch(fetchHotelsRequest());
      HotelSearchService.FetchHotels(query)
        .then(handleError)
        .then(result => result.json())
        .then(jsonResult => {
          dispatch(fetchHotelsSuccess(jsonResult));
          return jsonResult;
        })
        .catch(error => dispatch(fetchHotelsFailure(error)));
    };
  };
}

export { HotelSearchActions };
