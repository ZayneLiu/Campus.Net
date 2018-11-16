<template>
  <div class="author">
    <div class="avatar"></div>
    <a href="#">{{author.name}}</a>
    <span>发布于</span>
    <a :href="column.url">{{column.name}}</a>
    <span class="stars" @click="addToFav($event)">
      <i class="fa fa-bookmark"/>
      {{favorites}} 收藏
    </span>
  </div>
</template>

<style lang="scss" scoped>
// :root{

// }
.author {
  margin: 5px 0;
  height: fit-content;
  display: inline-flex;
  flex-flow: row nowrap;
  justify-content: flex-start;
  line-height: 100%;
  font-size: medium;
  .avatar {
    background-color: grey;
    width: 20px;
    height: 20px;
    border-radius: 20px;
  }
  a {
    text-decoration: none;
    align-self: center;
    padding: 0 5px;
    font-size: medium;
  }
  a:hover {
    text-decoration: underline;
  }
  span {
    align-self: center;
    font-size: medium;
    font-weight: 400;
  }
  .stars {
    user-select: none;
    cursor: pointer;
    margin: 0 0 0 3px;
    font-size: small;
    color: grey;
    font-weight: 400;
    i {
      margin: 0 5px 0 2px;
      // align-self: center;
      padding: 3px 0 0 0;
      color: grey;
    }
  }
  .stars:hover {
    text-decoration: underline;
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';
import Author from '@/models/Author';
import Column from '@/models/Column';

@Component
export default class PostInfo extends Vue {
  @Prop()
  public favorites!: number;
  @Prop()
  public column!: Column;
  @Prop()
  public author!: Author;
  // START Author 拆解
  public authorId: string = this.author.id;
  public authorName: string = this.author.name;
  public authorAvatar: string = this.author.avatar;
  public authorUrl: string = this.author.url;
  // END

  // START Column 拆解
  public columnId: string = this.column.id;
  public columnName: string = this.column.name;
  public columnUrl: string = this.column.url;

  // END

  // @Prop()
  // public column!: {
  //   /**
  //    * 专栏URL
  //    */
  //   url: string;
  //   /**
  //    * 专栏名
  //    */
  //   name: string;
  // };

  // public author: string = 'fa';

  /**
   * addToFav
   */
  public addToFav(e: Event) {
    // alert(e);
    this.favorites++;
  }
}
</script>
