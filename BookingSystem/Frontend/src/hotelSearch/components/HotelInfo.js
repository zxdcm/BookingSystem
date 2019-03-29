import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const HotelInfo = ({ hotel, hotelDetailsLink }) => (
  <div className="card">
    {hotel.imageUrl && <img className="card-img" src={hotel.imageUrl} />}
    <div className="card-body body outline">
      {hotel.name && <div className="card-title">{hotel.name}</div>}
      {hotel.address && <div className="card-text">{hotel.address}</div>}
      {hotel.countryName && (
        <div className="card-text">{hotel.countryName}</div>
      )}
      {hotel.cityName && <div className="card-text">{hotel.cityName}</div>}
      <Link to={hotelDetailsLink}>Details</Link>
    </div>
  </div>
);

HotelInfo.propTypes = {
  hotel: PropTypes.object
};

export default HotelInfo;
