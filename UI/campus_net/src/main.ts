import Vue from 'vue';
import App from './App.vue';
import router from './router';
import Vuex from 'vuex';
import store from './store';
import Vuelidate from 'vuelidate';

// Vue.prototype = axios;
Vue.config.productionTip = false;
Vue.use(Vuex);
Vue.use(Vuelidate);

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
