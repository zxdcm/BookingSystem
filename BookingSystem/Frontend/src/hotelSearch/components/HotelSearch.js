import React, { Component } from "react";
import PropTypes from "prop-types";
import HotelList from "./HotelList";
import SearchForm from "./SearchForm";
import { Row, Col, Spinner } from "reactstrap";

const HotelSearch = props => {
  const {
    startDate,
    endDate,
    roomSize,
    country,
    city,
    countryOptions,
    cityOptions,
    handleSubmit,
    handleReset,
    handleInputChange,
    handleStartDateChange,
    handleEndDateChange,
    handleCountryOptionsChange,
    handleCityOptionsChange,
    handleCountryChange,
    handleCityChange,
    hotels,
    getHotelDetailsLink,
    getHotelImageLink,
    isLoading
  } = props;
  return (
    <Row md="8">
      <Col md="4">
        <SearchForm
          startDate={startDate}
          endDate={endDate}
          roomSize={roomSize}
          country={country}
          city={city}
          countryOptions={countryOptions}
          cityOptions={cityOptions}
          handleSubmit={handleSubmit}
          handleReset={handleReset}
          handleInputChange={handleInputChange}
          handleStartDateChange={handleStartDateChange}
          handleEndDateChange={handleEndDateChange}
          handleCountryOptionsChange={handleCountryOptionsChange}
          handleCityOptionsChange={handleCityOptionsChange}
          handleCountryChange={handleCountryChange}
          handleCityChange={handleCityChange}
        />
      </Col>
      <Col className="d-flex justify-content-center align-items-center">
        {isLoading ? (
          <div>
            <Spinner size="lg" color="secondary" />
          </div>
        ) : (
          <HotelList
            hotels={hotels}
            getHotelDetailsLink={getHotelDetailsLink}
            getHotelImageLink={getHotelImageLink}
          />
        )}
      </Col>
    </Row>
  );
};
HotelSearch.propTypes = {
  hotels: PropTypes.array,
  getHotels: PropTypes.func
};

export default HotelSearch;
