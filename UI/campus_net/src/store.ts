import Vue from 'vue';
import Vuex from 'vuex';

import axios from 'axios';
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    currentUserId: '',
  },
  mutations: {
    login(state, userId: string) {
      state.currentUserId = userId;
      // 向 session 中储存当前登录用户的 userId
      sessionStorage.setItem('currentUserId', userId);
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
