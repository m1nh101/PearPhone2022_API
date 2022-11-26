import React from "react";

const Checkbox = (props: any) => {
  const inputRef = React.useRef(null);
  const onChange = () => {
    if (props.onChange) {
      props.onChange(inputRef.current);
    }
  };
  return (
    <label className="custom_checkbox">
      <input
        type={"checkbox"}
        ref={inputRef}
        onChange={onChange}
        checked={props.checked}
      />
      <span className="custom_checkbox-checkmark">
        <i className="bx bx-check"></i>
      </span>
      {props.label}
    </label>
  );
};

export default Checkbox;
