import React, { Component } from "react";
import PropTypes from "prop-types";
import DatePicker from "react-datepicker";
import Select from "react-select";
import { Form, FormGroup, Label, Input, Button, ButtonGroup } from "reactstrap";
import { dateFormat } from "../../shared/settings/dateFormat";
import "react-datepicker/dist/react-datepicker.css";

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
    <Form onSubmit={handleSubmit}>
      <FormGroup>
        <Label>Start date</Label>
        <DatePicker
          selected={startDate}
          onChange={handleStartDateChange}
          dateFormat={dateFormat.CALENDAR_DISPLAY_FORMAT}
        />
      </FormGroup>
      <FormGroup>
        <Label>End date</Label>
        <DatePicker
          selected={endDate}
          onChange={handleEndDateChange}
          dateFormat={dateFormat.CALENDAR_DISPLAY_FORMAT}
        />
      </FormGroup>
      <FormGroup>
        <Label>Room size</Label>
        <Input
          name="roomSize"
          type="number"
          value={roomSize}
          onChange={handleInputChange}
        />
      </FormGroup>
      <FormGroup>
        <Label>Country</Label>
        <Select
          options={countryOptions}
          onInputChange={handleCountryOptionsChange}
          onChange={handleCountryChange}
        />
      </FormGroup>
      <FormGroup>
        <Label>City</Label>
        <Select
          options={cityOptions}
          onInputChange={handleCityOptionsChange}
          onChange={handleCityChange}
        />
      </FormGroup>
      <ButtonGroup>
        <Button type="submit">Find</Button>
        <Button type="button" onClick={handleReset}>
          Reset
        </Button>
      </ButtonGroup>
    </Form>
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
