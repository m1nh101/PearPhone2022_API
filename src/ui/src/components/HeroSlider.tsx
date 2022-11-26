import React, { useCallback, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { data } from "./../helpers/data";
import Button from "./Button";

interface Props {
  list: Array<data>;
  control: boolean;
  auto: boolean;
  timeOut: number;
}
interface PropsItem {
  item: data;
  active: boolean;
}
const HeroSlider: React.FC<Props> = (props: Props): JSX.Element => {
  const { list } = props;
  const [activeSlide, setActiveSlide] = useState(0);
  const timeOut = props.timeOut ? props.timeOut : 2000;

  const nextSlide = useCallback(() => {
    const index = activeSlide + 1 === list.length ? 0 : activeSlide + 1;
    setActiveSlide(index);
  }, [activeSlide, list]);

  const prevSlide = () => {
    const index = activeSlide - 1 < 0 ? 0 : activeSlide - 1;
    setActiveSlide(index);
  };

  useEffect(() => {
    if (props.auto) {
      const slideAuto = setInterval(() => {
        nextSlide();
      }, timeOut);
      return () => clearInterval(slideAuto);
    }
  }, [nextSlide, timeOut, props]);

  return (
    <div className="hero_slider">
      {list.map((item, index) => (
        <HeroSliderItem
          key={index}
          item={item}
          active={index === activeSlide}
        />
      ))}
      {props.control ? (
        <div className="hero_slider_control">
          <div className="hero_slider_control-item">
            <i className="bx bx-chevron-left" onClick={prevSlide} />
          </div>
          <div className="hero_slider_control-item">
            <div className="index">
              {activeSlide + 1} / {list.length}
            </div>
          </div>
          <div className="hero_slider_control-item">
            <i className="bx bx-chevron-right" onClick={nextSlide} />
          </div>
        </div>
      ) : (
        <div className="abc">abc</div>
      )}
    </div>
  );
};

const HeroSliderItem = (props: PropsItem) => (
  <div className={`hero_slider_item ${props.active ? "active" : ""}`}>
    <div className="hero_slider_item-info">
      <div className={`hero_slider_item-info-title color-${props.item.color}`}>
        <span>{props.item.title}</span>
      </div>
      <div className="hero_slider_item_info-desciption">
        <span>{props.item.description}</span>
      </div>
      <div className="hero_slider_item-info-btn">
        <Link to={props.item.path}>
          <Button
            backgroundColor={props.item.color}
            icon={"bx bx-cart"}
            animate={true}
            size={"sm"}
          >
            xem chi tiet
          </Button>
        </Link>
      </div>
    </div>
    <div className="hero_slider_item-image">
      <div className={`shape bg-${props.item.color}`}></div>
      <img src={props.item.img} alt="" />
    </div>
  </div>
);

export default HeroSlider;
