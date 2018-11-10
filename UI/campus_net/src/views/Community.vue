<template>
    <div id="outer_container">
        <div class="nav">
            <router-link to="/community/post">专栏</router-link>
            <router-link to="/community/qa">Q&amp;A</router-link>
            <router-link to="/community/write">发帖</router-link>
            <router-link to="/community/ask">提问</router-link>

        </div>
        <router-view>
        </router-view>
    </div>
</template>

<style lang="scss" scoped>
#outer_container {
  //   width: 100%;

  .nav {
    display: flex;
    flex-flow: row nowrap;
    width: 100%;
    background-color: rgba($color: lightgrey, $alpha: 0.5);
    justify-content: center;
    line-height: 100%;
    a {
      margin: 0 10px;
      display: block;
      height: 30px;
      text-decoration: none;
    }
    // .btn {
    // }
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import VueRouter from 'vue-router';
import Component from 'vue-class-component';

const innerRouter = new VueRouter({
    routes: [
        { path: '/community/post', component: () => import('@/views/Post.vue') },
        { path: '/community/qa', component: () => import('@/views/QA.vue') },
        // { path: '/community/write', component: () => import('@/views/Write.vue') },
        // { path: '/community/ask', component: () => import('@/views/Ask.vue') },
    ],
});
@Component({
    router: innerRouter,
})
export default class Community extends Vue {

}
</script>
