import {
  GET_CATEGORIES,
  GET_SUBCATEGORIES,
  categoriesMutations,
} from './actions';
import { createApiRequest } from '../apiRequest';
import { notifyActions } from '../notifications';
import createWhereClause from './createWhereClause';

const actions = {
  [GET_CATEGORIES.REJECTED]() {
    console.log('========== ERR ==========');
  },
  [GET_CATEGORIES.DEFAULT](context) {
    const { saveCategories } = categoriesMutations(context);
    const { error } = notifyActions(context);

    createApiRequest(context)({
      data: { where: 'ParentId = null' },
      api: 'ajaxApi',
      url: 'categories/getall',
      method: 'get',
      onSuccess: [saveCategories],
      onFailure: [error],
    });
  },
  [GET_SUBCATEGORIES.DEFAULT](context, { ids }) {
    const { saveSubcategories } = categoriesMutations(context);
    const { error } = notifyActions(context);

    if (ids.length === 0) {
      saveSubcategories({});
      return;
    }

    createApiRequest(context)({
      data: { where: createWhereClause(ids), include: 'Parent' },
      api: 'ajaxApi',
      url: 'categories/getall',
      method: 'get',
      onSuccess: [saveSubcategories],
      onFailure: [error],
    });
  },
};

const mutations = {
  saveCategories(state, payload) {
    state.categories = payload.data;
  },
  saveSubcategories(state, payload) {
    state.subCategories = payload.data || [];
  },
};

const state = {
  categories: [],
  subCategories: [],
};

export default {
  namespaced: true,
  state,
  actions,
  mutations,
};
