import React from "react";
import { Link } from "react-router-dom";
import Button from "./Button";
import { moneyUs, moneyVi } from "./../utils/moneyConvert";

export interface Product {
  title: string;
  price: string;
  image01: string;
  image02: string;
  slug: string;
}

const ProductCard: React.FC<Product> = (props: Product): JSX.Element => {
  return (
    <div className="product_card">
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
      <div className="product_card-btn">
        <Link to={`/catalog/${props.slug}`}>
          <Button size="sm" icon="bx bx-cart" animate={true} backgroundColor="">
            chon mua
          </Button>
        </Link>
      </div>
    </div>
  );
};

export default ProductCard;
