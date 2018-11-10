<template>
  <div class="post_item">
    <div class="upper">
      <div class="upper-left">
        <div class="up">
          <i class="fa fa-caret-up"></i>
          <span>0</span>
        </div>
      </div>
      <div class="upper-right">
        <div class="title">
          <a v-text="post.title + id" href="#">Title</a>
          <span class="type">原创</span>
          <!-- <span class="type">翻译</span> -->
          <!-- <span class="type">搬运</span> -->
        </div>
        <!-- 标签 -->
        <!-- <Tags></Tags> -->
        <Author></Author>
        <p>
          <!-- Content <br /> Content -->
          {{post.contentPeek}}

        </p>
      </div>
    </div>
    <hr />
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
      flex: 9;
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
        margin: 5px 0 5px 0;
        font-size: large;
        text-align: start;
        color: gray;
        overflow: hidden;
        word-wrap: break-word;
        height: 50px;
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
import Author from '@/components/Author.vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';

@Component({
  components: {
    Tags, Author,
  },

  props: [
    'post',
    'id',
  ]
  ,
  data: () => {
    return {
      // post: () => {
      //   // return Prop.arguments.post;
      // },
      // Title: "Title",
    };
    // Title: this.Title
  },
  computed: {
    // peekContent: () => {
    //   // return .post.peekContent.slice(0, 39) + '…';
    // },
  },
})
export default class PostItem extends Vue {
}
</script>
