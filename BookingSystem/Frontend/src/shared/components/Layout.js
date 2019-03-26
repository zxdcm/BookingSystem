import React, { Fragment } from "react";
import Header from "./Header";
import Footer from "./Footer";
import { Container, Row } from "reactstrap";
const Layout = props => {
  const { isLoggedIn, isAdmin, children } = props;
  return (
    <Container>
      <Row>
        <Header isLoggedIn={isLoggedIn} isAdmin={isAdmin} />
      </Row>
      {children}
      <Row>
        <Footer />
      </Row>
    </Container>
  );
};

export default Layout;
