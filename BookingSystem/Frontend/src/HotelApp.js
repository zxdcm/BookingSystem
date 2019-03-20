import React, { Component } from "react";
import { connect } from "react-redux";
import { HotelSearch } from "./hotelSearch";

class HotelApp extends Component {
  render() {
    return <HotelSearch />;
  }
}

const mapStateToProps = state => {
  return {
    state: state
  };
};

export default connect(
  mapStateToProps,
  null
)(HotelApp);
