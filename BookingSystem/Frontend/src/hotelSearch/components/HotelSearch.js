import React, { Component } from "react";
import PropTypes from "prop-types";
import HotelList from "./HotelList";
import SearchForm from "./SearchForm";

const HotelSearch = props => {
  const {
    startDate,
    endDate,
    roomSize,
    country,
    city,
    cityOptions,
    handleSubmit,
    handleReset,
    handleInputChange,
    handleStartDateChange,
    handleEndDateChange,
    handleCityOptionsChange,
    handleCountryChange,
    handleCityChange,
    hotels
  } = props;
  return (
    <div>
      <SearchForm
        startDate={startDate}
        endDate={endDate}
        roomSize={roomSize}
        country={country}
        city={city}
        cityOptions={cityOptions}
        handleSubmit={handleSubmit}
        handleReset={handleReset}
        handleInputChange={handleInputChange}
        handleStartDateChange={handleStartDateChange}
        handleEndDateChange={handleEndDateChange}
        handleCityOptionsChange={handleCityOptionsChange}
        handleCountryChange={handleCountryChange}
        handleCityChange={handleCityChange}
      />
      <HotelList hotels={hotels} />
    </div>
  );
};
HotelSearch.propTypes = {
  hotels: PropTypes.array,
  getHotels: PropTypes.func
};

export default HotelSearch;
