import React from "react";

import { Route, Routes } from "react-router-dom";
import Catalog from "../pages/Catalog";
import Home from "../pages/Home";
import Login from "../pages/login";
import Product from "./../pages/Product";
import Cart from "./../pages/Cart";

const RouterApps = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/catalog" element={<Catalog />} />
      <Route path="/catalog/:slug" element={<Product />} />
      <Route path="login" element={<Login />} />
      <Route path="cart" element={<Cart />} />
    </Routes>
  );
};

export default RouterApps;
