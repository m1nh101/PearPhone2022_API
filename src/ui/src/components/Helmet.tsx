import React from "react";

const Helmet = (props: any) => {
  document.title = "PearPhone - " + props.title;
  React.useEffect(() => {
    window.scrollTo(0, 0);
  }, []);
  return <div>{props.children}</div>;
};
export default Helmet;
