import Vue from 'vue';
import Vuex from 'vuex';
import User from './user';
import FileModule from './file';
import QuestionModule from './question';

Vue.use(Vuex);


export default new Vuex.Store({
  modules: {
    user: User,
    file: FileModule,
    question: QuestionModule,
  },
});
