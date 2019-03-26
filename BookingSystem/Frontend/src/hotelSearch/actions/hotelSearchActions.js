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

const loadCityOptionsRequest = createAction(
  actionType.LOAD_CITY_OPTIONS_REQUEST
);
const loadCityOptionsSuccess = createAction(
  actionType.LOAD_CITY_OPTIONS_SUCCESS,
  options => ({ cityOptions: options })
);
const loadCityOptionsFailure = createAction(
  actionType.LOAD_CITY_OPTIONS_FAILURE,
  error => ({ error: error })
);

const loadCountryOptionsRequest = createAction(
  actionType.LOAD_COUNTRY_OPTIONS_REQUEST
);
const loadCountryOptionsSuccess = createAction(
  actionType.LOAD_COUNTRY_OPTIONS_SUCCESS,
  options => ({ countryOptions: options })
);
const loadCountryOptionsFailure = createAction(
  actionType.LOAD_COUNTRY_OPTIONS_FAILURE,
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
      .catch(error => {
        dispatch(fetchHotelsFailure(error));
      });
  };

  static setCityOptions = createAction(actionType.SET_CITY_OPTIONS, data => ({
    cityOptions: data
  }));

  static setCountryOptions = createAction(
    actionType.SET_COUNTRY_OPTIONS,
    data => ({
      countryOptions: data
    })
  );

  static loadCityOptions = search => dispatch => {
    dispatch(loadCityOptionsRequest);
    return HotelSearchService.fetchCities({
      cityName: search.cityName,
      countryName: search.countryName
    })
      .then(handleError)
      .then(result => result.json())
      .then(cities => {
        const citiesOptions = OptionsService.getOptions(
          cities,
          "cityName",
          "cityId"
        );
        dispatch(loadCityOptionsSuccess(citiesOptions));
      })
      .catch(error => {
        dispatch(loadCityOptionsFailure(error));
      });
  };

  static loadCountryOptions = search => dispatch => {
    dispatch(loadCountryOptionsRequest);
    return HotelSearchService.fetchCountries({
      countryName: search.countryName
    })
      .then(handleError)
      .then(result => result.json())
      .then(countries => {
        const countriesOptions = OptionsService.getOptions(
          countries,
          "countryName",
          "countryId"
        );
        dispatch(loadCountryOptionsSuccess(countriesOptions));
      })
      .catch(error => {
        dispatch(loadCountryOptionsFailure(error));
      });
  };
}

export { HotelSearchActions };
