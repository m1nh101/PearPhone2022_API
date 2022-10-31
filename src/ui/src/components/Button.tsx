import React from "react";

interface PropButton {
  backgroundColor: string;
  size: string;
  animate: boolean;
  children: string;
  icon: string;
}

const Button: React.FC<PropButton> = (props: PropButton): JSX.Element => {
  const bg = props.backgroundColor ? "bg-" + props.backgroundColor : "bg-main";
  const size = props.size ? "btn-" + props.size : "";
  const animate = props.animate ? "btn-animate" : "";

  return (
    <button className={`btn ${bg} ${size} ${animate}`}>
      <span className="btn-txt">{props.children}</span>
      {props.icon ? (
        <span className="btn-icon">
          <i className={`${props.icon} bx-tada`}></i>
        </span>
      ) : null}
    </button>
  );
};

export default Button;
