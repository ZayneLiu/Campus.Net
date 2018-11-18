<template>
  <div class="post_item">
    <div class="upper">
      <div class="upper-left">
        <div class="up" @click="approve($event)">
          <i class="fa fa-caret-up"></i>
          <span>{{approvals}}</span>
        </div>
      </div>
      <div class="upper-right">
        <div class="title">
          <a v-text="post.title" href="#">Title</a>
          <span class="type">{{type}}</span>
        </div>
        <!-- 标签 -->
        <PostInfo :favorites="favorites" :author="post.author" :column="post.column"></PostInfo>
        <p v-html="thumbnailContent"></p>
      </div>
    </div>
    <hr>
  </div>
</template>

<style lang="scss" scoped>
.post_item {
  display: flex;
  flex-flow: column nowrap;
  justify-content: flex-start;
  .upper {
    justify-content: flex-start;
    display: flex;
    flex-flow: row nowrap;
    .upper-left {
      flex: 1;
      background-color: #fff;
      display: flex;
      flex-flow: column nowrap;
      justify-content: flex-start;
      .up {
        display: flex;
        flex-flow: column nowrap;
        justify-content: flex-start;
        align-self: center;
        border: 1px #d1d1d1 solid;
        border-radius: 4px;
        cursor: pointer;
        width: 40px;
        height: 45px;
        color: grey;
        user-select: none;
        transition: ease-in-out 0.1s;
      }
      .up:hover {
        background-color: grey;
        color: #fff;
      }
    }
    .upper-right {
      width: 90%;
      display: flex;
      flex-flow: column nowrap;
      justify-content: flex-start;
      .title {
        display: inline-flex;
        flex-flow: row nowrap;
        justify-content: flex-start;
        align-items: center;
        a {
          color: #000;
          text-decoration: none;
          margin: 0;
          text-align: start;
          font-size: x-large;
          font-weight: 500;
        }
        a:hover {
          text-decoration: underline grey;
        }
        .type {
          margin: 0 0 0 15px;
          display: block;
          background-color: gray;
          border-radius: 4px;
          font-size: small;
          font-weight: 300;
          color: #fff;
          padding: 0 5px;
          user-select: none;
        }
      }
      p {
        width: 100%;
        margin: 5px 0 5px 0;
        font-size: large;
        text-align: start;
        color: gray;
        overflow: hidden;
        word-wrap: break-word;
        text-overflow: ellipsis;
        height: 50px;
        line-height: 25px;
      }
    }
  }
  hr {
    border-top: 1px #d1d1d1 solid;
    border-bottom: 0;
    border-left: 0;
    border-right: 0;
    width: 100%;
    margin: 15px 0 0 0;
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import Tags from '@/components/Tags.vue';
import PostInfo from '@/components/PostInfo.vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';
import { Dictionary } from 'vue-router/types/router';
import PostModel from '@/models/Post.ts';
import Author from '@/models/Author';
import Tag from '@/models/Tag';
import Column from '@/models/Column';

@Component({
  components: {
    Tags,
    PostInfo,
  },
})
export default class ThePostItem extends Vue {
  @Prop()
  public post!: PostModel;
  public title: string = this.post.title;
  public type: string = this.post.type;
  public author: Author = this.post.author;
  public content: string = this.post.content;
  public column: Column = this.post.column;
  public tags: Tag[] = this.post.tags;
  public favorites: number = this.post.favorites;
  public approvals: number = this.post.approvals;
  public thumbnailContent: string = this.post.content.slice(0, 150) + '...';
  constructor() {
    super();
  }

  public approve(e: Event) {
    this.approvals += 1;
  }
}
</script>
