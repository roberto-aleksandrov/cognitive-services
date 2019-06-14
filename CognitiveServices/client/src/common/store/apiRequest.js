

export const API_REQUEST = 'API_REQUEST';

export const createApiRequest = ({ dispatch }) => (payload) => {
  dispatch(API_REQUEST, payload, { root: true });
};

const actions = ({ apiService }) => ({
  [API_REQUEST]: (context, payload) => {
    const { fulfill, reject } = payload.actions(context);

    apiService[payload.api].exec(payload)
      .then(fulfill)
      .catch(reject);
  },
});

export default ({ apiService }) => ({
  actions: actions({ apiService }),
});
