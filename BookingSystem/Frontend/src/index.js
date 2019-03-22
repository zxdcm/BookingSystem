import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { store } from "./store/Store";
import HotelApp from "./HotelApp";
import "semantic-ui-css/semantic.min.css";

const rootElement = document.getElementById("root");
ReactDOM.render(
  <Provider store={store}>
    <HotelApp />
  </Provider>,
  rootElement
);

module.hot.accept();
