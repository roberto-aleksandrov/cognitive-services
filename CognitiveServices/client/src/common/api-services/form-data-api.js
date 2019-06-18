import axios from 'axios';

const getFormData = (data) => {
  const formData = new FormData();

  Object.keys(data).forEach((key) => {
    if (Array.isArray(data[key])) {
      data[key].forEach(value => formData.append(`${key}[]`, value));
    } else {
      formData.append(key, data[key]);
    }
  });

  return formData;
};

const api = config => ({
  exec: ({ method, data, url }) => {
    const formData = getFormData(data);

    return axios({
      method,
      url: `${config.baseUrl}/${url}`,
      crossdomain: true,
      data: formData,
      headers: { 'Content-Type': 'multipart/form-data' },
    });
  },
});

export default api;
