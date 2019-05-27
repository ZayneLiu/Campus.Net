import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store/index';

import Axios from 'axios';

Axios.defaults.baseURL = 'http://localhost:5000/';


import iView from 'iview';
import 'iview/dist/styles/iview.css';


Vue.prototype.$EventBus = new Vue();

Vue.use(iView);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
