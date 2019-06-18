import Vue from 'vue';
import Vuex from 'vuex';
import createPicture from './features/pictures/create-picture-page/store';
import updatePicture from './features/pictures/update-picture-page/store';
import picture from './common/store/pictures';
import category from './common/store/categories';
import apiRequest from './common/store/apiRequest';
import notifications from './common/store/notifications';

Vue.use(Vuex);

export default ({ apiService }) => new Vuex.Store({
  strict: true,
  modules: {
    category,
    picture,
    createPicture,
    updatePicture,
    apiRequest: apiRequest({ apiService }),
    notifications,
  },
});
