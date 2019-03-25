import React, { Fragment } from "react";
import Header from "./Header";
import Footer from "./Footer";

const Layout = props => {
  const { isLoggedIn, isAdmin, children } = props;
  return (
    <Fragment>
      <Header isLoggedIn={isLoggedIn} isAdmin={isAdmin} />
      <div>{children}</div>
      <Footer />
    </Fragment>
  );
};

export default Layout;
