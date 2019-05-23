<template>
  <div class="login">
    <h1>Welcome to Campus.Net.</h1>
    <span class="title">Please login.</span>
    <hr>
    <div class="form-wrapper">
      <form>
        <input autocomplete="username" placeholder="Email" type="email" v-model="form.email">
        <input
          autocomplete="current-password"
          placeholder="Password"
          type="password"
          v-model="form.password"
        >
      </form>
      <div class="btn-group">
        <button @click="submitForm()" type="primary">Login</button>
        <button>Forget</button>
        <p>
          Don't have an account?
          <router-link :replace="true" tag="span" to="/register">Register.</router-link>
        </p>
      </div>
    </div>
  </div>
</template>

<style lang='scss' >
.login {
  font-size: medium;

  width: 100%;
  height: 100vh;
  display: flex;
  flex-flow: column nowrap;
  // justify-content: center;
  align-items: center;
  h1 {
    margin: 10px 0;
  }
  hr {
    width: 500px;
  }
  .title {
    font-size: x-large;
  }
  .form-wrapper {
    padding: 10px 0;
    display: flex;
    flex-flow: column;
    justify-content: center;
    align-items: center;
    form {
      width: 300px;
      max-width: 300px;
      padding: 10px 0;
      display: flex;
      flex-flow: row wrap;
      input {
        width: 100%;
        margin: 0 0 10px 0;
        height: 30px;
        border-radius: 4px;
        text-indent: 10px;
        border: 1px solid #e3e3e3;
      }
    }
    .btn-group {
      width: 300px;
      display: flex;
      flex-flow: row wrap;
      justify-content: space-between;
      button {
        width: 45%;
        height: 30px;
        border-radius: 4px;
        cursor: pointer;
        &[type='primary'] {
          background-color: lightsteelblue;
        }
        &:hover {
          box-shadow: 0px 3px 5px darkgray;
        }
      }
      p {
        margin: 5px 0 0 0;
        width: 100%;
        text-align: end;

        span {
          cursor: pointer;
          text-decoration: underline;
          color: lightsteelblue;
        }
      }
    }
  }
}
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
import { Md5 } from 'ts-md5';
import UserInterface, { LoginInfo, RegisterInfo } from '@/models/User';
// import { Message as mm } from 'iview';
import { AxiosError } from 'axios';


@Component({})
export default class Login extends Vue {

  private form: LoginInfo
    = {
      email: '',
      password: '',
    };

  private submitForm() {

    this.$store.dispatch('login', this.form)
      .then((res) => {
        if (res.data.code === 200) {
          const user = res.data.user;
          this.$store.commit('setUser', user);
          this.$store.commit('setLoginState', true);

          this.$Message.success({
            content: 'Login Successfully',
          });
          this.$router.replace('/');
        } else {
          this.$Modal.error({
            title: 'Error',
            content: res.data.message,
            // duration: 2,
          });
        }
      });
  }
}
</script>