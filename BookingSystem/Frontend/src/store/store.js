import thunk from "redux-thunk";
import logger from "redux-logger";
import { createStore, applyMiddleware, compose } from "redux";
import { rootReducer } from "../reducer";
import { composeWithDevTools } from "redux-devtools-extension";

const configureStore = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(thunk))
);

export { configureStore as store };
