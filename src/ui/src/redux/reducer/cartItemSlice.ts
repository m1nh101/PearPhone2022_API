import { createSlice } from "@reduxjs/toolkit";
// import { Product } from "../../helpers/data";
import { get } from "../../utils/cache/storage";

const item =
  get("cartItems") !== null ? JSON.parse(get("cartItems") as any) : [];

// const findItem = (arr: Product, item) => arr.filter((e) => e.s);

const cartItemSilce = createSlice({
  name: "cartItems",
  initialState: {
    value: item,
  },
  reducers: {
    addItem: (state, action) => {
      const newItem = action.payload;
    },
    remove: (state) => {
      state.value = null;
    },
  },
});

export const { addItem, remove } = cartItemSilce.actions;
export default cartItemSilce.reducer;
