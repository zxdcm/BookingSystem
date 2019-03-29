import React, { Component } from "react";
import PropTypes from "prop-types";
import DatePicker from "react-datepicker";
import Select from "react-select";
import { dateFormat } from "../../shared/settings/dateFormat";
import "react-datepicker/dist/react-datepicker.css";

const SearchForm = props => {
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
    handleStartDateChange,
    handleEndDateChange,
    handleRoomSizeChange,
    handleCountryOptionsChange,
    handleCityOptionsChange,
    handleCountryChange,
    handleCityChange
  } = props;
  return (
    <div className="form">
      <div className="form-group">
        <div className="alignItemsRight">
          <button className="btn btn-danger resetBtn" onClick={handleReset}>
            Reset
          </button>
        </div>
        <label>Destination country</label>
        <Select
          classNamePrefix="custom-select"
          value={country}
          options={countryOptions}
          onInputChange={handleCountryOptionsChange}
          onChange={handleCountryChange}
          placeholder="Select country"
        />
      </div>
      <div className="form-group">
        <label>Destination city</label>
        <Select
          classNamePrefix="custom-select"
          options={cityOptions}
          value={city}
          onInputChange={handleCityOptionsChange}
          onChange={handleCityChange}
          placeholder="Select city"
        />
      </div>
      <div className="form-group">
        <label>Move in date</label>
        <DatePicker
          className="form-control"
          minDate={startDate}
          selected={startDate}
          onChange={handleStartDateChange}
          dateFormat={dateFormat.CALENDAR_DISPLAY_FORMAT}
        />
      </div>
      <div className="form-group">
        <label>Move out date</label>
        <DatePicker
          className="form-control"
          minDate={startDate}
          selected={endDate}
          onChange={handleEndDateChange}
          dateFormat={dateFormat.CALENDAR_DISPLAY_FORMAT}
        />
      </div>
      <div className="form-group">
        <label>Room size</label>
        <Select
          value={roomSize}
          options={roomSizeOptions}
          onChange={handleRoomSizeChange}
          placeholder="Select room size"
        />
      </div>
      <button className="findBtn" onClick={handleSubmit}>
        Find
      </button>
    </div>
  );
};

SearchForm.propTypes = {
  currentCountry: PropTypes.object,
  currentCity: PropTypes.object,
  onCountrySelect: PropTypes.func,
  onCitySelect: PropTypes.func,
  onSubmit: PropTypes.func,
  loadCities: PropTypes.func,
  handleSubmit: PropTypes.func,
  handleStartDateChange: PropTypes.func,
  handleEndDateChange: PropTypes.func,
  handleInputChange: PropTypes.func,
  handleCitySelect: PropTypes.func
};

export default SearchForm;
