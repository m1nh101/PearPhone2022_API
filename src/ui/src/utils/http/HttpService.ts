import axios from "axios";

const AuthService = axios.create({
  baseURL: `https://localhost:7236/api`,
  timeout: 5000,
});

// Request interceptor
AuthService.interceptors.request.use(
  async (configs: any) => {
    configs.headers.post["Content-Type"] = "application/json";
    return configs;
  },
  (error) => {
    console.log(error.response);
    return Promise.reject(error);
  }
);

// Response interceptor
AuthService.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    return Promise.reject(
      error !== undefined ? error.response : "Network error"
    );
  }
);
export default AuthService;
