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
      <HotelList hotels={hotels} />
    </div>
  );
};
HotelSearch.propTypes = {
  hotels: PropTypes.array,
  getHotels: PropTypes.func
};

export default HotelSearch;
