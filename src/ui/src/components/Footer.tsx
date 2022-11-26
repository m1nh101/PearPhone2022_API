import React from "react";

import { Link } from "react-router-dom";
import {
  footerAboutLinks,
  footerCustomerLinks,
} from "../assets/datarouter/linkrouter";

import Grid from "./Grid";

const Footer: React.FC = (): JSX.Element => {
  return (
    <footer className="footer">
      <div className="container">
        <Grid col={4} mdCol={2} smCol={1} gap={10}>
          <div>
            <div className="footer_title">Tổng đài hỗ trợ</div>
            <div className="footer_content">
              <p>
                Liên hệ đặt hàng <strong>0365609559</strong>
              </p>
              <p>
                Thắc mắc đơn hàng <strong>0365609559</strong>
              </p>
              <p>
                Góp ý, khiếu nại <strong>0365609559</strong>
              </p>
            </div>
          </div>
          <div>
            <div className="footer_title">Về PEARPHONE Shop</div>
            <div className="footer_content">
              {footerAboutLinks.map((item, index) => (
                <p key={index}>
                  <Link to={item.path}>{item.display}</Link>
                </p>
              ))}
            </div>
          </div>
          <div>
            <div className="footer_title">Chăm sóc khách hàng</div>
            <div className="footer_content">
              {footerCustomerLinks.map((item, index) => (
                <p key={index}>
                  <Link to={item.path}>{item.display}</Link>
                </p>
              ))}
            </div>
          </div>
          <div>
            <div className="footer_title">PEARPHONE Shop</div>
            <div className="footer_content">
              <p>
                <i className="bx bx-map">
                  <strong>Địa Chỉ :</strong> Yên Hòa - Cầu Giấy - Hà Nội
                </i>
              </p>
              <p>
                <i className="bx bx-mail-send">
                  <strong>Email :</strong> abcdefgh@gmail.com
                </i>
              </p>
              <p>
                <strong>
                  Bản quyền thuộc về PearPhone | cung cấp bởi nhóm{" "}
                </strong>
              </p>
            </div>
          </div>
        </Grid>
      </div>
    </footer>
  );
};

export default Footer;
