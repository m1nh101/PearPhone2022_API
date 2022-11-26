import React from "react";
import { Link } from "react-router-dom";
import Button from "../components/Button";
import CartItem from "../components/CartItem";
import Helmet from "../components/Helmet";

const Cart: React.FC = (): JSX.Element => {
  return (
    <Helmet title="Gio Hang">
      <div className="cart">
        <div className="cart_info">
          <div className="cart_info-txt">
            <p>bạn có 3 sp trong giỏ hàng</p>
            <div className="cart_info-txt-price">
              <span>thành tiền</span>
              <span>12k</span>
            </div>
          </div>
          <div className="cart_info-btn">
            <Button size="block">đặt hàng</Button>
            <Link to="/catalog">
              <Button size="block">tiếp tục mua hàng</Button>
            </Link>
          </div>
        </div>
        <CartItem />
      </div>
    </Helmet>
  );
};

export default Cart;
