import Vue from 'vue';
import Vuex from 'vuex';
import createPicture from './features/pictures/create-picture-page/store';
import category from './common/store/categories';
import apiRequest from './common/store/apiRequest';

Vue.use(Vuex);

export default ({ apiService }) => new Vuex.Store({
  strict: true,
  modules: {
    category,
    createPicture,
    apiRequest: apiRequest({ apiService }),
  },
});
