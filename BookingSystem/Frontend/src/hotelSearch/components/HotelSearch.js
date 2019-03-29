import React, { Component, Fragment } from "react";
import PropTypes from "prop-types";
import HotelList from "./HotelList";
import SearchForm from "./SearchForm";
import { Pagination } from "../../shared/components/Pagination";

const HotelSearch = props => {
  const {
    startDate,
    endDate,
    country,
    city,
    roomSize,
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
    handleSetPage,
    hotels,
    pageInfo,
    getHotelDetailsLink,
    isLoading
  } = props;
  return (
    <div className="row">
      <div className="col-4">
        <div className="filter-box">
          <SearchForm
            startDate={startDate}
            endDate={endDate}
            country={country}
            city={city}
            roomSize={roomSize}
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
            handleSetPage={handleSetPage}
          />
        </div>
      </div>
      <div className="col align-items-center-container ">
        {isLoading ? (
          <div>
            <div
              className="spinner-border text-light"
              style={{ size: "lg", color: "light" }}
            />
          </div>
        ) : (
          <Fragment>
            {hotels.length ? (
              <div className="col-12 search-result-box">
                <HotelList
                  hotels={hotels}
                  getHotelDetailsLink={getHotelDetailsLink}
                />
                <Pagination pageInfo={pageInfo} setPage={handleSetPage} />
              </div>
            ) : (
              <div className="search-result-box alert alert-info" role="alert">
                <h4>No hotels match : ( </h4>
              </div>
            )}
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
