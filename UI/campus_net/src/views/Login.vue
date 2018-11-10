<template>
  <div id="outer_container">
      <div id="login_form">
          <div class="text_above">Welcome to<br/><span>campus.net</span></div>
          <hr/>
          <div id="form_body_wrapper">
              <div class="field">
                  <label for="username">学号 或 Email</label>
                  <input type="text" name="username" v-model="user.username" id="username" placeholder="Username">
              </div>
              <div class="field">
                  <label for="password">密码</label>
                  <input type="password" name="password" v-model="user.password" id="password" placeholder="Password">
              </div>
              <div class="btn_group">
                  <button class="btn_primary" @click="forward_post" value="new User('asd','asd')">Submit</button>
                  <hr/>
                  <button class="btn_common" @click="account_recovery" value="new User('asd','asd')">Forget</button>
              </div>
          </div>
      </div>
  </div>
</template>

<style lang="scss" scoped>
#outer_container {
  @import url("../../public/form.css");
  height: calc(100vh - 50px);
  min-height: 500px;
  width: 100%;
  display: flex;
  flex-flow: column;
  justify-content: center;
  align-items: center;
  #login_form {
    padding: 25px;
    display: flex;
    flex-flow: column nowrap;
    justify-content: center;
    // align-items: center;
    width: 600px;
    // height: calc(100%-50px);
    border: #dddddd 1px solid;
    border-radius: 4px;
    //   background-color: grey;

    // CENTER !!!????
    // margin-left: auto;
    // margin-right: auto;
    // CENTER END
    .text_above {
      font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS",
        sans-serif;
      margin-bottom: 15px;
      font-size: 25px;
      span {
        font-size: 50px;
        font-weight: 600;
      }
    }
    > hr {
      width: 60%;
      height: 1px;
      border-left: none;
      border-right: none;
      border-bottom: none;
      border-top: 1px #eeeeee solid;
    }
    #form_body_wrapper {
      margin-top: 20px;
      width: 300px;
      margin-left: auto;
      margin-right: auto;
      background-color: #fff;
      .btn_group {
        hr {
          width: 100%;
          height: 1px;
          border-left: none;
          border-right: none;
          border-bottom: none;
          border-top: 1px #eeeeee solid;
        }
      }
    }
  }
}
</style>

<script lang='ts'>
import Vue from 'vue';
import { Prop, Component } from 'vue-property-decorator';
//     class User {
//     /**
//      *    用户类，登录用
//      */
//     public username: string;
//     public password: string;
//     constructor(username: string, password: string) {
//         this.username = username;
//         this.password = password;
//     }
// }

@Component
export default class Login extends Vue {
  private user = {
    username: '',
    password: '',
  };
  private account_recovery() {
    //   账号找回
  }
  private forward_post() {
    //   转发POST请求到API服务器
    const user = this.user;
    // console.log({
    //   username: user.username,
    //   pwd: user.password,
    // });
    // console.log(user);
  }
}
</script>