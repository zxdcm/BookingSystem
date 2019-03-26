import React from "react";
import PropTypes from "prop-types";
import {
  Button,
  Card,
  CardBody,
  CardTitle,
  CardText,
  CardImg
} from "reactstrap";
import { Link } from "react-router-dom";

const HotelInfo = ({ hotel, hotelDetailsLink, hotelImageLink }) => (
  <Card>
    {hotelImageLink && <CardImg src={hotelImageLink} />}
    <CardBody body outline color="primary">
      {hotel.name && <CardTitle>{hotel.name}</CardTitle>}
      {hotel.address && <CardText>{hotel.address}</CardText>}
      {hotel.countryName && <CardText>{hotel.countryName}</CardText>}
      {hotel.cityName && <CardText>{hotel.cityName}</CardText>}
      <Link to={hotelDetailsLink}>Details</Link>
    </CardBody>
  </Card>
);

HotelInfo.propTypes = {
  hotel: PropTypes.object
};

export default HotelInfo;
