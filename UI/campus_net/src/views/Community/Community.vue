<template>
  <div id="outer_container">
    <div class="nav">
      <router-link to="/posts" v-html="'专栏'"/>
      <router-link to="/questions" v-html="'Questions'"/>
      <router-link to="/write" v-html="'发帖'"/>
      <router-link to="/ask" v-html="'提问'"/>
    </div>
    <router-view/>
  </div>
</template>

<style lang="scss" scoped>
#outer_container {
  flex: 1;
  .nav {
    display: flex;
    flex-flow: row nowrap;
    width: 100%;
    background-color: rgba($color: lightgrey, $alpha: 0.5);
    justify-content: center;
    align-self: center;
    a {
      margin: 0 10px;
      display: block;
      text-decoration: none;
      text-align: center;
      &.router-link-active {
        background-color: #42b983;
        color: #fff;
      }
    }
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import VueRouter from 'vue-router';
import Component from 'vue-class-component';

const innerRouter = new VueRouter({
  routes: [
    {
      path: '/articles',
      component: () => import('@/views/Community/Articles.vue'),
    },
    {
      path: '/questions',
      component: () => import('@/views/Community/Questions.vue'),
    },
    {
      path: '/write',
      component: () => import('@/components/Write.vue'),
      props: {
        post: true,
      },
    },
    {
      path: '/ask',
      component: () => import('@/components/Write.vue'),
      props: {
        question: true,
      },
    },
  ],
});

@Component({
  router: innerRouter,
})
export default class Community extends Vue {}
</script>
