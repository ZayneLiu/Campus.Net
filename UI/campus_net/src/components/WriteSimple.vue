<template>
  <div class="write-item">
    <div class="upper">
      <select id name>
        <option value>原创</option>
        <option value>转载</option>
        <option value>翻译</option>
      </select>
      <input placeholder="Title" type="text" v-model="title">
      <input placeholder="Column" type="text">
      <input placeholder="Tags" type="text">
      <button @click="publish($event)">发布</button>
    </div>

    <textarea cols="30" id name rows="10" v-model="content"></textarea>
  </div>
</template>

<style lang="scss" scoped>
.write-item {
  max-width: 100%;
  padding: 5px;
  display: flex;
  flex-flow: column nowrap;
  // cross axis alignment
  align-items: center;
  // main axis alignment
  justify-content: center;
  .upper {
    input {
      border: 1px solid #c5c5c5;
      border-radius: 4px;
      padding-left: 5px;
      height: 20px;
    }
  }
  textarea {
    border: 1px solid #c5c5c5;
    border-radius: 4px;
    // max-width: calc(100% - 10px);
    width: calc(100% - 10px);
    font-size: medium;
    resize: none;
  }
}
</style>


<script lang="ts">
import Vue from 'vue';
import { Prop, Component } from 'vue-property-decorator';

@Component({
  data() {
    return {
      content: '',
    };
  },
})
export default class WriteSimple extends Vue {
  public title: string = '';
  public content: string = '';
  public type: string = '';

  private publish(e: MouseEvent) {
    console.log(e ? e.srcElement : e);
  }
}
</script>
