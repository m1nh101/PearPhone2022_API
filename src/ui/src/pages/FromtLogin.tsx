import { useState } from "react";
import axios from "axios";
import { Api } from "./../assets/datarouter/apirouter";
import { Link } from "react-router-dom";
import { login } from "../api/Auth";

const BasicExample: React.FC = (): JSX.Element => {
  const [Username, setUsername] = useState("");
  const [Password, setPassword] = useState("");
  const loginClick = async () => {
    // gọi thẳng axios thì nhận
    // const res = await axios.post(`${Api.login}`, {
    //   Username: "test",
    //   Password: "test@2002",
    // });
    // alert(res.data.message);

    //
    const data = {
      Username: "test",
      Password: "test@2002",
    };
    const response = await login(data);
    console.log(response.data);
  };
  return (
    <div className="LoginBody">
      <div className="login">
        <h1>Hello Again! </h1>
        <form className="needs-validation">
          <div className="form-group was-validated">
            <label className="form-label" htmlFor="email">
              Username
            </label>
            <input
              required
              className="login_input form-control"
              type="text"
              onChange={(e) => setUsername(e.target.value)}
            />
            <div className="invalid-feedback">Dien di may ban e!</div>
          </div>
          <div className="form-group was-validated">
            <label className="form-label" htmlFor="password">
              Password
            </label>
            <input
              className="login_input form-control"
              required
              type="password"
              onChange={(e) => setPassword(e.target.value)}
            />
            <div className="invalid-feedback">Dien di may ban e!</div>
          </div>
          <div className="input-group form-group d-flex justify-content-between">
            <div className="form-check">
              <input
                className="form-check-input"
                type="checkbox"
                value=""
                id="flexCheckDefault"
              />
              <label className="form-check-label" htmlFor="flexCheckDefault">
                Remember me
              </label>
            </div>
            <Link to={"/register"}>
              <i className="bx bxs-registered" />
              Register
            </Link>
          </div>
        </form>
        <div className="login_btn">
          <button
            onClick={loginClick}
            className={"custome_btn-4"}
            type="submit"
          >
            <span>submit</span>
          </button>
        </div>
      </div>
    </div>
  );
};

export default BasicExample;
