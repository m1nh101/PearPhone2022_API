import React from "react";

import { Route, Routes } from "react-router-dom";
import Catalog from "../pages/Catalog";
import Home from "../pages/Home";
import Login from "../pages/login";

const RouterApps = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/catalog" element={<Catalog />} />
      <Route path="login" element={<Login />} />
    </Routes>
  );
};

export default RouterApps;
