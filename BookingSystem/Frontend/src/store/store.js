import thunk from "redux-thunk";
import logger from "redux-logger";
import { createStore, applyMiddleware } from "redux";
import { createBrowserHistory } from "history";
import { rootReducer } from "../reducer";
import { composeWithDevTools } from "redux-devtools-extension";
import { routerMiddleware, connectRouter } from "connected-react-router";

const history = createBrowserHistory();

const configureStore = createStore(
  rootReducer(history),
  composeWithDevTools(applyMiddleware(thunk, routerMiddleware(history)))
);

export { configureStore as store, history };
