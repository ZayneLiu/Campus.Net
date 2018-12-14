<template>
  <div id="outer_container">
    <div id="login_form">
      <div class="text_above">Welcome to
        <br>
        <span>campus.net</span>
      </div>
      <hr>
      <div id="form_body_wrapper">
        <div class="field">
          <label for="username">学号 或 Email</label>
          <input
            id="login"
            name="login"
            placeholder="SCID or Email"
            type="text"
            v-model.trim="form.login"
          >
        </div>
        <div class="field">
          <label for="password">密码</label>
          <input
            id="password"
            name="password"
            placeholder="Password"
            type="password"
            v-model.trim="form.password"
          >
        </div>
        <ul>
          <li v-if="!($v.form.login.email || $v.form.login.numeric)">
            <span>Invalid SCID or Email</span>
          </li>
          <!-- <li v-if="formEmpty">
            <span>Empty form, please fill the form above.</span>
          </li>-->
        </ul>
        <div class="btn_group">
          <button
            :class="'btn_primary'"
            :disabled="!($v.form.login.email || $v.form.login.numeric)"
            @click="login"
          >Submit</button>
          <hr>
          <button :class="'btn_common'" @click="account_recovery">Forget</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang='ts'>
import Vue from 'vue';
import { Prop, Component } from 'vue-property-decorator';
import store from '@/store';
import axios from 'axios';
import { helpers, email, numeric } from 'vuelidate/lib/validators';
import Vuelidate from 'vuelidate';
import { Dictionary } from 'vue-router/types/router';

@Component({
  validations: {
    form: {
      login: {
        email,
        numeric,
      },
    },
  },
})
export default class Login extends Vue {
  public loginNotValid: boolean = false;
  private form = {
    login: '',
    password: '',
  };
  private formEmpty: boolean = false;
  mounted() {
    console.log('mounted');
    console.log(sessionStorage.getItem('currentUser'));
  }

  private account_recovery() {
    //   账号找回
  }
  private login() {
    // // 初始化登陆结果
    // const result = {
    //   result: 'ERROR',
    //   userId: '',
    // };
    // 判断输入是否为空
    this.formEmpty = this.form.login === '' || this.form.password === '';
    if (this.formEmpty) {
      alert('Empty form, please fill the login form.');
      return;
    }
    // login 验证对象
    const loginV = this.$v.form.login;
    // login 验证非空
    if (loginV) {
      // 判断 Login 信息是否合法
      this.loginNotValid = !(loginV.email || loginV.numeric);
      if (this.loginNotValid) {
        console.log('Login Not Valid');
        return;
      }
      // 重构 form Json
      const form = loginV.email
        ? {
            email: this.form.login,
            password: this.form.password,
          }
        : {
            scid: this.form.login,
            password: this.form.password,
          };

      // 转发POST请求到API服务器
      axios({
        method: 'post',
        url: 'https://localhost:5001/api/users/login',
        responseType: 'application/json',
        data: form,
      }).then((response) => {
        // 登陆成功，从服务器返回 登陆结果 和 UserID
        const result: Dictionary<string> = response.data;
        // console.log(response.data);
        if (response.data != null) {
          sessionStorage.setItem('currentUser', result['id']);
          console.log(result['id']);
          this.$router.push('/user/');
          // 登陆成功 用 vuex 向 session 中存储 user
          // this.$store.commit('login', result);
          // 从session 中获取 当前用户 userId
          // console.log(sessionStorage.getItem('currentUserId'));
          // this.$store.dispatch('login');
        }
      });
    }

    // 从服务器获取用户名后
  }
}
</script>

<style lang="scss" scoped>
#outer_container {
  @import url('../../public/form.css');
  min-height: 100vh;
  // height: 100%;
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
      font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS',
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
      ul {
        padding: 0 0 0 20px;
        margin: 10px 0 0 0;
        li {
          color: var(--color-danger);
          text-align: left;
        }
      }
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