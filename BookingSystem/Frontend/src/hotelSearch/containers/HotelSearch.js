import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelSearchActions, hotelSearchActionType } from "../actions";
import HotelSearch from "../components/HotelSearch";
import SearchForm from "../components/SearchForm";

const mapStateToProps = state => {
  const hotels = state.hotelSearch.hotels;
  const form = state.hotelSearch.searchForm;
  return {
    hotels: hotels.hotels,
    isFetching: hotels.isFetching,
    error: hotels.error,
    currentCity: form.currentCity,
    currentCountry: form.currentCountry,
    cityOptions: form.cityOptions
  };
};

class HotelSearchContainer extends Component {
  state = {
    startDate: new Date(),
    endDate: new Date(),
    roomSize: 0,
    cityId: null,
    countryId: null
  };

  handleSubmit = event => {
    event.preventDefault();
    const data = { ...this.state };
    this.props.onSubmit(data);
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

  handleCityOptionsChange = search => {
    if (search == "") return;
    this.props.loadCityOptions(search);
  };

  handleCountryChange = event => {
    this.props.setCountry(event.target.value);
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
        cityOptions={this.props.cityOptions}
        handleSubmit={this.handleSubmit}
        handleInputChange={this.handleInputChange}
        handleStartDateChange={this.handleStartDateChange}
        handleEndDateChange={this.handleEndDateChange}
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
      onSubmit: HotelSearchActions.fetchHotels,
      setCity: HotelSearchActions.setCity,
      setCountry: HotelSearchActions.setCountry,
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
