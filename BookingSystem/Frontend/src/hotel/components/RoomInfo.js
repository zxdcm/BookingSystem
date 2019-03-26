import React from "react";
import PropTypes from "prop-types";

const RoomInfo = props => {
  {
    const { room } = props;
    return (
      <div>
        {room.name && <h2>{room.name}</h2>}
        {room.price && <li>{room.price}</li>}
        {room.quantity && <li>{room.quantity}</li>}
      </div>
    );
  }
};

RoomInfo.propTypes = {
  room: PropTypes.object
};

export default RoomInfo;
