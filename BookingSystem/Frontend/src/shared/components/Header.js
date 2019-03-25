import React from "react";
import { NavLink as RouterNavLink } from "react-router-dom";
import { routePath } from "../settings/routePath";
import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";

const Header = props => {
  const { isLoggedIn, isAdmin } = props;
  return (
    <div>
      <Navbar>
        <NavbarBrand tag={RouterNavLink} to="/">
          Brand
        </NavbarBrand>
        <Nav>
          <NavItem>
            <NavLink tag={RouterNavLink} to={routePath.HOTEL_SEARCH_PAGE}>
              Search
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={RouterNavLink} to="/another">
              Sign up
            </NavLink>
          </NavItem>
          <NavLink tag={RouterNavLink} to="/onemore">
            One More
          </NavLink>
        </Nav>
      </Navbar>
    </div>
  );
};
export default Header;
