import React, { Component } from "react";
import HotelList from "../components/HotelList";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { HotelSearchActions } from "../actions";
import PropTypes from "prop-types";

class HotelSearch extends Component {
  componentDidMount() {}

  render() {
    const { hotels, getHotels } = this.props;
    return (
      <div>
        <HotelList hotels={hotels} />
        <button onClick={() => getHotels("query")}>Get hotels</button>
      </div>
    );
  }
}

HotelSearch.propTypes = {
  hotels: PropTypes.object,
  getHotels: PropTypes.func
};

const mapStateToProps = state => {
  const hotelsReducer = state.hotelSearchReducer;
  return {
    hotels: hotelsReducer.hotels,
    isFetching: hotelsReducer.isFetching,
    error: hotelsReducer.error
  };
};

const mapDispatchToProps = dispatch => {
  const bindedCreators = bindActionCreators(
    {
      getHotels: HotelSearchActions.FetchHotels
    },
    dispatch
  );
  return { ...bindedCreators };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HotelSearch);
