import React from "react";
import { NavLink } from "react-router-dom";
import { routePath } from "../settings/routePath";

const Header = props => {
  const { isLoggedIn, isAdmin } = props;
  return (
    <div id="header">
      <div className="navbar navbar-light bg-light">
        <div className="navbar-brand">
          <NavLink to="/">Brand</NavLink>
        </div>
        <div className="nav">
          <div className="nav-item">
            <div className="nav-link">
              <NavLink to={routePath.HOTEL_SEARCH_PAGE} />
            </div>
          </div>
          <div className="nav-item">
            <div className="nav-link">Sign up</div>
          </div>
          <div className="nav-link">One More</div>
        </div>
      </div>
    </div>
  );
};
export default Header;
