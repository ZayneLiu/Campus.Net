import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home,
    },
    {
      path: '/qa',
      name: 'Questions&Answers',
      component: () => import('@/views/QA.vue'),
    },
    {
      path: '/qa/ask',
      name: 'AskQuestion',
      component: () => import('@/components/QA/AskQuestion.vue'),
    },
    {
      path: '/qa/:qid',
      name: 'QuestionDetail',
      component: () => import('@/views/QuestionDetail.vue'),
      props: true,
    },
    {
      path: '/profile',
      name: 'Profile',
      component: () => import('@/views/Profile.vue'),
      children: [
        {
          path: 'my-answers',
          name: 'MyAnswers',
          component: () => import('@/components/Profile/MyAnswers.vue'),
        },
        {
          path: 'my-questions',
          name: 'MyQuestions',
          component: () => import('@/components/Profile/MyQuestions.vue'),
        },
        {
          path: 'my-watch-list',
          name: 'MyWatchList',
          component: () => import('@/components/Profile/MyWatchList.vue'),
        },
      ],
    },
    {
      path: '/result/:content',
      name: 'SearchResult',
      props: true,
      component: () => import('@/views/Result.vue'),

    },
    {
      path: '/login',
      name: 'Login',
      component: () => import('./components/Login.vue'),
    },
    {
      path: '/register',
      name: 'Register',
      component: () => import('./components/Register.vue'),
    },
    {
      path: '/about',
      name: 'About',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue'),
    },
  ],
});
