import React from "react";
import { Policy } from "../helpers/data";

const PolicyCard: React.FC<Policy> = (props: Policy): JSX.Element => {
  return (
    <div className="policy_card">
      <div className="policy_card-icon">
        <i className={props.icon}></i>
      </div>
      <div className="policy_card-info">
        <div className="policy_card-info-name">{props.name}</div>
        <div className="policy_card-info-description">{props.description}</div>
      </div>
    </div>
  );
};

export default PolicyCard;
