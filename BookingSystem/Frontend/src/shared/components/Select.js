import React from "react";

const Select = props => (
  <Select
    {...props}
    value={props.input.value}
    onChange={value => props.input.onChange(value)}
    onBlur={() => props.input.onBlur(props.input.value)}
    options={props.options}
  />
);

export default Select;
