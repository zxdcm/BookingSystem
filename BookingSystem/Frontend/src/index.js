import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { ConnectedRouter } from "connected-react-router";
import { store, history } from "./store/store";
import { Route, Switch } from "react-router";
import "semantic-ui-css/semantic.min.css";
import "bootstrap/dist/css/bootstrap.min.css";
import HotelApp from "./HotelApp";

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <HotelApp history={history} />
    </ConnectedRouter>
  </Provider>,
  document.getElementById("root")
);

module.hot.accept();
