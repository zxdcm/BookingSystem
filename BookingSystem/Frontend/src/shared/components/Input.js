import React from "react";
import PropTypes from "prop-types";

const Input = ({
  input,
  label,
  type,
  placeholder,
  meta: { error = null, touched = null, warning = null } = null
}) => {
  return (
    <div>
      <h3>{label}</h3>
      <input {...input} type={type} placeholder={placeholder} />
      {touched &&
        ((error && <span>{error}</span>) ||
          (warning && <span>{warning}</span>))}
    </div>
  );
};

Input.propTypes = {
  label: PropTypes.string,
  input: PropTypes.element,
  type: PropTypes.string,
  placeholder: PropTypes.string,
  meta: PropTypes.object
};

export default Input;
