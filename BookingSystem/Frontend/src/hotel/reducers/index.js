import { combineReducers } from "redux";
import firstReducer from "./firstReducer";
import func from "./secondReducer";

export default combineReducers({ firstReducer, func });
