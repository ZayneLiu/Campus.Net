<template>
  <div id="profile">
    <!-- <Login></Login> -->
    <div id="profile_heading">
      <main>
        <div id="avatar_social">
          <div id="-avatar">avatar</div>
          <div id="-social">
            <i aria-hidden="true" class="fa fa-weixin"></i>
            <i aria-hidden="true" class="fa fa-weibo"></i>
            <i aria-hidden="true" class="fa fa-github"></i>
            <i aria-hidden="true" class="fa fa-linkedin"></i>
          </div>
        </div>
        <div id="basic_info">
          <div id="-name">
            <span>ZayneLiu</span>
            <a href="#">查看完整档案</a>
          </div>
          <div class="-item" id="-award">
            <span>award</span>
          </div>
          <div class="-item" id="-city">
            <i aria-hidden="true" class="fa fa-map-marker"></i>
            <span>city</span>
          </div>
          <div class="-item" id="-email">
            <i aria-hidden="true" class="fa fa-envelope"></i>
            <span @click="edit($event)">email</span>
          </div>
          <div class="-item" id="-major">
            <i aria-hidden="true" class="fa fa-graduation-cap"></i>
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
        <p>Biography</p>
      </div>
      <!-- </div> -->
    </div>
    <div id="profile_body">
      <div id="basic_info">
        <p>
          <label for>UserId</label>
          <input type="text">
        </p>
        <p>
          <label for>UserName</label>
          <input type="text">
        </p>
        <p>
          <label for>Gender</label>
          <span>
            <input
              :checked="user.gender === 'male'? 'checked': ''"
              name="gender"
              type="radio"
              value="Male"
            >Male
            <input
              :checked="user.gender === 'female'? 'checked': ''"
              name="gender"
              type="radio"
              value="Female"
            >Female
          </span>
        </p>
        <p>
          <label for>SCID</label>
          <input :value="user.scid" type="text">
        </p>
        <p>
          <label for>Email</label>
          <input :value="user.email" type="text">
        </p>
        <p>
          <label for>Tel</label>
          <input :value="user.tel" type="tel">
        </p>
        <p>
          <label for>Birthday</label>
          <input :value="user.birthday" type="date">
        </p>
        <p>
          <label for>Major</label>
          <input :value="user.major" type="text">
        </p>
        <p>
          <label for>Password</label>
          <input :value="user.password" type="text">
        </p>
      </div>
    </div>
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
  private user = {
    id: '',
    scid: '',
    email: '',
    tel: '',
    password: '',
    gender: '',
    birthday: new Date(),
    major: '',
    biography: '',
  };
  mounted() {
    const userId = sessionStorage.getItem('currentUser');
    axios({
      method: 'get',
      url: 'https://localhost:5001/api/users/' + userId,
      responseType: 'application/json',
    }).then((response) => {
      // 登陆成功，从服务器返回 登陆结果 和 UserID
      const result = response.data;
      console.log(response.data);
      console.log(result);
      if (response.data != null) {
        // this.user.id = result['id'];
        this.user = {
          id: result['id'],
          scid: result['scid'],
          email: result['email'],
          tel: result['tel'],
          password: result['password'],
          gender: result['gender'],
          birthday: result['birthday'],
          major: result['major'],
          biography: result['biography'],
        };
        console.log(this.user);

        // console.log(result['id']);
        // this.$router.push('/user/');
        // 登陆成功 用 vuex 向 session 中存储 user
        // this.$store.commit('login', result);
        // 从session 中获取 当前用户 userId
        // console.log(sessionStorage.getItem('currentUserId'));
        // this.$store.dispatch('login');
      }
    });
  }
  public edit(e: Event) {
    // alert("adf");
    console.log(e.srcElement);
  }
}
</script>


<style lang="scss" scoped>
.flex.row {
  display: flex;
  flex-flow: row nowrap;
}
.flex.col {
  display: flex;
  flex-flow: column nowrap;
}
#profile {
  @extend .flex.col;
  justify-content: center;
  height: fit-content;
  #profile_heading {
    @extend .flex.row;
    align-self: center;
    width: 85%;
    max-width: 1200px;
    padding: 0 25px;
    height: 300px;
    justify-content: space-around;
    align-items: center;
    background-color: #f6f6f6;
    main {
      @extend .flex.row;
      justify-content: space-around;
      width: 380px;
      #avatar_social {
        @extend .flex.col;
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
        @extend .flex.col;
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
        @extend .flex.row;
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
    }
  }
  #profile_body {
    display: flex;
    flex-flow: column nowrap;
    #basic_info {
      align-self: center;
      width: fit-content;
      p {
        display: flex;
        flex-flow: row nowrap;
        justify-content: space-between;
      }
    }
  }
}
</style>

