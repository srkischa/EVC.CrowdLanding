import axios from "axios";
// import { AuthService } from "./Auth/AuthService";

const apiBaseUrl = process.env.REACT_APP_API_URL;

const instance = axios.create({
  baseURL: apiBaseUrl
});

// instance.interceptors.request.use(
//   config => {
//     return AuthService.getUser().then(user => {
//       if (user != null && user.access_token != null) {
//         const { access_token } = user;
//         config.headers.Authorization = `Bearer ${access_token}`;
//       }
//       return Promise.resolve(config);
//     });
//   },
//   err => {
//     return Promise.reject(err);
//   }
// );

export default instance;
