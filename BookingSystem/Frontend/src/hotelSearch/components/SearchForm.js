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
    <div className="form" onSubmit={handleSubmit}>
      <div className="form-group">
        <label>Country</label>
        <Select
          options={countryOptions}
          onInputChange={handleCountryOptionsChange}
          onChange={handleCountryChange}
          placeholder="Select country"
        />
      </div>
      <div className="form-group">
        <label>City</label>
        <Select
          options={cityOptions}
          onInputChange={handleCityOptionsChange}
          onChange={handleCityChange}
          placeholder="Select city"
        />
      </div>
      <div className="form-group">
        <label>Room size</label>
        <Select
          options={roomSizeOptions}
          onChange={handleRoomSizeChange}
          placeholder="Select room size"
        />
      </div>
      <div className="form-group">
        <label>Start date</label>
        <DatePicker
          minDate={startDate}
          selected={startDate}
          onChange={handleStartDateChange}
          dateFormat={dateFormat.CALENDAR_DISPLAY_FORMAT}
        />
      </div>
      <div className="form-group">
        <label>End date</label>
        <DatePicker
          minDate={startDate}
          selected={endDate}
          onChange={handleEndDateChange}
          dateFormat={dateFormat.CALENDAR_DISPLAY_FORMAT}
        />
      </div>

      <div className="btn-group">
        <button className="btn btn-primary" type="submit">
          Find
        </button>
        <button
          className="btn btn-secondary"
          type="button"
          onClick={handleReset}
        >
          Reset
        </button>
      </div>
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
