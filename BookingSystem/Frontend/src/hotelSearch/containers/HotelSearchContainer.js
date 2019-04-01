import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelSearchActions } from "../actions";
import HotelSearch from "../components/HotelSearch";
import { links } from "../../shared/settings/links";
import { QueryService } from "../../shared/utils";

const mapStateToProps = state => {
  const hotels = state.hotelSearch.hotels;
  const form = state.hotelSearch.searchForm;
  return {
    startDate: form.startDate,
    endDate: form.endDate,
    roomSize: form.roomSize,
    city: form.city,
    country: form.country,
    hotels: hotels.hotels,
    pageInfo: hotels.pageInfo,
    isFetching: hotels.isFetching,
    error: hotels.error,
    roomSizeOptions: form.roomSizeOptions,
    countryOptions: form.countryOptions,
    cityOptions: form.cityOptions,
    search: state.router.location.pathname,
    isLoading: hotels.isFetching
  };
};

class HotelSearchContainer extends Component {
  componentDidMount() {
    this.props.getHotels();
    this.props.loadRoomSizeOptions();
  }

  handleSubmit = event => {
    event.preventDefault();
    this.props.resetPage();
    this.props.getHotels();
  };

  handleReset = event => {
    this.props.reset();
    this.props.loadRoomSizeOptions();
    this.props.getHotels();
  };

  handleStartDateChange = date => {
    this.props.setStartDate(date);
  };

  handleEndDateChange = date => {
    this.props.setEndDate(date);
  };

  handleCountryOptionsChange = search => {
    if (search === "") return;
    this.props.loadCountryOptions({ countryName: search });
  };

  handleCityOptionsChange = search => {
    if (search === "") return;
    this.props.loadCityOptions({
      cityName: search
    });
  };

  handleRoomSizeChange = data => {
    this.props.setRoomSize(data);
  };

  handleCountryChange = data => {
    this.props.setCountry(data);
  };

  handleCityChange = data => {
    this.props.setCity(data);
  };

  getHotelDetailsLink = hotelId => {
    const searchData = {
      startDate: this.props.startDate,
      endDate: this.props.endDate,
      roomSize: this.props.roomSize.value,
      cityId: this.props.city.value,
      countryId: this.props.country.value
    };
    return this.props.getHotelDetailsLink(hotelId, searchData);
  };

  handleSetPage = page => {
    this.props.setPage(page);
    this.props.getHotels();
  };

  render() {
    return (
      <HotelSearch
        startDate={this.props.startDate}
        endDate={this.props.endDate}
        city={this.props.city}
        country={this.props.country}
        roomSize={this.props.roomSize}
        roomSizeOptions={this.props.roomSizeOptions}
        countryOptions={this.props.countryOptions}
        cityOptions={this.props.cityOptions}
        handleSubmit={this.handleSubmit}
        handleReset={this.handleReset}
        handleStartDateChange={this.handleStartDateChange}
        handleEndDateChange={this.handleEndDateChange}
        handleCountryOptionsChange={this.handleCountryOptionsChange}
        handleCityOptionsChange={this.handleCityOptionsChange}
        handleRoomSizeChange={this.handleRoomSizeChange}
        handleCountryChange={this.handleCountryChange}
        handleCityChange={this.handleCityChange}
        handleSetPage={this.handleSetPage}
        hotels={this.props.hotels}
        pageInfo={this.props.pageInfo}
        getHotelDetailsLink={this.getHotelDetailsLink}
        isLoading={this.props.isLoading}
      />
    );
  }
}

const mapDispatchToProps = dispatch => {
  const bindedCreators = bindActionCreators(
    {
      getHotels: HotelSearchActions.fetchHotels,
      setCity: HotelSearchActions.setCity,
      setCountry: HotelSearchActions.setCountry,
      setStartDate: HotelSearchActions.setStartDate,
      setEndDate: HotelSearchActions.setEndDate,
      setRoomSize: HotelSearchActions.setRoomSize,
      setPage: HotelSearchActions.setPage,
      loadCountryOptions: HotelSearchActions.loadCountryOptions,
      loadCityOptions: HotelSearchActions.loadCityOptions,
      loadRoomSizeOptions: HotelSearchActions.loadRoomSizeOptions,
      reset: HotelSearchActions.reset,
      resetPage: HotelSearchActions.resetPage,
      resetCityOptions: HotelSearchActions.resetCityOptions,
      resetCountryOptions: HotelSearchActions.resetCountryOptions
    },
    dispatch
  );
  return {
    ...bindedCreators,
    getHotelDetailsLink: (hotelId, data) => ({
      pathname: links.getHotel(hotelId),
      search: QueryService.hotelQueryFromData(data)
    })
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HotelSearchContainer);
