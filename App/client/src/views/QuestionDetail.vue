<template>
  <div class="question-detail">
    <template v-if="!qid">Loading...</template>

    <h1 class="title">{{question.title}}</h1>
    <div class="tags-views">
      <Tags/>
      <span class="view-counter">{{question.views}} views</span>
    </div>
    <!-- views -->
    <div class="question-wrapper">
      <div class="voter">
        <Tooltip class="tips" content="I have the same question!" placement="left">
          <button class="up-vote">
            <Icon type="ios-arrow-up"/>
            <span>0</span>
          </button>
        </Tooltip>
        <Tooltip class="tips" content="Invaluable question." placement="left">
          <button class="down-vote">
            <Icon type="ios-arrow-down"/>
          </button>
        </Tooltip>
      </div>
      <div class="question-body">
        <div class="content" v-html="question.content"></div>
        <!-- TODO: Question Operations -->
        <!-- TODO: Author Info -->
        <!-- TODO: Comments -->
      </div>
    </div>
  </div>
</template>

<style lang='scss' scoped>
.question-detail {
  h1 {
    margin: 10px 0 0 0;
    text-align: start;
  }
  .tags-views {
    margin: 5px 0 0 0;
    border-bottom: 1px solid #e5e5e5;
    display: flex;
    flex-flow: row nowrap;
    .view-counter {
      margin-left: 10px;
      color: grey;
    }
  }
  .question-wrapper {
    display: flex;
    flex-flow: row nowrap;
    .voter {
      margin-top: 10px;
      height: fit-content;
      position: sticky;
      //   position: fixed;
      top: 20px;
      display: flex;
      flex-flow: column nowrap;
      //   justify-content: space-evenly;
      align-items: center;
      width: 50px;
      border: 1px solid #c5c5c5;
      border-radius: 4px;
      //   float: left;
      .tips {
        display: flex;
        padding: 0;
        margin: 0;
        width: 100%;
        // margin: auto;
        .up-vote {
          padding-top: 5px;
          span {
            // height: 10px;
            line-height: 18px;
            padding: 5px 0 0 0;
          }
        }
        .down-vote {
          padding: 5px;
        }
        .up-vote,
        .down-vote {
          // padding: 5px;
          cursor: pointer;
          width: 100%;
          display: flex;
          flex-flow: column;
          align-items: center;
          background-color: transparent;
          border: none;
          &:hover {
            background-color: grey;
            color: #ffffff;
            transition-delay: 0;
            span {
              transition-delay: 0;
              // transition: none;
            }
          }
        }
      }
    }
    .question-body {
      padding: 10px;
      margin-left: 10px;
      height: fit-content;
      .content {
        //   border-left: 1px solid #d5d5d5;
        //   border-radius: 4px;
      }
    }
  }
}
</style>

<script lang='ts'>
import { Component, Vue, Prop } from 'vue-property-decorator';
import Tags from '@/components/QA/Tags.vue';
@Component({
  components: {
    Tags,
  },
})
export default class QuestionDetail extends Vue {
  @Prop()
  public qid: any;

  public question: any = {};

  public mounted() {
    const uid = this.$store.state.user.user._id.$oid;
    this.$store.dispatch('viewQuestion', { qid: this.qid, uid });
    this.$store.dispatch('getQuestionById', this.qid)
      .then((res) => {
        if (res.data.code === 200) {
          this.question = res.data.question;
        }
      });
  }
}
</script>