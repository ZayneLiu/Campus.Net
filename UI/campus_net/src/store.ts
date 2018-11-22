import Vue from 'vue';
import Vuex from 'vuex';

import axios from 'axios';
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    currentUser: '',
  },
  mutations: {
    changeUser(state, user) {
      state.currentUser = user;
    },
  },
  actions: {
    login(loginInfo) {
      // axios({
      //   method: 'post',
      //   url: 'https://localhost:5001/api/user',
      //   responseType: 'application/json',
      //   data: loginInfo,
      // });
    },
  },
});
