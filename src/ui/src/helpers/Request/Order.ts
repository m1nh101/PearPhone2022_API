export interface Add {
  productId: number;
  itemId: number;
}

export interface Patch {
  productId: number;
  itemId: number;
  quantity: number;
}

export interface Delete {
  productId: number;
  itemId: number;
}
