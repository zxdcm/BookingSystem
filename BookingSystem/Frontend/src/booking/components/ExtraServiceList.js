import React, { Component } from "react";
import PropTypes from "prop-types";
import ExtraServiceInfo from "./ExtraServiceInfo";

class ExtraServiceList extends Component {
  render() {
    const { extraServices } = this.props;
    return (
      <div>
        {extraServices &&
          extraServices.map(extraService => (
            <div key={extraService.hotelId}>
              <ExtraServiceInfo extraService={extraService} />
            </div>
          ))}
      </div>
    );
  }
}

ExtraServiceList.propTypes = {
  extraServices: PropTypes.array
};

export default ExtraServiceList;
