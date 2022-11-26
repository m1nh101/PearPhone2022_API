import React from "react";
import { Link } from "react-router-dom";
import productData from "../assets/fake-data/products";

const CartItem: React.FC = (): JSX.Element => {
  const data = productData.getProductBySlug("ao-thun-dinosaur-01");
  return (
    <div className="cart_item">
      <div className="cart_item-image">
        <img src={data?.image01} alt="" />
      </div>
      <div className="cart_item-info">
        <div className="cart_item-info-name">
          <Link to={`/catalog/${data?.slug}`}>
            {`${data?.title} - ${data?.colors} - ${data?.size}`}
          </Link>
        </div>
        <div className="cart_item-info-price">12k</div>
        <div className="cart_item-info-quantity">30k</div>
        <div className="product_info-item-quantity">
          <div className="product_info-item-quantity-btn">
            <i className="bx bx-minus"></i>
          </div>
          <div className="product_info-item-quantity-input">
            <i>0</i>
          </div>
          <div className="product_info-item-quantity-btn">
            <i className="bx bx-plus"></i>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartItem;
