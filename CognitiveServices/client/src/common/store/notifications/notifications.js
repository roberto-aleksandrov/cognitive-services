import Vue from 'vue';
import { forEachObjIndexed } from 'ramda';

export const NOTIFY_ERROR = 'NOTIFY_ERROR';
export const NOTIFY_SUCCESS = 'NOTIFY_SUCCESS';

export const notifyActions = ({ dispatch }) => ({
  error: payload => dispatch(NOTIFY_ERROR, payload, { root: true }),
  success: payload => dispatch(NOTIFY_SUCCESS, payload, { root: true }),
});

const OPTIONS = {
  duration: 5000,
  keepOnHover: true,
};

const SUCCESS_OPTIONS = {
  ...OPTIONS,
  type: 'success',
};

const ERROR_OPTIONS = {
  ...OPTIONS,
  type: 'error',
};

const actions = {
  [NOTIFY_ERROR]: (context, { data, message }) => {
    Vue.toasted.show(message, ERROR_OPTIONS);
    forEachObjIndexed(e => Vue.toasted.show(e, ERROR_OPTIONS), data);
  },
  [NOTIFY_SUCCESS]: (context, { data, message }) => {
    Vue.toasted.show(message, SUCCESS_OPTIONS);
    forEachObjIndexed(e => Vue.toasted.show(e, SUCCESS_OPTIONS), data);
  },
};

export default {
  actions,
};
