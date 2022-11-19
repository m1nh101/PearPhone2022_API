import React from "react";
import Helmet from "../components/Helmet";
import productData from "../assets/fake-data/products";
import { Section, SectionBody, SectionTitle } from "./../components/Section";
import Grid from "../components/Grid";
import ProductCard from "../components/ProductCard";
import { useParams } from "react-router-dom";
import ProductView from "../components/ProductView";

const Product: React.FC = (props: any): JSX.Element => {
  const { slug } = useParams();
  const product = productData.getProductBySlug(slug!);
  console.log(product);
  const relateProducts = productData.getProducts(8);
  React.useEffect(() => {
    window.scrollTo(0, 0);
  }, [product]);
  return (
    <Helmet title={product?.title}>
      <Section>
        <SectionBody>
          <ProductView {...product} />
        </SectionBody>
      </Section>
      <Section>
        <SectionTitle>Tìm hiểu thêm</SectionTitle>
        <SectionBody>
          <Grid col={4} mdCol={2} smCol={1} gap={20}>
            {relateProducts.map((item, index) => (
              <ProductCard
                key={index}
                image01={item.image01}
                image02={item.image02}
                title={item.title}
                price={item.price}
                slug={item.slug}
              />
            ))}
          </Grid>
        </SectionBody>
      </Section>
    </Helmet>
  );
};

export default Product;
