import { combineReducers } from "redux";
import { hotelSearchReducer } from "./hotelSearch";

const rootReducer = combineReducers({ hotelSearchReducer });
export { rootReducer };
