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
            v-model.trim="form.login"
            type="text"
            name="login"
            id="login"
            placeholder="SCID or Email"
          >
        </div>
        <div class="field">
          <label for="password">密码</label>
          <input
            v-model.trim="form.password"
            type="password"
            name="password"
            id="password"
            placeholder="Password"
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
            :disabled="!($v.form.login.email || $v.form.login.numeric)"
            :class="'btn_primary'"
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
import Vue from "vue";
import { Prop, Component } from "vue-property-decorator";
import store from "@/store";
import axios from "axios";
import { helpers, email, numeric } from "vuelidate/lib/validators";
import Vuelidate from "vuelidate";

@Component({
  validations: {
    form: {
      login: {
        email,
        numeric
      }
    }
  }
})
export default class Login extends Vue {
  private form = {
    login: "",
    password: ""
  };
  private formEmpty: boolean = false;
  public loginNotValid: Boolean = false;

  private account_recovery() {
    //   账号找回
  }
  private login() {
    // 初始化登陆结果
    var result = {
      result: "ERROR",
      userId: ""
    };
    // 判断输入是否为空
    this.formEmpty = this.form.login === "" || this.form.password === "";
    if (this.formEmpty) {
      alert("Empty form, please fill the login form.");
      return;
    }
    // login 验证对象
    const login_v = this.$v.form.login;
    // login 验证非空
    if (login_v) {
      // 判断 Login 信息是否合法
      this.loginNotValid = !(login_v.email || login_v.numeric);
      if (this.loginNotValid) {
        console.log("Login Not Valid");
        return;
      }
      // 重构 form Json
      const form = login_v.email
        ? {
            email: this.form.login,
            password: this.form.password
          }
        : {
            scid: this.form.login,
            password: this.form.password
          };

      // 转发POST请求到API服务器
      axios({
        method: "post",
        url: "https://localhost:5001/api/users/login",
        responseType: "application/text",
        data: form
      }).then(response => {
        // 登陆成功，从服务器返回 登陆结果 和 UserID
        result = {
          result: response.data["result"],
          userId: response.data["user"]
        };
        console.log(result);
        // console.log(result.userId);
        if (result.result == "LOGIN SUCCEEDED") {
          // 登陆成功 用 vuex 向 session 中存储 userId
          this.$store.commit(
            "login",
            result.userId === null ? null : result.userId
          );
          // 从session 中获取 当前用户 userId
          console.log(sessionStorage.getItem("currentUserId"));
        }
      });
    }

    // 从服务器获取用户名后
    // this.$store.dispatch('login');
  }
}
</script>

<style lang="scss" scoped>
#outer_container {
  @import url("../../public/form.css");
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