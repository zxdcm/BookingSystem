import React from "react";
import PropTypes from "prop-types";
import HotelInfo from "./HotelInfo";

const HotelList = ({ hotels, getHotelDetailsLink, getHotelImageLink }) => (
  <div>
    {hotels &&
      hotels.map(hotel => (
        <div key={hotel.hotelId}>
          <HotelInfo
            hotel={hotel}
            hotelDetailsLink={getHotelDetailsLink(hotel.hotelId)}
            hotelImageLink={getHotelImageLink(hotel.hotelId) || null}
          />
        </div>
      ))}
  </div>
);

HotelList.propTypes = {
  hotels: PropTypes.array
};

export default HotelList;
