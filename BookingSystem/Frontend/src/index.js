import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "connected-react-router";
import { store, history } from "./store/store";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/";
import "react-datepicker/dist/react-datepicker.css";
import "react-datepicker/dist/react-datepicker-cssmodules.css";
// import "./styles/main";
import HotelApp from "./HotelApp";

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <HotelApp />
    </ConnectedRouter>
  </Provider>,
  document.getElementById("root")
);

module.hot.accept();
