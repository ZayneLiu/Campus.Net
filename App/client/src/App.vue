<template>
  <div id="app">
    <div id="header" v-if="this.isLoggedIn">
      <router-link class="logo" tag="div" to="/">
        <span>
          Campus.Net
          <span class="lower">A Q&A Community</span>
        </span>
      </router-link>
      <div class="navbar">
        <div v-show="this.isLoggedIn && this.$route.path !== '/qa/ask'">
          <router-link :key="1" :replace="true" to="/">Home</router-link>
          <router-link :key="2" :replace="true" to="/qa">Q&A</router-link>
          <router-link :key="3" :replace="true" to="/profile">Profile</router-link>
          <router-link :key="4" :replace="true" to="/project">Project</router-link>
        </div>
        <div v-show="this.$route.path === '/qa/ask'">
          <span class="banner-text">Ask Your Question</span>
        </div>
        <!-- <template></template> -->
        <!-- </transition-group> -->
      </div>

      <div class="search-bar" v-if="this.isLoggedIn && this.$route.path !== '/qa/ask'">
        <Icon size="25" type="ios-search" />
        <input @keypress.enter="search()" placeholder="Search..." type="text" v-model="searchContent" />
      </div>

      <div class="create">
        <router-link tag="span" to="/qa/ask" v-if="this.$route.path !== '/qa/ask'">Ask</router-link>
        <span @click="ask" v-else>Ask Away</span>
      </div>
      <div class="notice" v-if="this.$route.path !== '/qa/ask'">
        <Dropdown trigger="hover">
          <div>
            <Icon class="icon" size="40" type="ios-notifications-outline" />
          </div>

          <DropdownMenu slot="list">
            <DropdownItem>驴打滚</DropdownItem>
            <DropdownItem>炸酱面</DropdownItem>
            <DropdownItem>豆汁儿</DropdownItem>
          </DropdownMenu>
        </Dropdown>
      </div>
      <div class="user-panel" v-if="this.$route.path !== '/qa/ask'">
        <div class="avatar"></div>
      </div>
    </div>
    <router-view class="router-view" />
  </div>
</template>


<style lang="scss">
// /* Enter and leave animations can use different */
// /* durations and timing functions.              */
// .slide-fade-enter-active {
//   transition: all 0.3s ease;
// }
// .slide-fade-leave-active {
//   transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
// }
// .slide-fade-enter, .slide-fade-leave-to
// /* .slide-fade-leave-active below version 2.1.8 */ {
//   transform: translateX(10px);
//   opacity: 0;
// }
</style>


<style lang="scss">
* {
  transition: all ease-in-out 0.2s;
}
body {
  padding: 0;
  margin: 0;
}
// Here are the variables to cover, such as:
p {
  font-size: medium;
  font-weight: 400;
}

#app {
  display: flex;
  flex-flow: column nowrap;
  font-size: medium;
  max-width: 1200px;
  min-width: 800px;
  min-height: 100vh;
  margin: auto;
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

  #header {
    height: 80px;
    display: flex;
    flex-flow: row nowrap;
    justify-content: flex-start;
    align-items: center;
    border-bottom: #2c3e50 1px solid;
    .logo {
      cursor: pointer;
      align-self: flex-start;
      user-select: none;
      padding: 10px;
      background: url('./assets/atom-icon.svg');
      background-size: 60px 60px;
      background-position: center left 10px;
      background-repeat: no-repeat;
      height: 80px;
      display: flex;
      flex-flow: row nowrap;
      justify-content: flex-start;
      align-items: center;

      span {
        padding: 0 10px;
        display: inline-flex;
        flex-flow: column nowrap;
        margin-left: 60px;
        font-size: x-large;
        font-weight: 500;
        .lower {
          font-size: small;
          font-weight: normal;
          margin: 0;
        }
      }
    }
    .navbar {
      display: flex;
      flex-flow: row nowrap;
      justify-content: flex-start;
      align-items: center;
      padding: 0 10px;
      height: 100px;
      a {
        transition: all ease-in-out 0.3s;
        margin: 0 5px;
        color: #2c3e50;
        border-radius: 40px;
        font-size: large;
        font-weight: 500;
        padding: 10px 20px;
        &.router-link-exact-active {
          background-color: rgba($color: #808080, $alpha: 0.8);
          transition: all ease-in-out 0.3s;
          margin-top: 10px;
          color: #ffffff;
        }
      }
      .banner-text {
        font-size: large;
        font-weight: 500;
      }
    }
    .search-bar {
      margin: 0 10px;
      padding: 2px 10px;
      border: 1px solid lightgray;
      border-radius: 24px;
      overflow: hidden;
      display: flex;
      flex-flow: row nowrap;
      align-items: center;

      input {
        outline: none;
        border: none;
        height: 36px;
        width: 180px;
        font-size: medium;
        padding-left: 10px;
      }
      &:hover {
        box-shadow: 1px 2px 2px #e3e3e3, -1px -1px 2px #e3e3e3;
      }
    }
    .create {
      margin-left: auto;
      height: 100%;
      display: flex;
      flex-flow: column nowrap;
      justify-content: center;
      padding: 0 15px;
      span {
        cursor: pointer;
        border: 1px solid grey;
        padding: 5px 15px;
        border-radius: 4px;
        &:hover {
          background-color: grey;
          color: #ffffff;
          font-weight: 500;
          // font-weight: 600;
        }
      }
    }
    .notice {
      padding: 0 5px;
      border-radius: 20px;
      cursor: pointer;
      // background-clip: content-box;
      color: #808080;
      &:hover {
        background-color: rgba($color: #808080, $alpha: 0.1);
      }
    }
    .user-panel {
      padding: 10px;
      display: flex;
      flex-flow: row nowrap;
      align-items: center;

      .avatar {
        width: 50px;
        height: 50px;
        border-radius: 30px;
        background-color: grey;
        margin: 0 5px;
      }
    }
  }
  .router-view {
    max-width: 1200px;
    width: 100%;
    align-self: center;
    min-height: calc(100vh - 100px);
  }
}
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';

@Component({})
export default class App extends Vue {
  public searchContent: string = '';

  public search() {
    this.$router.replace('/result/' + this.searchContent);
  }

  public ask() {
    this.$EventBus.$emit('ask-question');
  }

  public get isLoggedIn(): boolean {
    return this.$store.state.user.isLoggedIn;
  }

  public beforeMount() {
    if (!this.$store.state.user.isLoggedIn) {
      if (
        !(this.$route.path === '/login' || this.$route.path === '/register')
      ) {
        this.$router.replace('/login');
      }
    } else {
      //
    }
  }
}
</script>
