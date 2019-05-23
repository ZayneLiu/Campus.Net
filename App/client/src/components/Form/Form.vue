<template>
  <form>
      <slot></slot>
  </form>
</template>

<style lang='scss' scoped>
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
@Component({})
export default class Form extends Vue { }
</script>