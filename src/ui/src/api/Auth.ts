import AuthService from "../utils/http/Request";
import HttpService from "../utils/http/HttpService";
import { Login, Register } from "../helpers/Request/Auth";

export function login(data: Login) {
  return HttpService({
    url: "/auth/login",
    method: "post",
    data,
  });
}

export function logout() {
  return AuthService({
    url: "/auth/logout",
    method: "post",
  });
}

export function register(data: Register) {
  return HttpService({
    url: "/auth/register",
    method: "post",
    data,
  });
}
