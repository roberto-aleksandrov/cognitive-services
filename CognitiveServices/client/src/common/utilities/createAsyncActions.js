export const createAsyncActions = ({ types, namespace }) => ({ dispatch }) => ({
  reject: err => dispatch(`${namespace}/${types.REJECTED}`, err, { root: true }),
  fulfill: data => dispatch(`${namespace}/${types.FULFILLED}`, data, { root: true }),
  pending: () => dispatch(`${namespace}/${types.PENDING}`, {}, { root: true }),
});
