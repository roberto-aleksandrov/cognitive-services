import { GET_CATEGORIES, getCategoriesActions } from './actions';
import { createApiRequest } from '../apiRequest';

const actions = {
  [GET_CATEGORIES.REJECTED]() {
    console.log('========== ERR ==========');
  },
  [GET_CATEGORIES.FULFILLED](context, data) {
    context.commit('saveCategories', data);
  },
  [GET_CATEGORIES.DEFAULT](context, data) {
    createApiRequest(context)({
      data,
      api: 'ajaxApi',
      url: 'categories/getall',
      method: 'get',
      actions: getCategoriesActions,
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
