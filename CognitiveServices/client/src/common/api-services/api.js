import axios from 'axios';
// import { getToken } from '../utilities/authentication-configuration';

const api = config => ({
  exec: ({ method, data, url }) => {
    const reqConfig = {
      method,
      url: `${config.baseUrl}/${url}`,
      crossdomain: true,
      headers: { 'Content-Type': 'application/json' },
    };

    if (method.toLowerCase() === 'get' || method.toLowerCase() === 'delete') {
      reqConfig.params = data;
    } else {
      reqConfig.data = data;
    }

    return axios(reqConfig);
  },
});

export default api;
