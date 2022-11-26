import { configureStore } from "@reduxjs/toolkit";
import productModalSlice from "../reducer/productModalSlice";

export const store = configureStore({
  reducer: {
    productModal: productModalSlice,
  },
});
