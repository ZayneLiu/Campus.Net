<template>
  <div id="profile">
    <!-- <Login></Login> -->
    <div id="profile_heading">
      <main>
        <div id="avatar_social">
          <div id="-avatar">avatar</div>
          <div id="-social">
            <i class="fa fa-weixin" aria-hidden="true"></i>
            <i class="fa fa-weibo" aria-hidden="true"></i>
            <i class="fa fa-github" aria-hidden="true"></i>
            <i class="fa fa-linkedin" aria-hidden="true"></i>
          </div>
        </div>
        <div id="basic_info">
          <div id="-name">
            <span>ZayneLiu</span>
            <a href="#">查看完整档案</a>
          </div>
          <div id="-award" class="-item">
            <span>award</span>
          </div>
          <div id="-city" class="-item">
            <i class="fa fa-map-marker" aria-hidden="true"></i>
            <span>city</span>
          </div>
          <div id="-email" class="-item">
            <i class="fa fa-envelope" aria-hidden="true"></i>
            <span @click="edit($event)">email</span>
          </div>
          <div id="-major" class="-item">
            <i class="fa fa-graduation-cap" aria-hidden="true"></i>
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
            <input type="radio" name="gender" value="Male">Male
            <input type="radio" name="gender" value="Female">Female
          </span>
        </p>
        <p>
          <label for>SCID</label>
          <input type="text">
        </p>
        <p>
          <label for>Email</label>
          <input type="text">
        </p>
        <p>
          <label for>Tel</label>
          <input type="tel">
        </p>
        <p>
          <label for>Birthday</label>
          <input type="date">
        </p>
        <p>
          <label for>Major</label>
          <input type="text">
        </p>
        <p>
          <label for>Password</label>
          <input type="text">
        </p>
      </div>
    </div>
  </div>
</template>

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

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component({
  components: {}
})
export default class User extends Vue {
  edit(e: Event) {
    // alert("adf");
    console.log(e.srcElement);
  }
}
</script>
