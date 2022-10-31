import React from "react";

const Helmet = (props: any) => {
  document.title = "PearPhone - " + props.title;

  return <div>{props.children}</div>;
};
export default Helmet;
