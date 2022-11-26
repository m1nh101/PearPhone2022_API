import { createSlice } from "@reduxjs/toolkit";

const productModealSilce = createSlice({
  name: "productModal",
  initialState: {
    value: null,
  },
  reducers: {
    set: (state, action) => {
      state.value = action.payload;
    },
    remove: (state) => {
      state.value = null;
    },
  },
});
export const { set, remove } = productModealSilce.actions;
export default productModealSilce.reducer;
