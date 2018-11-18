<template>
  <div id="container">
    <div class="title-field">
      <div id="title-left" @click="name">
        <span>原创</span>
        <i class="fa fa-caret-down"/>
      </div>
      <!-- <div id="title-right"> -->
      <input class="field" type="text" placeholder="标题：那是我夕阳下的奔跑">
      <!-- </div> -->
    </div>
    <div class="column-and-tags">
      <select class="field" name="select-column" id="">
        <!-- <optgroup label=""> -->
        <option v-for="(column, index) in columns" v-bind:key="index" :value="column">{{column}}</option>
        <!-- </optgroup> -->
      </select>
      <input
        @focus="chooseTags($event)"
        class="field"
        type="text"
        placeholder="标签，如：php（用逗号,分号;分隔）"
      >
    </div>
    <div id="editor" class="field">
      <textarea name="" id="" cols="30" rows="10"></textarea>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.field {
  border: 1px solid #c5c5c5;
  border-radius: 4px;
}
#container {
  height: 100%;
  padding: 10px;
  // background-color: #000;
  display: flex;
  flex-flow: column nowrap;
  justify-content: flex-start;
  .title-field {
    user-select: none;
    cursor: pointer;
    padding: 0;
    margin: 0 0 10px 0;
    height: 45px;
    display: flex;
    flex-flow: row nowrap;
    align-items: center;
    // 标题栏左侧下拉
    #title-left {
      width: 60px;
      margin: 0;
      height: 100%;
      align-self: center;
      padding: 0 15px;
      cursor: pointer;
      border: 1px solid #c5c5c5;
      border-right: none;
      border-radius: 4px 0 0 4px;
      font-size: large;
      line-height: 45px;
      span {
        padding: 0 5px 0 0;
      }
    }
    #left:hover {
      background-color: #dddddd;
    }
    // #title-right {
    input {
      flex: 1;
      display: block;
      margin: 0;
      padding: 0;
      // flex: 1;
      display: block;
      border: 1px solid #c5c5c5;
      border-radius: 0 4px 4px 0;
      font-size: large;
      line-height: 45px;
      padding: 0 0 0 15px;
      margin: 0;
    }
    // }
  }
  .column-and-tags {
    width: 100%;
    display: flex;
    height: 40px;
    select {
      flex: 1;
      width: 60px;
      margin: 0 10px 0 0;
      height: 100%;
      align-self: center;
      padding: 0 15px;
      cursor: pointer;
      font-size: medium;
      border: 1px solid #c5c5c5;
      background-color: #fff;
      height: 100%;
    }
    input {
      flex: 5;
      padding: 0 0 0 15px;
      font-size: medium;
    }
  }
  #editor {
    margin-top: 10px;
    display: block;
    padding: 0;
    width: 100%;
    height: 600px;
    textarea {
      height: 100%;
      width: 100%;
      font-size: medium;
    }
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';

@Component({})
export default class Write extends Vue {
  constructor() {
    super();
  }
  private get types(): string[] {
    return ['原创', '转载', '翻译'];
  }

  private get columns(): string[] {
    return ['adf', 'asdf', 'adf'];
  }

  private name() {
    alert('下拉列表，原创、翻译、转载');
  }

  private chooseTags(e: Event) {
    // console.log( '选择标签' );
    // return;
  }
}
</script>
