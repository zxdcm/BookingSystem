import React, { Fragment } from "react";
import Header from "./Header";
import Footer from "./Footer";
const Layout = props => {
  const { isLoggedIn, isAdmin, children } = props;
  return (
    <div className="container">
      <div className="row">
        <Header isLoggedIn={isLoggedIn} isAdmin={isAdmin} />
      </div>
      {children}
      <div className="row">
        <Footer />
      </div>
    </div>
  );
};

export default Layout;
