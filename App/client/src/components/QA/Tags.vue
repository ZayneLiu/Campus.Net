<template>
  <div class="tags">
    <a :href="tag.url" :html="tag.name" :key="index" class="tag" v-for="(tag,index) in tags"/>
    <a class="tag" href="#">Database</a>
    <a class="tag" href="#">Flask</a>
    <a class="tag" href="#">Web</a>
  </div>
</template>

<style lang='scss' scoped>
.tags {
  height: 20px;
  user-select: none;
  background-color: #fff;
  // width: 100%;
  margin: 0;
  padding: 0;
  display: inline-flex;
  justify-content: flex-start;
  border: 0;
  .tag {
    border-radius: 4px;
    text-decoration: none;
    margin: 0 10px 0 0;

    padding: 0 10px;
    font-size: small;
    display: block;
    border: 1px #d1d1d1 solid;
    color: #fff;
    // border-radius: 2px;
    background-color: gray;
  }
  .tag:hover {
    color: gray;
    background-color: #fff;
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';

@Component({})
export default class Tags extends Vue {
  @Prop({
    required: true,
    default: [],
  })
  public tags!: any[];
}
</script>


