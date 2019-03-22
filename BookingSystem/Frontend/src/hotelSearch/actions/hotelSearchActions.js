import { createAction } from "redux-actions";
import { hotelSearchActionType as actionType } from "./hotelSearchActionType";
import { HotelSearchService } from "../services/";
import { handleError } from "../../shared/utils/";
import { OptionsService } from "../../shared/utils/optionsService";

const fetchHotelsRequest = createAction(actionType.FETCH_HOTELS_REQUEST);
const fetchHotelsSuccess = createAction(
  actionType.FETCH_HOTELS_SUCCESS,
  data => ({ hotels: data })
);
const fetchHotelsFailure = createAction(
  actionType.FETCH_HOTELS_FAILURE,
  error => ({ error: error })
);

const fetchCitiesRequest = createAction(actionType.FETCH_CITIES_REQUEST);
const fetchCitiesSuccess = createAction(
  actionType.FETCH_CITIES_SUCCESS,
  data => ({ cities: data })
);
const fetchCitiesFailure = createAction(
  actionType.FETCH_CITIES_FAILURE,
  error => ({ error: error })
);

const fetchCitiesWithMergeSuccess = createAction(
  actionType.FETCH_CITIES_WITH_MERGE_SUCCESS,
  data => ({ cities: data })
);

const fetchCountriesRequest = createAction(actionType.FETCH_CITIES_REQUEST);
const fetchCountriesSuccess = createAction(
  actionType.FETCH_CITIES_SUCCESS,
  data => ({ countries: data })
);
const fetchCountriesFailure = createAction(
  actionType.FETCH_CITIES_FAILURE,
  error => ({ error: error })
);

class HotelSearchActions {
  static fetchHotels = data => dispatch => {
    dispatch(fetchHotelsRequest());
    HotelSearchService.fetchHotels(data)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchHotelsSuccess(jsonResult));
        return jsonResult;
      })
      .catch(error => dispatch(fetchHotelsFailure(error)));
  };

  static fetchCities = (data, merge) => dispatch => {
    dispatch(fetchCitiesRequest());
    return HotelSearchService.fetchCities(data)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        if (merge) {
          dispatch(fetchCitiesSuccess(jsonResult));
        } else {
          dispatch(fetchCitiesWithMergeSuccess(jsonResult));
        }
        return jsonResult;
      })
      .catch(error => {
        const mockJsonResult = [
          { name: "Minsk", cityId: 1 },
          { name: "Moscow", cityId: 2 }
        ];
        dispatch(fetchCitiesSuccess(mockJsonResult));
        dispatch(fetchCitiesFailure(error));
        return mockJsonResult;
      });
  };

  static fetchCountires = data => dispatch => {
    dispatch(fetchCountriesRequest());
    HotelSearchService.fetchCountires(data)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchCountriesSuccess(jsonResult));
        return jsonResult;
      })
      .catch(error => dispatch(fetchCountriesFailure(error)));
  };

  static fsetCity = createAction(actionType.SET_CITY, city => ({
    city: city
  }));
  static setCountry = createAction(actionType.SET_COUNTRY, country => ({
    country: country
  }));

  static setCityOptions = createAction(actionType.SET_CITY_OPTIONS, data => ({
    cityOptions: data
  }));

  static loadCityOptions = search => dispatch => {
    console.log(search);
    const promise = HotelSearchActions.fetchCities({ name: search })(dispatch);
    promise.then(cities => {
      const options = OptionsService.getOptions(cities, "name", "cityId");
      dispatch(HotelSearchActions.setCityOptions(options));
    });
  };
}

export { HotelSearchActions };
