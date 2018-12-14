import Vue from 'vue';
import Vuex, { Dictionary } from 'vuex';

import axios from 'axios';
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    currentUser: '',
  },
  mutations: {
    login(state, user: Dictionary<string>) {
      state.currentUser = user['id'];
      // console.log('state.currentUser = user;');
      // 向 session 中储存当前登录用户的 userId
      // user[""]
    },
  },
  actions: {
    login(loginInfo) {
      console.log('Login');

      // axios({
      //   method: 'post',
      //   url: 'https://localhost:5001/api/user',
      //   responseType: 'application/json',
      //   data: loginInfo,
      // });
    },
  },
});
