<template>
  <div id="outer_container">
    <div class="nav">
      <router-link to="/posts">专栏</router-link>
      <router-link to="/qas">Q&amp;A</router-link>
      <router-link to="/write">发帖</router-link>
      <router-link to="/ask">提问</router-link>
    </div>
    <router-view></router-view>
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
      path: '/posts',
      component: () => import('@/views/Community/Posts.vue'),
    },
    {
      path: '/qas',
      component: () => import('@/views/Community/QAs.vue'),
    },
    {
      path: '/write',
      component: () => import('@/components/Write.vue'),
    },
    // { path: '/community/ask', component: () => import('@/views/Ask.vue') },
  ],
});

@Component({
  router: innerRouter,
})
export default class Community extends Vue {}
</script>
