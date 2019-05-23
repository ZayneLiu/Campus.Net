<template>
  <div>
    <h1>Search Result - {{content}}</h1>
  </div>
</template>

<style lang='scss' scoped>
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
@Component({})
export default class Result extends Vue {
  public get content(): string {
    return this.$route.params.content;
  }

}
</script>