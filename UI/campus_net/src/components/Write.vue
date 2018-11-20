<template>
  <div id="container">
    <div class="title-field">
      <div v-if="post" id="title-left" @click="name">
        <span>原创</span>
        <i class="fa fa-caret-down"/>
      </div>
      <input class="field" type="text" placeholder="标题：那是我夕阳下的奔跑">
    </div>
    <div class="column-and-tags">
      <select v-if="this.post || this.question" class="field" name="select-column" id="">
        <option v-for="(column, index) in columns" v-bind:key="index" :value="column">{{column}}</option>
      </select>
      <input
        @focus="chooseTags($event)"
        class="field"
        type="text"
        placeholder="标签，如：php（用逗号,分号;分隔）"
      >
    </div>
    <editor/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';
import editor from '@/components/TheMavonEditor.vue';

@Component({
  components: { editor },
})
export default class Write extends Vue {
  @Prop({
    default: false,
    // required: true,
  })
  public post!: boolean;
  @Prop({
    default: false,
    // required: true,
  })
  public question!: boolean;

  constructor() {
    super();
  }
  private get types(): string[] {
    return ['原创', '转载', '翻译'];
  }

  private get columns(): string[] {
    return this.post === true
      ? ['发布专栏（选填）', 'asdf', 'adf']
      : ['提问模版', 'asdf', 'asdf'];
  }

  private name() {
    alert('下拉列表，原创、翻译、转载');
  }

  private chooseTags(e: Event) {
    //
  }
}
</script>

<style lang="scss" scoped>
.field {
  border: 1px solid #c5c5c5;
  border-radius: 4px;
}
#container {
  height: 100%;
  padding: 10px;
  display: flex;
  flex-flow: column nowrap;
  justify-content: flex-start;
  .title-field {
    border: 1px solid #c5c5c5;
    border-radius: 4px;
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
      border-right: 1px solid #c5c5c5;
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
      display: block;
      border: none;
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
      color: grey;
      height: 100%;
    }
    input {
      flex: 5;
      padding: 0 0 0 15px;
      font-size: medium;
    }
  }
}
</style>
