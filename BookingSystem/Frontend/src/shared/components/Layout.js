import React from "react";
import Header from "./Header";
import Footer from "./Footer";
const Layout = props => {
  const { isLoggedIn, isAdmin, children } = props;
  return (
    <div id="booking" className="container-fluid">
      <div className="row">
        <Header isLoggedIn={isLoggedIn} isAdmin={isAdmin} />
      </div>
      <div className="container">{children}</div>
      <div className="row">
        <Footer />
      </div>
    </div>
  );
};

export default Layout;
