import React, { Component } from "react";
import PropTypes from "prop-types";
import { HotelSearch } from "./hotelSearch";
import { connect } from "react-redux";

class HotelApp extends Component {
  render() {
    return <HotelSearch />;
  }
}

HotelApp.PropTypes = {};

const mapStateToProps = state => {
  return {
    state: state
  };
};

export default connect(
  mapStateToProps,
  null
)(HotelApp);
