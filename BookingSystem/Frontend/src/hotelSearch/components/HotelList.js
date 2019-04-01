import React from "react";
import PropTypes from "prop-types";
import HotelInfo from "./HotelInfo";

const HotelList = ({ hotels, getHotelDetailsLink }) => (
  <div>
    {hotels &&
      hotels.map(hotel => (
        <div key={hotel.hotelId}>
          <HotelInfo
            hotel={hotel}
            hotelDetailsLink={getHotelDetailsLink(hotel.hotelId)}
          />
        </div>
      ))}
  </div>
);

HotelList.propTypes = {
  hotels: PropTypes.array
};

export default HotelList;
