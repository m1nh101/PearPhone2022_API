import React, { useRef, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { mainNav } from "../assets/datarouter/linkrouter";
import Example from "./../pages/offCanvas";

const Header: React.FC = (): JSX.Element => {
  interface newcurrent {
    className: string;
  }
  const headerRef = useRef<newcurrent>({
    className: "header",
  });

  const [headerTag, setHeaderTag] = useState("header");
  const [menuleft, setMenuleft] = useState("header_menu_left");
  const showMenu = () => setMenuleft("header_menu_left active");
  const closeMenu = () => setMenuleft("header_menu_left");

  useEffect(() => {
    window.addEventListener("scroll", () => {
      if (
        document.body.scrollTop > 80 ||
        document.documentElement.scrollTop > 80
      ) {
        if (headerRef && !headerRef.current.className.includes("shrink")) {
          setHeaderTag("header shrink");
        }
      } else {
        setHeaderTag("header");
      }
    });
    return () => {
      window.removeEventListener("scroll", () => {});
    };
  }, []);
  return (
    <div className={headerTag}>
      <div className="container">
        <div className="header_logo">
          <p className="header_p">PEARPHONE</p>
        </div>
        <div className="header_menu">
          <div className="header_menu_mobile-toggle">
            <i className="bx bx-menu" onClick={showMenu}></i>
          </div>
          <div className={menuleft}>
            <div className="header_menu_left_close">
              <i className="bx bx-left-arrow-alt" onClick={closeMenu}></i>
            </div>
            {mainNav.map((item, index) => (
              <div
                key={index}
                className={`header_menu_item
                    header_menu_left_item  `}
              >
                <Link to={item.path}>
                  <span>{item.display}</span>
                </Link>
              </div>
            ))}
          </div>
          <div className="header_menu_right">
            <div className="header_menu_item header_menu_right_item">
              <Example />
            </div>
            <div className="header_menu_item header_menu_right_item">
              <Link to="/login">Login</Link>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Header;
