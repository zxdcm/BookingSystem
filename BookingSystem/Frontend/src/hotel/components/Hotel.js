import React from "react";
import PropTypes from "prop-types";
import HotelHeader from "./HotelHeader";
import RoomList from "./RoomList";

const Hotel = props => {
  const { hotel, rooms } = props;
  return (
    <div>
      <HotelHeader hotel={hotel} />
      <RoomList rooms={rooms} />
    </div>
  );
};

Hotel.propTypes = {
  hotel: PropTypes.object,
  rooms: PropTypes.array
};

export default Hotel;
