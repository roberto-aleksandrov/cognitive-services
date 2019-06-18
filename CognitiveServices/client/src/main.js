import Vue from 'vue';
import './plugins/vuetify';
import Toasted from 'vue-toasted';

import App from './App.vue';
import router from './router';
import initializeStore from './store';

import { api, formDataApi } from './common/api-services';
import { apiConfig, formDataApiConfig } from './common/api-services/configurations';

Vue.config.productionTip = false;
Vue.use(Toasted);

const apiService = {
  ajaxApi: api(apiConfig),
  formDataApi: formDataApi(formDataApiConfig),
};

new Vue({
  router,
  store: initializeStore({ apiService }),
  render: h => h(App),
}).$mount('#app');
