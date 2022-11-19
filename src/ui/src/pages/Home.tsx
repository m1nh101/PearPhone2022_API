// import axios from "axios";
// import { Api } from "./../assets/datarouter/apirouter";
// import React, { useEffect, useState } from "react";
import React from "react";
import HeroSlider from "../components/HeroSlider";
import Helmet from "./../components/Helmet";
import heroSliderData from "./../assets/fake-data/hero-slider";
import { Section, SectionBody, SectionTitle } from "./../components/Section";
import policy from "../assets/fake-data/policy";
import PolicyCard from "../components/PolicyCard";
import Grid from "../components/Grid";
import productData from "../assets/fake-data/products";
import ProductCard from "../components/ProductCard";
import { Link } from "react-router-dom";
import banner from "../assets/images/banner.png";

// interface Data {
//   id: number;
//   name: string;
//   rgb: string;
// }

const Home: React.FC = (): JSX.Element => {
  // const [listData, setListData] = useState<Data[]>([]);
  // useEffect(() => {
  //   const getApi = async () => {
  //     console.log(`${Api.color}`);
  //     await axios.get(`${Api.color}`).then((res) => {
  //       setListData(res.data);
  //     });
  //   };
  //   getApi();
  // }, [listData]);
  //     <div>
  //       {listData.map((e) => (
  //         <h2 key={e.id}>
  //           {e.name} + {e.rgb}
  //         </h2>
  //       ))}
  //     </div>

  return (
    <Helmet title="Trang Chu">
      <HeroSlider
        control={true}
        list={heroSliderData}
        auto={true}
        timeOut={3000}
      ></HeroSlider>
      <Section>
        <SectionBody>
          <Grid col={4} mdCol={2} smCol={1} gap={20}>
            {policy.map((item, index) => (
              <Link to={"/policy"} key={index}>
                <PolicyCard
                  name={item.name}
                  description={item.description}
                  icon={item.icon}
                />
              </Link>
            ))}
          </Grid>
        </SectionBody>
      </Section>

      <Section>
        <SectionTitle>top san pham ban chay</SectionTitle>
        <SectionBody>
          <Grid col={4} mdCol={2} smCol={1} gap={20}>
            {productData.getProducts(4).map((item, index) => (
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
        </SectionBody>
      </Section>

      {/* banner */}
      <Section>
        <SectionBody>
          <Link to="/catalog">
            <img src={banner} alt="" />
          </Link>
        </SectionBody>
      </Section>

      <Section>
        <SectionTitle>Pho Bien</SectionTitle>
        <SectionBody>
          <Grid col={4} mdCol={2} smCol={1} gap={20}>
            {productData.getProducts(12).map((item, index) => (
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
        </SectionBody>
      </Section>
    </Helmet>
  );
};

export default Home;
