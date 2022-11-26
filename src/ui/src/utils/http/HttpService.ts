import axios from "axios";

const AuthService = axios.create({
  baseURL: `https://localhost:7236/api`,
  timeout: 5000,
});

// Request interceptor
AuthService.interceptors.request.use(
  async (configs) => {
    return configs;
  },
  (error) => {
    console.log(error.response);
    return error;
  }
);

// Response interceptor
AuthService.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    return error;
  }
);
export default AuthService;
