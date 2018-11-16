<template>
    <div id="wrapper">
        <Login></Login>
    </div>
</template>

<style lang="scss" scoped>
#wrapper {
  display: flex;
  height: 100%;
  flex-flow: column nowrap;
  justify-content: center;
  //   align-items: center;
}
</style>


<script lang="ts">
import Vue from 'vue';
import Login from '@/components/Login.vue';
import Component from 'vue-class-component';

@Component({
  components: {
    Login,
  },
})
export default class User extends Vue {}
</script>

