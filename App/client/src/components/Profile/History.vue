<template>
  <div>
    History
    {{questionHistory}}
  </div>
</template>

<style lang='scss' scoped>
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
@Component({})
export default class History extends Vue {
  private get user(): any {
    return this.$store.state.user.user;
  }

  // TODO: user object has question_history, just use it.

  public get questionHistory(): any[] {
    // this.$store.dispatch('getHistory', this.user.email).then((res) => {
    //   console.log(res);
    // });
    return [];
  }

  public mounted() {
    // this.$store.dispatch('getHistory', this.user.email).then((res) => {
    //   console.log(res);
    // });
  }
}
</script>