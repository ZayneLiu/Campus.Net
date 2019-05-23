<template>
  <!-- <div id="question-item">{{question.title}}</div> -->

  <div class="question-item">
    <div class="rank">
      <div class="answers">
        <span>0</span>
        <small>回答</small>
      </div>
      <hr>
      <div class="views">
        <span>{{question.views?question.views:0}}</span>
        <small>浏览</small>
      </div>
    </div>
    <div class="content">
      <div class="content-upper">
        <span>
          <a href="#">{{author}}</a>
        </span>
      </div>
      <div class="content-lower">
        <router-link
          :to="{ name:'QuestionDetail',params:{ qid:question._id.$oid } }"
          class="title"
          tag="div"
        >{{question.title}}</router-link>
        <div class="tags">
          <!-- <Tags/> -->
        </div>
      </div>
    </div>
  </div>
</template>

<style lang='scss' scoped>
.question-item {
  width: 850px;
  // background-color: #c5c5c5;
  padding: 10px 0;
  border-bottom: 1px solid #e5e5e5;
  display: flex;
  flex-flow: row nowrap;
  .rank {
    display: flex;
    flex-flow: row nowrap;
    justify-content: space-evenly;
    align-items: center;
    width: 100px;
    margin: 0 10px 0 0;
    hr {
      width: 1px;
      height: 30px;
      background-color: grey;
      border: none;
      padding: 0;
    }
    div {
      display: flex;
      flex-flow: column nowrap;
    }
  }
  .content {
    overflow: hidden;
    width: 700px;
    display: flex;
    flex-flow: column nowrap;
    align-items: flex-start;
    .content-upper {
      display: inline-flex;
      flex-flow: row nowrap;
      align-items: flex-start;
      span {
        font-size: small;
      }
    }
    .content-lower {
      display: flex;
      flex-flow: row wrap;
      align-items: center;
      .title {
        font-size: x-large;
        margin-right: 10px;
      }
    }
  }
}
</style>

<script lang='ts'>
import { Component, Vue, Prop } from 'vue-property-decorator';
@Component({})
export default class QuestionItem extends Vue {
  @Prop({
    default: {},
  })
  public question: any;


  public author: string = '';


  public beforeMount() {
    this.$store.dispatch('getUserProfile', this.question.email)
      .then((res) => {
        this.author = res.data.user.username;
      });
  }

}
</script>