import React, { Component } from "react";
import { connect } from "react-redux";
import { Route, Switch } from "react-router-dom";
import { routePath } from "./shared/settings/routePath";
import Layout from "./shared/components/Layout";
import { HotelSearch, hotelSearch } from "./hotelSearch";

class HotelApp extends Component {
  render() {
    return (
      <Layout isLoggedIn={true} isAdmin={true}>
        <Switch>
          <Route exact path="/" component={HotelSearch} />
          <Route
            exact
            path={routePath.HOTEL_SEARCH_PAGE}
            component={hotelSearch}
          />
        </Switch>
      </Layout>
    );
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
