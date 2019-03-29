import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const HotelInfo = ({ hotel, hotelDetailsLink }) => (
  <div className="card">
    <div className="card-body body outline">
      {hotel.imageUrl && <img className="card-img" src={hotel.imageUrl} />}
      {hotel.name && <h5 className="card-title text-center">{hotel.name}</h5>}
      {hotel.address && <div className="card-text">{hotel.address}</div>}
      {hotel.countryName && (
        <div className="card-text">{hotel.countryName}</div>
      )}
      {hotel.cityName && <div className="card-text">{hotel.cityName}</div>}
      <div className="alignItemsRight">
        <Link className="btn btn-outline-secondary" to={hotelDetailsLink}>
          Details
        </Link>
      </div>
    </div>
  </div>
);

HotelInfo.propTypes = {
  hotel: PropTypes.object
};

export default HotelInfo;
