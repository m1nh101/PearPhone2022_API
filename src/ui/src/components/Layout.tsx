import React from "react";
import { BrowserRouter } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";
import RouterApps from "./../router/Routes";
import ProductViewModal from "./ProductViewModal";

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
      <ProductViewModal />
    </BrowserRouter>
  );
};

export default Layout;
