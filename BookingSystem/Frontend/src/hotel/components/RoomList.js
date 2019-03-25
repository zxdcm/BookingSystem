import React from "react";
import PropTypes from "prop-types";
import RoomInfo from "./RoomInfo";

const RoomList = props => {
  const { rooms } = props;
  return (
    <div>
      {rooms &&
        rooms.map(room => (
          <div key={room.roomId}>
            <RoomInfo room={room} />
          </div>
        ))}
    </div>
  );
};

RoomList.propTypes = {
  rooms: PropTypes.array
};

export default RoomList;
