import { juxt } from 'ramda';

export const API_REQUEST = 'API_REQUEST';

export const createApiRequest = ({ dispatch }) => (payload) => {
  dispatch(API_REQUEST, payload, { root: true });
};

const actions = ({ apiService }) => ({
  [API_REQUEST]: (context, payload) => {
    const { onSuccess, onFailure } = payload;

    apiService[payload.api].exec(payload)
      .then(juxt(onSuccess))
      .catch(err => juxt(onFailure)(err.response));
  },
});

export default ({ apiService }) => ({
  actions: actions({ apiService }),
});
