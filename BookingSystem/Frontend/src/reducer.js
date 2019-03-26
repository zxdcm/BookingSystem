import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";
import { connectRouter } from "connected-react-router";
import { hotelSearch } from "./hotelSearch";
import { hotel } from "./hotel/";

const rootReducer = history =>
  combineReducers({
    router: connectRouter(history),
    form: formReducer,
    hotelSearch,
    hotel
  });
export { rootReducer };
