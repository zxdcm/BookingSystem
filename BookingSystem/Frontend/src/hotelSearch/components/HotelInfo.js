import React from "react";
import PropTypes from "prop-types";

const HotelInfo = ({ hotel }) => (
  <div>
    {hotel.name && <h2>{hotel.name}</h2>}
    {hotel.address && <li>{hotel.address}</li>}
    {hotel.countryName && <li>{hotel.countryName}</li>}
    {hotel.cityName && <li>{hotel.cityName}</li>}
  </div>
);

HotelInfo.propTypes = {
  hotel: PropTypes.object
};

export default HotelInfo;
