import axios from "axios";

const AuthService = axios.create({
  baseURL: `https://localhost:7236/api`,
  timeout: 5000,
  withCredentials: true,
});

export default AuthService;
