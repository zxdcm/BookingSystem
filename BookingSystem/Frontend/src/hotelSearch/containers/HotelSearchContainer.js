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
  state = {
    startDate: new Date(),
    endDate: new Date(),
    roomSize: { label: 1, value: 1 },
    city: "",
    country: ""
  };

  componentDidMount() {
    const data = this.getFormRequestData();
    this.props.getHotels(data);
    this.props.loadRoomSizeOptions();
  }

  getFormRequestData = () => ({
    startDate: this.state.startDate,
    endDate: this.state.endDate,
    roomSize: this.state.roomSize.value,
    cityId: this.state.city.value,
    countryId: this.state.country.value,
    page: this.props.pageInfo.page,
    pageSize: this.props.pageInfo.pageSize
  });

  handleSubmit = event => {
    event.preventDefault();
    const data = this.getFormRequestData();
    this.props.getHotels(data);
  };

  handleReset = event => {
    this.setState({
      startDate: new Date(),
      endDate: new Date(),
      roomSize: { label: 1, value: 1 },
      city: "",
      country: ""
    });
    this.props.resetCountryOptions();
    this.props.resetCityOptions();
    const data = this.getFormRequestData();
    this.props.getHotels(data);
  };

  handleStartDateChange = date => {
    this.setState({
      startDate: date,
      endDate: date
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
    const countryId = this.state.country.value;
    this.props.loadCityOptions({
      cityName: search,
      countryId: countryId
    });
  };

  handleRoomSizeChange = data => {
    this.setState({ roomSize: data });
  };

  handleCountryChange = data => {
    this.setState({ country: data, city: { value: "", label: "" } });
    this.props.resetCityOptions();
  };

  handleCityChange = data => {
    this.setState({ city: data });
  };

  getHotelDetailsLink = hotelId => {
    const searchData = { ...this.state };
    return this.props.getHotelDetailsLink(hotelId, searchData);
  };

  handleSetPage = page => {
    const data = this.getFormRequestData();
    data.page = page;
    this.props.getHotels(data);
  };

  render() {
    return (
      <HotelSearch
        startDate={this.state.startDate}
        endDate={this.state.endDate}
        city={this.state.city}
        country={this.state.country}
        roomSize={this.state.roomSize}
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
      loadCountryOptions: HotelSearchActions.loadCountryOptions,
      loadCityOptions: HotelSearchActions.loadCityOptions,
      loadRoomSizeOptions: HotelSearchActions.loadRoomSizeOptions,
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
