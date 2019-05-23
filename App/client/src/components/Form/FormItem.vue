<template>
  <div>
    <slot></slot>
    <!-- <transition></transition> -->
  </div>
</template>

<style lang='scss' scoped>
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
@Component({})
export default class FormItem extends Vue { }
</script>