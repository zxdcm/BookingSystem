import React, { Component } from "react";
import PropTypes from "prop-types";
import DatePicker from "react-datepicker";
import Select from "react-select";
import { Dropdown } from "semantic-ui-react";

const SearchForm = props => {
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
        <label>Cities</label>
        <Select
          options={cityOptions}
          onInputChange={handleCityOptionsChange}
          onChange={handleCityChange}
        />
        <Dropdown
          options={cityOptions}
          search
          selection
          value={city}
          onChange={handleCityChange}
          onSearchChange={(event, data) => {
            handleCityOptionsChange(data.searchQuery);
          }}
        />
        <input name="city" onChange={handleCityChange} value={city} />
        <label>Countries</label>
        <input name="country" onChange={handleCountryChange} value={country} />
        <div>
          <button type="submit">Find</button>
          <button onClick={handleReset}>Reset</button>
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
