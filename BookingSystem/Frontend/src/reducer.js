import { combineReducers } from "redux";
import { hotelSearch } from "./hotelSearch";
import { reducer as formReducer } from "redux-form";

const rootReducer = combineReducers({ hotelSearch, form: formReducer });
export { rootReducer };
