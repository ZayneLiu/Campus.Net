<template>
  <div id="profile">
    <div class="profile_heading">
      <main>
        <div id="avatar_social">
          <div id="-avatar">avatar</div>
          <!-- <div id="-social">
            <i aria-hidden="true" class="fa fa-weixin"></i>
            <i aria-hidden="true" class="fa fa-weibo"></i>
            <i aria-hidden="true" class="fa fa-github"></i>
            <i aria-hidden="true" class="fa fa-linkedin"></i>
          </div>-->
        </div>
        <div id="basic_info">
          <div id="-name">
            <span>ZayneLiu</span>
          </div>
          <div class="-item" id="-award">
            <span>award</span>
          </div>
          <div class="-item" id="-city">
            <Icon size="20" type="ios-flag"/>
            <span>city</span>
          </div>
          <div class="-item" id="-email">
            <Icon size="20" type="ios-mail"/>
            <span @click="edit($event)">email</span>
          </div>
          <div class="-item" id="-major">
            <Icon size="20" type="ios-school"/>
            <span>major</span>
          </div>
        </div>
      </main>
      <div id="-bio">
        <div class="window-title">
          <div class="red dot"></div>
          <div class="yellow dot"></div>
          <div class="green dot"></div>
        </div>
        <p class="content">
          <span class="placeholder">
            这个人很懒，并没有什么想说的...
            <span class="edit-bio">说点什么</span>
          </span>
        </p>
      </div>
    </div>
    <div class="quick-access-panel">
      <div class="social-status">
        <div class="following">
          <span>关注了</span>
          <span>
            <strong>xx 人</strong>
          </span>
        </div>
        <hr>
        <div class="followers">
          <span>被关注</span>
          <strong>xx 人</strong>
        </div>
      </div>
      <router-link class="quick-access-item" to="/profile">我的主页</router-link>
      <router-link class="quick-access-item" to="/profile/my-answers">我的回答</router-link>
      <router-link class="quick-access-item" to="/profile/my-questions">我的提问</router-link>
      <router-link class="quick-access-item" to="/profile/my-watch-list">我关注的</router-link>
    </div>
    <router-view class="profile_body"></router-view>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import axios from 'axios';
import { Dictionary } from 'vue-router/types/router';

@Component({
  components: {},
})
export default class User extends Vue {
  private get user(): any {
    return this.$store.state.user.user;
  }
  public beforeCreate() {
    this.$store.dispatch('getUserInfo', this.$store.state.user.user.email);
  }
  public edit(e: Event) {
    // alert("adf");
    // console.log(e.srcElement);
  }
}
</script>


<style lang="scss" scoped>
#profile {
  display: flex;
  flex-flow: column wrap;
  justify-content: flex-start;
  height: fit-content;
  .profile_heading {
    background-color: #f5f5f5;
    display: flex;
    flex-flow: row nowrap;
    align-self: center;
    width: 100%;
    max-width: 1200px;
    padding: 0 25px;
    height: 300px;
    justify-content: space-around;
    align-items: center;
    main {
      display: flex;
      flex-flow: row nowrap;
      justify-content: space-around;
      width: 380px;
      #avatar_social {
        display: flex;
        flex-flow: column nowrap;
        align-self: center;
        height: fit-content;
        #-avatar {
          color: white;
          line-height: 130px;
          height: 130px;
          width: 130px;
          border-radius: 65px;
          background-color: grey;
        }
        #-social {
          display: flex;
          flex-flow: row nowrap;
          justify-content: center;
          padding: 10px 0 0 0;
          i {
            font-size: large;
            width: 30px;
          }
        }
      }
      #basic_info {
        // @extend .flex, .col;
        display: flex;
        flex-flow: column nowrap;
        height: fit-content;
        justify-self: start;
        .-item {
          margin-top: 5px;
          display: flex;
          flex-flow: row nowrap;
          justify-content: flex-start;
          i {
            width: 30px;
            // height: 30px;
            display: block;
            align-self: center;
          }
          span {
            cursor: pointer;
            padding: 0 10px;
            border-radius: 4px;
          }
          span:hover {
            color: #eeeeee;
            background-color: grey;
          }
        }
        #-name {
          span {
            font-size: xx-large;
          }
          a {
            margin: 0 0 0 15px;
            font-size: small;
            text-decoration: none;
          }
        }
        #-award {
          margin: 10px 0 5px 0;
        }
      }
    }
    #-bio {
      width: 360px;
      height: 250px;
      background-color: #eeeeee;
      border-radius: 5px;
      overflow: hidden;
      .window-title {
        // @extend .flex, .row;
        display: flex;
        flex-flow: row nowrap;
        height: 25px;
        background-color: #e5e5e5;
        justify-content: flex-start;
        align-items: center;
        .dot {
          margin: 0 0 0 5px;
          height: 12px;
          width: 12px;
          border-radius: 100%;
        }
        .red {
          background-color: #e0625b;
        }
        .yellow {
          background-color: #f0c342;
        }
        .green {
          background-color: #79cf50;
        }
      }
      .content {
        padding: 20px 10px;
        .placeholder {
          color: grey;
          .edit-bio {
            cursor: pointer;
            color: #3e76f6;
            text-decoration: underline;
          }
        }
      }
    }
  }
  .quick-access-panel {
    display: flex;
    flex-flow: column nowrap;
    width: 150px;
    .social-status {
      display: flex;
      flex-flow: row nowrap;
      background-color: #f5f5f5;

      padding: 5px 0;
      align-items: center;
      box-shadow: 0 4px 4px #d5d5d5;
      margin: 4px 0 8px 0;
      // shape-outside: padding-box;
      .following,
      .followers {
        padding: 0 10px;
        // text-align: start;
        flex: 1;
        display: flex;
        flex-flow: column nowrap;
      }
      hr {
        height: 30px;
        border: none;
        background-color: #d5d5d5;
        width: 1px;
      }
    }
    .quick-access-item {
      background-color: #f5f5f5;

      width: 100%;
      color: #2c3e50;
      padding: 5px;
      &.router-link-exact-active {
        background-color: grey;
        color: #ffffff;
      }
    }

    // background-color: red;
  }
  .profile_body {
    display: flex;
    flex-flow: column nowrap;
  }
}
</style>

