import React from "react";
import { BrowserRouter } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";
import RouterApps from "./../router/Routes";

const Layout: React.FC = (): JSX.Element => {
  return (
    <BrowserRouter>
      <Header />
      <div className="container">
        <div className="main">
          <RouterApps />
        </div>
      </div>
      <Footer />
    </BrowserRouter>
  );
};

export default Layout;
