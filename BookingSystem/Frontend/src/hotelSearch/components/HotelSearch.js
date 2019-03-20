import React, { Component } from "react";
import PropTypes from "prop-types";
import HotelList from "./HotelList";

class HotelSearch extends Component {
  render() {
    const { hotels, getHotels } = this.props;
    return (
      <div>
        <HotelList hotels={hotels} />
        <button onClick={() => getHotels("query")}>Get hotels</button>
      </div>
    );
  }
}

HotelSearch.propTypes = {
  hotels: PropTypes.array,
  getHotels: PropTypes.func
};

export default HotelSearch;
