import React from "react";
import Helmet from "./../components/Helmet";
import Grid from "./../components/Grid";
import productData from "../assets/fake-data/products";
import ProductCard from "../components/ProductCard";
import category from "./../assets/fake-data/category";
import Checkbox from "../components/Checkbox";
import colors from "../assets/fake-data/product-color";
import size from "./../assets/fake-data/product-size";
import Button from "../components/Button";

const Catalog: React.FC = (): JSX.Element => {
  const productList = productData.getAllProducts();
  return (
    <Helmet title="San Pham">
      <div className="catalog">
        <div className="catalog_filter">
          <div className="catalog_filter-widget">
            <div className="catalog_filter-widget-title">Danh muc san pham</div>
            <div className="catalog_filter-widget-content">
              {category.map((item, index) => (
                <div className="catalog_filter-widget-content-item" key={index}>
                  <Checkbox label={item.display} />
                </div>
              ))}
            </div>
          </div>
          <div className="catalog_filter-widget">
            <div className="catalog_filter-widget-title">Mau Sac</div>
            <div className="catalog_filter-widget-content">
              {colors.map((item, index) => (
                <div className="catalog_filter-widget-content-item" key={index}>
                  <Checkbox label={item.display} />
                </div>
              ))}
            </div>
          </div>
          <div className="catalog_filter-widget">
            <div className="catalog_filter-widget-title">Kich Co</div>
            <div className="catalog_filter-widget-content">
              {size.map((item, index) => (
                <div className="catalog_filter-widget-content-item" key={index}>
                  <Checkbox label={item.display} />
                </div>
              ))}
            </div>
          </div>
          <div className="catalog_filter-widget">
            <div className="catalog_filter-widget-content">
              <Button size="sm" icon="" animate={false} backgroundColor="">
                xoa bo loc
              </Button>
            </div>
          </div>
        </div>
        <div className="catalog_content">
          <Grid col={3} mdCol={2} smCol={1} gap={20}>
            {productList.map((item, index) => (
              <ProductCard
                key={index}
                image01={item.image01}
                image02={item.image02}
                title={item.title}
                price={item.price}
                slug={item.slug}
              ></ProductCard>
            ))}
          </Grid>
        </div>
      </div>
    </Helmet>
  );
};

export default Catalog;
