<template>
  <div class="register">
    <h1>Welcome to Campus.Net.</h1>
    <span class="title">Create account.</span>
    <hr>
    <div class="form-wrapper">
      <form>
        <input placeholder="Username" type="text" v-model="form.username">
        <input autocomplete="email" placeholder="Email" type="email" v-model="form.email">
        <input
          autocomplete="password"
          placeholder="Password"
          type="password"
          v-model="form.password"
        >
        <input
          autocomplete="new-password"
          placeholder="Password Again"
          type="password"
          v-model="pwdAgain"
        >
        <div class="btn-group">
          <button @click="submitForm()" type="primary">Register</button>
          <p>
            Already have an account?
            <router-link :replace="true" tag="span" to="/login">Login.</router-link>
          </p>
        </div>
      </form>
    </div>
  </div>
</template>

<style lang='scss' scoped>
.register {
  width: 100%;
  display: flex;
  flex-flow: column nowrap;
  justify-content: center;
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
        font-size: medium;
        margin: 0 0 10px 0;
        height: 30px;
        border-radius: 4px;
        text-indent: 10px;
        border: 1px solid #e3e3e3;
      }
      .btn-group {
        width: 100%;
        display: flex;
        flex-flow: row wrap;
        justify-content: space-between;
        width: 100%;
        button {
          width: 100%;
          height: 30px;
          border-radius: 4px;
          font-size: medium;
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
}
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
import { RegisterInfo } from '@/models/User';
import { MessageConfig } from 'iview';
@Component({})
export default class Register extends Vue {

  private form: RegisterInfo
    = {
      username: '',
      email: '',
      password: '',
    };

  private pwdAgain: string = '';

  private submitForm() {
    if (this.form.password === this.pwdAgain) {
      const that = this;
      this.$store.dispatch('register', this.form).then((res) => {
        // console.log(res);
        // alert(res.data.message);
        const config: MessageConfig = {
          content: res.data.message,
          duration: 2,
        };
        that.$Message.warning(config);
      });
    }
  }
}
</script>