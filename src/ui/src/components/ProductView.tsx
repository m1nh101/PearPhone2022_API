import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { moneyVi } from "./../utils/moneyConvert";

export interface Product {
  title?: string;
  price?: string;
  image01?: string;
  image02?: string;
  slug?: string;
  description?: string;
  colors?: string[];
  size?: string[];
}

const ProductView: React.FC<Product> = (products: Product): JSX.Element => {
  const [descriptionExpand, setDescriptionExpand] = useState(false);
  const [color, setColor] = useState<string>();
  const [size, setSize] = useState<string>();
  const [quantity, setQuantity] = useState(1);
  const [previewImg, setPreViewImg] = useState(products.image01);

  const updateQuantity = (type: string) => {
    if (type === "plus") {
      setQuantity(quantity + 1);
    } else {
      setQuantity(quantity - 1 < 1 ? 1 : quantity - 1);
    }
  };
  useEffect(() => {
    setPreViewImg(products.image01);
    setQuantity(1);
    setColor("");
    setSize("");
  }, [products]);

  const CheckData = () => {
    if (color === "") {
      alert("Vui lòng chọn màu sắc");
      return false;
    }
    if (size === "") {
      alert("Vui lòng chọn kích cỡ");
      return false;
    }
    return true;
  };
  const addToCart = () => {
    if (CheckData()) console.log({ color, size, quantity });
  };

  return (
    <div className="product">
      <div className="product_image">
        <div className="product_image-list">
          <div
            className="product_image-list-item"
            onClick={() => setPreViewImg(products.image01)}
          >
            <img src={products.image01} alt="" />
          </div>
          <div
            className="product_image-list-item"
            onClick={() => setPreViewImg(products.image02)}
          >
            <img src={products.image02} alt="" />
          </div>
        </div>
        <div className="product_image-main">
          <img src={previewImg} alt="" />
        </div>
        <div
          className={`product_description ${
            descriptionExpand ? "expand" : null
          }`}
        >
          <div className="product_description-title">Chi tiết sản phẩm</div>
          <div
            className="product_description-content"
            dangerouslySetInnerHTML={{ __html: products.description! }}
          ></div>
          <div className="product_description-toggle">
            <button
              type="button"
              className="btn btn-info"
              onClick={() => setDescriptionExpand(!descriptionExpand)}
            >
              {!descriptionExpand ? "Xem thêm" : "Thu gọn"}
            </button>
          </div>
        </div>
      </div>
      <div className="product_info">
        <h1 className="product_info-title">{products.title}</h1>
        <div className="product_info-item">
          <span className="product_info-item-price">
            {moneyVi(products.price!)}
          </span>
        </div>
        <div className="product_info-item">
          <div className="product_info-item-title">Màu Sắc</div>
          <div className="product_info-item-list">
            {products.colors?.map((item, index) => (
              <div
                key={index}
                className={`product_info-item-list-item ${
                  color === item ? "active" : ""
                }`}
                onClick={() => setColor(item)}
              >
                <div className={`circle bg-${item}`}></div>
              </div>
            ))}
          </div>
        </div>
        <div className="product_info-item">
          <div className="product_info-item-title">Kích cỡ</div>
          <div className="product_info-item-list">
            {products.size?.map((item, index) => (
              <div
                key={index}
                className={`product_info-item-list-item ${
                  size === item ? "active" : ""
                }`}
                onClick={() => setSize(item)}
              >
                <div className="product_info-item-list-item-size">{item}</div>
              </div>
            ))}
          </div>
        </div>
        <div className="product_info-item">
          <div className="product_info-item-title">Số lượng</div>
          <div className="product_info-item-quantity">
            <div
              className="product_info-item-quantity-btn"
              onClick={() => updateQuantity("minus")}
            >
              <i className="bx bx-minus"></i>
            </div>
            <div className="product_info-item-quantity-input">
              <i>{quantity}</i>
            </div>
            <div
              className="product_info-item-quantity-btn"
              onClick={() => updateQuantity("plus")}
            >
              <i className="bx bx-plus"></i>
            </div>
          </div>
        </div>
        <div className="product_info-item">
          <button
            type="button"
            className="btn btn-info"
            onClick={() => addToCart()}
          >
            Thêm vào giỏ hàng
          </button>
          <Link
            to={{
              pathname: "/cart",
            }}
          >
            <button type="button" className="btn btn-info">
              mua ngay
            </button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default ProductView;
