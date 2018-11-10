<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link>
      <router-link to="/about">About</router-link>
      <router-link to="/login">Login</router-link>
      <router-link to="/register">Register</router-link>
    </div>
    <router-view />
  </div>
</template>

<style lang="scss">
:root {
  --color-danger: #f36061;
}
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  background-color: rgba($color: lightgrey, $alpha: 0.5);
  line-height: 50px;
  height: 50px;
  display: flex;
  flex-flow: row nowrap;
  justify-content: space-evenly;
  // padding: 30px;
  a {
    flex: 1;
    text-decoration: none;
    font-weight: bold;
    color: #2c3e50;
    &.router-link-exact-active {
      background-color: #42b983;
      color: #fff;
    }
  }
}
</style>
