<template>
  <div id="outer_container">
    <div id="register_form">
      <div class="text_above">注册</div>
      <hr>
      <div id="form_body_wrapper">
        <div class="field">
          <label for="name">学号</label>
          <input
            v-model="user.scid"
            @blur="scidValidator($event)"
            name="scid"
            type="text"
            placeholder="SCID"
          >
        </div>
        <div class="field">
          <label for="name">用户名</label>
          <input
            v-model="user.username"
            @blur="usernameValidator($event)"
            name="username"
            type="text"
            placeholder="Username"
          >
          <!-- 昵称字母开头，不能以数字开头，可以中文 -->
        </div>
        <div class="field">
          <label for="password">密码</label>
          <input
            v-model="user.pwd"
            @blur="pwdValidator($event)"
            name="password"
            type="password"
            placeholder="Password"
          >
        </div>
        <div class="field">
          <label for="password_again">再次输入密码</label>
          <input
            v-model="pwdAgain"
            @blur="pwdValidator"
            name="password_again"
            type="password"
            placeholder="Password Again"
          >
        </div>
        <ul id="error_list">
          <li v-for="(error, name, index) in formError" :key="index" v-if="error.flag">
            {{error.description.zh_CN}}
            <br>
            {{error.description.en_US}}
          </li>
        </ul>
        <hr>
        <div class="btn_group">
          <button class="btn_primary">Register</button>
          <button class="btn_common">Back</button>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang='scss' scoped>
#outer_container {
  @import url('../../public/form.css');
  width: 100%;
  // height: fit-content;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  #register_form {
    padding: 25px 100px;
    border-radius: 4px;
    border: #dddddd 1px solid;
    .text_above {
      font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS',
        sans-serif;
      margin-bottom: 15px;
      font-size: 25px;
    }
    > hr {
      width: 70%;
      height: 1px;
      border-left: none;
      border-right: none;
      border-bottom: none;
      border-top: 1px #eeeeee solid;
    }
    #form_body_wrapper {
      margin-top: 20px;
      width: 400px;
      margin-left: auto;
      margin-right: auto;
      background-color: #fff;
      hr {
        width: 100%;
        height: 1px;
        border-left: none;
        border-right: none;
        border-bottom: none;
        border-top: 1px #eeeeee solid;
      }
      #error_list {
        li {
          // height: 40px;
          // line-height: 20px;
          // display: inline-flex;
          // flex-flow: row wrap;
          text-align: start;
          color: var(--color-danger);
        }
      }
    }
  }
}
</style>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import { Prop } from 'vue-property-decorator';
@Component({})
export default class Register extends Vue {
  private pwdAgain = null;
  private formError = {
    scidInvalid: {
      flag: false,
      description: { en_US: 'SCID Invalid', zh_CN: '学号不存在或已绑定账号' },
    },
    passwordMismatch: {
      flag: false,
      description: { en_US: 'Passwords Mismatch', zh_CN: '两次输入密码不一致' },
    },
    usernameInvalid: {
      flag: false,
      description: { en_US: 'Username Invalid', zh_CN: '用户名非法' },
    },
  };
  private user = {
    scid: null,
    username: null,
    pwd: null,
  };
  private scidValidator(e: any) {
    // console.log(e.srcElement);
  }
  private usernameValidator(e: any) {
    // console.log(e.srcElement);
    const name = this.user.username;
    if (name != null) {
      // 验证用户名
      // console.log(name);
    }
  }
  private pwdValidator(e: any) {
    if (this.user.pwd != null && this.pwdAgain != null) {
      const pwd = this.user.pwd;
      const pwdAgain = this.pwdAgain;
      // Password Mismatch
      if (!(pwd === pwdAgain)) {
        // Toggle pwdMismatch flag
        this.formError.passwordMismatch.flag = true;
        // Toggle source element's border color
        e.srcElement.style.borderColor = 'var(--color-danger)';
      } else {
        // Toggle pwdMismatch flag
        this.formError.passwordMismatch.flag = false;
        // Toggle source element's border color
        e.srcElement.style.borderColor = null;
      }
    }
  }
}
</script>