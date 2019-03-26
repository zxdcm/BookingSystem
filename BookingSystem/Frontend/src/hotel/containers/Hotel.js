import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelActions } from "../actions";
import Hotel from "../components/Hotel";

const mapStateToProps = state => {
  const hotel = state.hotel;
  return {
    hotel: hotel.hotel,
    rooms: hotel.rooms,
    isFetching: hotel.isFetching,
    error: hotel.error
  };
};

class HotelContainer extends Component {
  render() {
    return <Hotel hotel={this.props.hotel} rooms={this.props.rooms} />;
  }
}

const mapDispatchToProps = dispatch => {
  const bindedCreators = bindActionCreators({}, dispatch);
  return {
    ...bindedCreators
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HotelContainer);
