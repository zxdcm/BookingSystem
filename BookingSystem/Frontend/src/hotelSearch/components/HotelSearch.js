import React, { Component, Fragment } from "react";
import PropTypes from "prop-types";
import HotelList from "./HotelList";
import SearchForm from "./SearchForm";

const HotelSearch = props => {
  const {
    startDate,
    endDate,
    country,
    city,
    roomSizeOptions,
    countryOptions,
    cityOptions,
    handleSubmit,
    handleReset,
    handleInputChange,
    handleStartDateChange,
    handleEndDateChange,
    handleCountryOptionsChange,
    handleCityOptionsChange,
    handleRoomSizeChange,
    handleCountryChange,
    handleCityChange,
    hotels,
    getHotelDetailsLink,
    getHotelImageLink,
    isLoading
  } = props;
  return (
    <div className="row">
      <div className="col-4">
        <SearchForm
          startDate={startDate}
          endDate={endDate}
          country={country}
          city={city}
          roomSizeOptions={roomSizeOptions}
          countryOptions={countryOptions}
          cityOptions={cityOptions}
          handleSubmit={handleSubmit}
          handleReset={handleReset}
          handleInputChange={handleInputChange}
          handleStartDateChange={handleStartDateChange}
          handleEndDateChange={handleEndDateChange}
          handleCountryOptionsChange={handleCountryOptionsChange}
          handleCityOptionsChange={handleCityOptionsChange}
          handleRoomSizeChange={handleRoomSizeChange}
          handleCountryChange={handleCountryChange}
          handleCityChange={handleCityChange}
        />
      </div>
      <div className="col d-flex justify-content-center align-items-center">
        {isLoading ? (
          <div>
            <div
              className="spinner-border"
              style={{ size: "lg", color: "secondary" }}
            />
          </div>
        ) : (
          <Fragment>
            <HotelList
              hotels={hotels}
              getHotelDetailsLink={getHotelDetailsLink}
              getHotelImageLink={getHotelImageLink}
            />
          </Fragment>
        )}
      </div>
    </div>
  );
};
HotelSearch.propTypes = {
  hotels: PropTypes.array,
  getHotels: PropTypes.func
};

export default HotelSearch;
