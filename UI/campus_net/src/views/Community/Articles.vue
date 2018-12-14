<template>
  <div id="outer_container">
    <div id="root">
      <main id="main">
        <ul>
          <li v-bind:key="index" v-for="(post, index) in posts">
            <ThePostItem :post="post"/>
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
  height: 100%;
  #root {
    width: 1200px;
    display: flex;
    flex-flow: row nowrap;
    padding: 10px 0 0 0;
    #left {
      padding: 10px 0 0 0;
      width: 400px;
      background-color: grey;
    }
    #main {
      width: 900px;
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
import Vue from 'vue';
import Component from 'vue-class-component';
import TheArticleItem from '@/components/TheArticleItem.vue';
import { Prop } from 'vue-property-decorator';
import PostModel from '@/models/Post.ts';

@Component({
  components: {
    TheArticleItem,
  },
})
export default class Articles extends Vue {
  get posts() {
    return [
      new PostModel().createPost(
        'titleqwer',
        '原创',
        {
          id: 'author_id',
          url: 'profile_url',
          name: 'username',
          avatar: 'avatar_url',
        },
        'content',
        0,
        0,
        {
          id: 'column_id',
          name: 'column_name',
          url: 'column_url',
        },
        [{ id: 'tag_id', name: 'tag_name', url: 'tag_url' }],
      ),
      new PostModel().createPost(
        'title',
        '原创',
        {
          id: 'author_id',
          url: 'profile_url',
          name: 'username',
          avatar: 'avatar_url',
        },
        'Lorem ipsum dolor sit  elit. Etiam gravida lorem eu urna vehicula luctus. Etiam lectus amet.',
        0,
        0,
        {
          id: 'column_id',
          name: 'column_name',
          url: 'column_url',
        },
        [{ id: 'tag_id', name: 'tag_name', url: 'tag_url' }],
      ),
      new PostModel().createPost(
        'title',
        '原创',
        {
          id: 'author_id',
          url: 'profile_url',
          name: 'username',
          avatar: 'avatar_url',
        },
        'Loremasfd amet, consecluctus. Etiam lectus amet.',
        0,
        0,
        {
          id: 'column_id',
          name: 'column_name',
          url: 'column_url',
        },
        [{ id: 'tag_id', name: 'tag_name', url: 'tag_url' }],
      ),
      new PostModel().createPost(
        'title',
        '原创',
        {
          id: 'author_id',
          url: 'profile_url',
          name: 'username',
          avatar: 'avatar_url',
        },
        'Lorem dipiscing elit. Etiam gravida lorem eu urna vehicula luctus. Etiam lectus amet.',
        0,
        0,
        {
          id: 'column_id',
          name: 'column_name',
          url: 'column_url',
        },
        [{ id: 'tag_id', name: 'tag_name', url: 'tag_url' }],
      ),
      new PostModel().createPost(
        'title',
        '原创',
        {
          id: 'author_id',
          url: 'profile_url',
          name: 'username',
          avatar: 'avatar_url',
        },
        'Lorem ipsuing elit. Etiam gravida lorem eu urna vehicula luctus. Etiam lectus amet.',
        0,
        0,
        {
          id: 'column_id',
          name: 'column_name',
          url: 'column_url',
        },
        [{ id: 'tag_id', name: 'tag_name', url: 'tag_url' }],
      ),
    ];
  }

  constructor() {
    super();
  }
}
</script>
