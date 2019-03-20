import React from "react";
import PropTypes from "prop-types";
import HotelInfo from "./HotelInfo";

const HotelList = ({ hotels }) => (
  <div>
    {hotels &&
      hotels.map(hotel => (
        <div key={hotel.hotelId}>
          <HotelInfo hotel={hotel} />
        </div>
      ))}
  </div>
);

HotelList.propTypes = {
  hotels: PropTypes.array
};

export default HotelList;
