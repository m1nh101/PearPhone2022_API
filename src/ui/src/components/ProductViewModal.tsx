import React from "react";
import { Button } from "react-bootstrap";
import productData from "./../assets/fake-data/products";
import ProductView from "./ProductView";

const ProductViewModal: React.FC = (): JSX.Element => {
  const product = productData.getProductBySlug("ao-thun-dinosaur-01");
  return (
    <div
      className={`product_view-modal ${product === undefined ? "" : "active"}`}
    >
      <div className="product_view-modal-content">
        <ProductView {...product} />
        <div className="product_view-modal-content-close">
          <Button size="sm">Đóng</Button>
        </div>
      </div>
    </div>
  );
};

export default ProductViewModal;
