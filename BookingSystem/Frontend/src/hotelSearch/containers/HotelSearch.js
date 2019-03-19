import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelSearchActions } from "../actions";
import HotelSearch from "../components/HotelSearch";

const mapStateToProps = state => {
  const hotelSearch = state.hotelSearch;
  return {
    hotels: hotelSearch.hotels,
    isFetching: hotelSearch.isFetching,
    error: hotelSearch.error
  };
};

const mapDispatchToProps = dispatch => {
  const bindedCreators = bindActionCreators(
    {
      getHotels: HotelSearchActions.fetchHotels
    },
    dispatch
  );
  return { ...bindedCreators };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HotelSearch);
