<template>
  <div id="outer_container">
    <div id="root">
      <main id="main">
        <ul>
          <li v-for="(post, index) in posts" v-bind:key="index">
            <PostItem v-bind:post="post" v-bind:id="index" />
          </li>
        </ul>
      </main>
      <aside id="right">Right Side</aside>
    </div>
  </div>
</template>
<style lang="scss" scoped>
#outer_container {
  display: flex;
  justify-content: center;
  #root {
    width: 1200px;
    display: flex;
    flex-flow: row nowrap;
    padding: 10px 0 0 0;
    // background-color: lightgrey;
    #left {
      padding: 10px 0 0 0;
      flex: 2;
      background-color: grey;
    }
    #main {
      flex: 3;
      ul {
        list-style: none;
        padding: 0;
        margin: 0;
        li {
          margin: 0 0 15px 0;
          padding: 0 10px;
        }
      }
    }
    #right {
      flex: 1;
    }
  }
}
</style>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import PostItem from "@/components/PostItem.vue";
import { Prop } from "vue-property-decorator";

// const PostItem = {
//     template: () => import('./PostItem.vue'),
// };

@Component({
  components: {
    PostItem
  },
  data: () => {
    return {
      posts: [
        {
          title: "Title",
          // 缩略内容 获取时注意
          contentPeek:
            "Pellentesque faucibus accumsan nibh, in placerat urna. Aliquam nec cursus sem. Duis sollicitudin ligula sit amet faucibus condimentum. Aliquam rhoncus tincidunt auctor. Vestibulum quis tristique urna, nec convallis velit. Sed in est maximus, sollicitudin enim at, sollicitudin erat. Aenean imperdiet tempus massa ut fermentum."
        },
        {
          title: "Title",
          // 缩略内容 获取时注意
          contentPeek:
            "asdffasdfmsan nibh, in placerat urna. Aliquam nec cursus sem. Duis sollicitudin ligula sit amet faucibus condimentum. Aliquam rhoncus tincidunt auctor. Vestibulum quis tristique urna, nec convallis velit. Sed in est maximus, sollicitudin enim at, sollicitudin erat. Aenean imperdiet tempus massa ut fermentum."
        },
        {
          title: "Title",
          contentPeek:
            "Pellentesque faucibus accumsan nibh, in placerat urna. Aliquam nec cursus sem. Duis sollicitudin ligula sit amet faucibus condimentum. Aliquam rhoncus tincidunt auctor. Vestibulum quis tristique"
        },
        {
          title: "Title",
          contentPeek:
            "Pellentesque faucibus accumsan nibh, in placerat urna. Aliquam nec cursus sem. Duis sollicitudin ligula sit amet faucibus condimentum. Aliquam rhoncus tincidunt auctor. Vestibulum quis tristique urna, nec convallis velit. Sed in est maximus, sollicitudin enim at, sollicitudin erat. Aenean imperdiet tempus massa ut fermentum."
        }
      ]
    };
  }
})
export default class Post extends Vue {}
</script>
