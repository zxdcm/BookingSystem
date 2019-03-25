import React, { Component } from "react";
import PropTypes from "prop-types";
import DatePicker from "react-datepicker";
import Select from "react-select";

const SearchForm = props => {
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
    handleCityChange
  } = props;
  return (
    <div>
      <form onSubmit={handleSubmit}>
        <DatePicker selected={startDate} onChange={handleStartDateChange} />
        <DatePicker selected={endDate} onChange={handleEndDateChange} />
        <label>Room size</label>
        <input
          name="roomSize"
          type="number"
          value={roomSize}
          onChange={handleInputChange}
        />
        <label>Country</label>
        <Select
          options={countryOptions}
          onInputChange={handleCountryOptionsChange}
          onChange={handleCountryChange}
        />
        <label>City</label>
        <Select
          options={cityOptions}
          onInputChange={handleCityOptionsChange}
          onChange={handleCityChange}
        />
        <div>
          <button type="submit">Find</button>
          <button type="button" onClick={handleReset}>
            Reset
          </button>
        </div>
      </form>
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
