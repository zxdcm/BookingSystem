import { createAction } from "redux-actions";
import { hotelSearchActionType as actionType } from "./hotelSearchActionType";
import { HotelSearchService } from "../services/";
import { handleError } from "../../shared/utils/";
import { OptionsService } from "../../shared/utils/optionsService";
import { config } from "../../shared/settings/config";

const fetchHotelsRequest = createAction(actionType.FETCH_HOTELS_REQUEST);
const fetchHotelsSuccess = createAction(
  actionType.FETCH_HOTELS_SUCCESS,
  data => ({ data: data })
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

const loadRoomSizeOptionsRequest = createAction(
  actionType.LOAD_ROOM_SIZE_OPTIONS_REQUEST
);

const loadRoomSizeOptionsSuccess = createAction(
  actionType.LOAD_ROOM_SIZE_OPTIONS_SUCCESS,
  options => ({ roomSizeOptions: options })
);
const loadRoomSizeOptionsFailure = createAction(
  actionType.LOAD_ROOM_SIZE_OPTIONS_FAILURE,
  error => ({ error: error })
);

class HotelSearchActions {
  static fetchHotels = () => (dispatch, getState) => {
    dispatch(fetchHotelsRequest());
    const searchForm = getState().hotelSearch.searchForm;
    const pageInfo = getState().hotelSearch.hotels.pageInfo;
    const requestData = {
      startDate: searchForm.startDate,
      endDate: searchForm.endDate,
      roomSize: searchForm.roomSize.value,
      cityId: searchForm.city.value,
      countryId: searchForm.country.value,
      page: pageInfo.page,
      pageSize: pageInfo.pageSize
    };
    HotelSearchService.fetchHotels(requestData)
      .then(handleError)
      .then(result => result.json())
      .then(jsonResult => {
        dispatch(fetchHotelsSuccess(jsonResult));
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

  static setCity = createAction(actionType.SET_CITY, data => ({ city: data }));

  static setCountry = createAction(actionType.SET_COUNTRY, data => ({
    country: data
  }));

  static setStartDate = createAction(actionType.SET_START_DATE, data => ({
    startDate: data
  }));
  static setEndDate = createAction(actionType.SET_END_DATE, data => ({
    endDate: data
  }));

  static setRoomSize = createAction(actionType.SET_ROOM_SIZE, data => ({
    roomSize: data
  }));

  static setPage = createAction(actionType.SET_PAGE, data => ({ page: data }));

  static resetPage = createAction(actionType.RESET_PAGE);

  static resetSearchForm = createAction(actionType.RESET_SEARCH_FORM);

  static reset = () => dispatch => {
    dispatch(HotelSearchActions.resetSearchForm);
    dispatch(HotelSearchActions.resetPage);
  };

  static resetCityOptions = createAction(actionType.RESET_CITY_OPTIONS);

  static loadCityOptions = search => (dispatch, getState) => {
    dispatch(loadCityOptionsRequest);
    const countryId = getState().hotelSearch.searchForm.country.value;
    return HotelSearchService.fetchCities({
      cityName: search.cityName,
      countryId: countryId,
      amount: search.amount || config.optionsAmount
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

  static resetCountryOptions = createAction(actionType.RESET_COUNTRY_OPTIONS);

  static loadCountryOptions = search => dispatch => {
    dispatch(loadCountryOptionsRequest);
    return HotelSearchService.fetchCountries({
      countryName: search.countryName,
      amount: search.amount || config.optionsAmount
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

  static loadRoomSizeOptions = () => dispatch => {
    dispatch(loadRoomSizeOptionsRequest);
    return HotelSearchService.fetchRoomSizes()
      .then(handleError)
      .then(result => result.json())
      .then(roomSizes => {
        const roomSizeOptions = OptionsService.getNumericOptionsFromArray(
          roomSizes
        );
        dispatch(loadRoomSizeOptionsSuccess(roomSizeOptions));
      })
      .catch(error => {
        dispatch(loadRoomSizeOptionsFailure(error));
      });
  };
}

export { HotelSearchActions };
