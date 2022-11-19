/* eslint-disable jsx-a11y/anchor-is-valid */
import { useState } from "react";
import { Offcanvas } from "react-bootstrap";
function Example() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <div>
      <a onClick={handleShow}>
        <i className="bx bxs-cart-alt"></i>
      </a>

      <Offcanvas
        show={show}
        onHide={handleClose}
        placement={"end"}
        scroll={true}
        backdrop={true}
      >
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Giỏ Hàng</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>các sản phẩm đã được đặt hàng</Offcanvas.Body>
      </Offcanvas>
    </div>
  );
}

export default Example;
