import React, { Component } from "react";
import { connect } from "react-redux";
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { routePath } from "./shared/settings/routePath";
import Layout from "./shared/components/Layout";
import { HotelSearch } from "./hotelSearch";

class HotelApp extends Component {
  render() {
    return <HotelSearch />;
  }
}

const mapStateToProps = state => {
  return {
    state: state
  };
};

export default connect(
  mapStateToProps,
  null
)(HotelApp);
