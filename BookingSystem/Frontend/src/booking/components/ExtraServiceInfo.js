import React, { Component } from "react";
import PropTypes from "prop-types";

class ExtraServiceInfo extends Component {
  render() {
    const { extraService } = this.props;
    return (
      <div>
        {extraService.name && <h2>{extraService.name}</h2>}
        {extraService.price && <li>{extraService.price}</li>}
      </div>
    );
  }
}

ExtraServiceInfo.propTypes = {
  extraService: PropTypes.object
};

export default ExtraServiceInfo;
