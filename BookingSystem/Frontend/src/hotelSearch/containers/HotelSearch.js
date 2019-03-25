import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelSearchActions, hotelSearchActionType } from "../actions";
import HotelSearch from "../components/HotelSearch";

const mapStateToProps = state => {
  const hotels = state.hotelSearch.hotels;
  const form = state.hotelSearch.searchForm;
  return {
    hotels: hotels.hotels,
    isFetching: hotels.isFetching,
    error: hotels.error,
    currentCity: form.currentCity,
    currentCountry: form.currentCountry,
    countryOptions: form.countryOptions,
    cityOptions: form.cityOptions,
    search: state.router.location.pathname
  };
};

class HotelSearchContainer extends Component {
  state = {
    startDate: new Date(),
    endDate: new Date(),
    roomSize: 0
  };

  componentDidMount() {
    this.props.getHotels({});
  }

  handleSubmit = event => {
    event.preventDefault();
    const data = {
      ...this.state,
      cityId: this.props.currentCity.cityId,
      countryId: this.props.currentCountry.countryId
    };
    this.props.getHotels(data);
  };

  handleReset = event => {
    this.props.getHotels({});
  };

  handleInputChange = event => {
    const target = event.target;
    this.setState({
      [target.name]: target.value
    });
  };

  handleStartDateChange = date => {
    this.setState({
      startDate: date
    });
  };

  handleEndDateChange = date => {
    this.setState({
      endDate: date
    });
  };

  handleCountryOptionsChange = search => {
    if (search === "") return;
    this.props.loadCountryOptions({ countryName: search });
  };

  handleCityOptionsChange = search => {
    if (search === "") return;
    const countryName = this.props.currentCountry.name;
    this.props.loadCityOptions({
      cityName: search,
      countryName: countryName
    });
  };

  handleCountryChange = data => {
    this.props.setCountry({ countryId: data.value, name: data.label });
  };

  handleCityChange = data => {
    this.props.setCity({ cityId: data.value, name: data.label });
  };

  render() {
    return (
      <HotelSearch
        startDate={this.state.startDate}
        endDate={this.state.endDate}
        roomSize={this.state.roomSize}
        city={this.props.currentCity}
        country={this.props.currentCountry}
        countryOptions={this.props.countryOptions}
        cityOptions={this.props.cityOptions}
        handleSubmit={this.handleSubmit}
        handleReset={this.handleReset}
        handleInputChange={this.handleInputChange}
        handleStartDateChange={this.handleStartDateChange}
        handleEndDateChange={this.handleEndDateChange}
        handleCountryOptionsChange={this.handleCountryOptionsChange}
        handleCityOptionsChange={this.handleCityOptionsChange}
        handleCountryChange={this.handleCountryChange}
        handleCityChange={this.handleCityChange}
        hotels={this.props.hotels}
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
      loadCountryOptions: HotelSearchActions.loadCountryOptions,
      loadCityOptions: HotelSearchActions.loadCityOptions
    },
    dispatch
  );
  return {
    ...bindedCreators
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HotelSearchContainer);
