import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelSearchActions } from "../actions";
import HotelSearch from "../components/HotelSearch";
import { links } from "../../shared/settings/links";
import { QueryService, ImageService, OptionsService } from "../../shared/utils";
import { format } from "moment";

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
    roomSize: 1,
    city: "",
    country: ""
  };

  componentDidMount() {
    this.props.getHotels({});
    this.props.loadRoomSizeOptions();
  }

  getFormRequestData = () => ({
    startDate: this.state.startDate,
    endDate: this.state.endDate,
    roomSize: this.state.roomSize,
    cityId: this.state.city.cityId,
    countryId: this.state.country.countryId
  });

  handleSubmit = event => {
    event.preventDefault();
    const data = this.getFormRequestData();
    data.pageInfo = this.props.pageInfo;
    this.props.getHotels(data);
  };

  handleReset = event => {
    this.setState({
      startDate: new Date(),
      endDate: new Date(),
      roomSize: 1,
      city: "",
      country: ""
    });
    this.props.getHotels();
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
    const countryName = this.state.country.name;
    this.props.loadCityOptions({
      cityName: search,
      countryName: countryName
    });
  };

  handleRoomSizeChange = data => {
    this.setState({ roomSize: data.value });
  };

  handleCountryChange = data => {
    const country = { countryId: data.value, name: data.label };
    this.setState({ country: country });
  };

  handleCityChange = data => {
    const city = { cityId: data.value, name: data.label };
    this.setState({ city: city });
  };

  getHotelDetailsLink = hotelId => {
    const searchData = { ...this.state };
    return this.props.getHotelDetailsLink(hotelId, searchData);
  };

  getHotelImageLink = hotelId => {
    return this.props.getHotelImageLink(hotelId);
  };

  handleSetPage = page => {
    const data = this.getFormRequestData();
    data.page = page;
    data.pageSize = this.props.pageInfo.pageSize;
    this.props.getHotels(data);
  };

  render() {
    return (
      <HotelSearch
        startDate={this.state.startDate}
        endDate={this.state.endDate}
        city={this.state.city}
        country={this.state.country}
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
        getHotelImageLink={this.getHotelImageLink}
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
      loadRoomSizeOptions: HotelSearchActions.loadRoomSizeOptions
    },
    dispatch
  );
  return {
    ...bindedCreators,
    getHotelDetailsLink: (hotelId, data) => ({
      pathname: links.getHotel(hotelId),
      search: QueryService.hotelQueryFromData(data)
    }),
    getHotelImageLink: hotelId => {
      return ImageService.getHotelImageLink(hotelId);
    }
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HotelSearchContainer);
