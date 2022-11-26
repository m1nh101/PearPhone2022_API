import React from "react";
import { useDispatch } from "react-redux";
import { Link } from "react-router-dom";
import { set } from "../redux/reducer/productModalSlice";
import { moneyUs, moneyVi } from "./../utils/moneyConvert";

export interface Product {
  title: string;
  price: string;
  image01: string;
  image02: string;
  slug: string;
}

const ProductCard: React.FC<Product> = (props: Product): JSX.Element => {
  const dispatch = useDispatch();
  return (
    <div className="product_card">
      <Link to={`/catalog/${props.slug}`}>
        <div className="product_card-image">
          <img src={props.image01} alt="" />
          <img src={props.image02} alt="" />
        </div>
        <h3 className="product_card-name">{props.title}</h3>
        <div className="product_card-price">
          {moneyUs(props.price)}
          <span className="product_card-price-old">
            <del>{moneyVi("399000")}</del>
          </span>
        </div>
      </Link>
      <div className="product_card-btn">
        <button
          className="btn btn-primary"
          onClick={() => dispatch(set(props.slug))}
        >
          chon mua
        </button>
      </div>
    </div>
  );
};

export default ProductCard;
