import React from "react";
import PropTypes from "prop-types";

const HotelHeader = props => {
  const { hotel } = props;
  return (
    hotel && (
      <div>
        {hotel.name && <h2>{hotel.name}</h2>}
        {hotel.address && <li>{hotel.address}</li>}
        {hotel.countryName && <li>{hotel.countryName}</li>}
        {hotel.cityName && <li>{hotel.cityName}</li>}
      </div>
    )
  );
};

HotelHeader.propTypes = {
  hotel: PropTypes.array
};

export default HotelHeader;
