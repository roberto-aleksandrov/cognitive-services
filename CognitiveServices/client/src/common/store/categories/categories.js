import { GET_CATEGORIES, getCategoriesActions } from './actions';
import { createApiRequest } from '../apiRequest';

const actions = {
  [GET_CATEGORIES.REJECTED]() {
    console.log('========== ERR ==========');
  },
  [GET_CATEGORIES.FULFILLED](context, data) {
    console.log(data);
    context.commit('saveCategories', data);
  },
  [GET_CATEGORIES.DEFAULT](context, data) {
    const { fulfill, reject } = getCategoriesActions(context);

    createApiRequest(context)({
      data,
      api: 'ajaxApi',
      url: 'categories/getall',
      method: 'get',
      onSuccess: [fulfill],
      onFailure: [reject],
    });
  },
};

const mutations = {
  saveCategories(state, payload) {
    state.categories = payload.data;
  },
};

const state = {
  categories: [],
};

export default {
  namespaced: true,
  state,
  actions,
  mutations,
};
