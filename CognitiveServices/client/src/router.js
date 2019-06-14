import Vue from 'vue';
import Router from 'vue-router';
import Home from './features/Home.vue';
import CreatePicturePage from './features/pictures/create-picture-page';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/pictures/create',
      name: 'createPicturePage',
      component: CreatePicturePage,
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './features/About.vue'),
    },
  ],
});
