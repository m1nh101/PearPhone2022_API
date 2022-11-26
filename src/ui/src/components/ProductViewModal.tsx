import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { Product } from "../helpers/data";
import { remove } from "../redux/reducer/productModalSlice";
import productData from "./../assets/fake-data/products";
import ProductView from "./ProductView";

const ProductViewModal: React.FC = (): JSX.Element => {
  const productSlug = useSelector((item: any) => item.productModal.value);
  const dispatch = useDispatch();

  const [product, setProduct] = useState<Product | undefined>();

  useEffect(() => {
    setProduct(productData.getProductBySlug(productSlug));
  }, [productSlug]);

  return (
    <div
      className={`product_view-modal ${product === undefined ? "" : "active"}`}
    >
      <div className="product_view-modal-content">
        <ProductView {...product} />
        <div className="product_view-modal-content-close">
          <Button size="sm" onClick={() => dispatch(remove())}>
            Đóng
          </Button>
        </div>
      </div>
    </div>
  );
};

export default ProductViewModal;
