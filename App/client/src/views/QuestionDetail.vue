<template>
  <div class="question-detail">
    <template v-if="!qid">Loading...</template>

    <h1 class="title">{{question.title}}</h1>
    <div class="tags-views">
      <Tags :tags="question.tags" />
      <span class="view-counter">{{question.views}} views</span>
    </div>
    <!-- views -->
    <div class="question-wrapper">
      <div class="voter">
        <Tooltip class="tips" content="I have the same question!" placement="left">
          <button class="up-vote">
            <Icon type="ios-arrow-up" />
            <span>0</span>
          </button>
        </Tooltip>
        <Tooltip class="tips" content="Invaluable question." placement="left">
          <button class="down-vote">
            <Icon type="ios-arrow-down" />
          </button>
        </Tooltip>
      </div>
      <div class="question-body">
        <div class="content" v-html="question.content"></div>
        <!-- TODO: Question Operations -->
        <!-- TODO: Author Info -->
        <div class="actions-info">
          <div class="actions">
            <template v-if=" question.followed === undefined || question.followed.indexOf(uid) < 0  ">
              <span @click="followQuestion" class="following">
                关注
                | {{question.followed ? question.followed.length:0}}
              </span>
            </template>
            <template v-else>
              <span class="following followed">已关注 | {{question.followed.length}}</span>
            </template>
            收藏 评论
          </div>
          <div class="info">
            <div :style="{ backgroundImage: 'url('+ author.avatar+')'} " class="author-avatar"></div>
            <div>
              <span class="username">{{author.username}}</span>
              <span class="time">{{time}}</span>
            </div>
          </div>
        </div>
        <div class="comments"></div>
        <!-- TODO: Comments -->
      </div>
      <div class="answers"></div>
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
      top: 20px;
      display: flex;
      flex-flow: column nowrap;
      align-items: center;
      width: 50px;
      border: 1px solid #c5c5c5;
      border-radius: 4px;
      .tips {
        display: flex;
        padding: 0;
        margin: 0;
        width: 100%;
        .up-vote {
          padding-top: 5px;
          span {
            line-height: 18px;
            padding: 5px 0 0 0;
          }
        }
        .down-vote {
          padding: 5px;
        }
        .up-vote,
        .down-vote {
          outline: none;
          cursor: pointer;
          width: 100%;
          display: flex;
          flex-flow: column;
          align-items: center;
          background-color: transparent;
          border: none;
          &:hover {
            color: #ffffff;
            span {
              transition-delay: 0;
            }
          }
        }
      }
      &:hover {
        background-color: #a0a0a0;
        color: #ffffff;
        transition-delay: 0;
        span {
          transition-delay: 0;
        }
      }
    }
    .question-body {
      align-self: flex-start;
      flex: 1;
      padding: 10px;
      margin-left: 10px;
      height: fit-content;
      .content {
        text-align: start;
        border-bottom: 1px solid #d5d5d5;
      }
      .actions-info {
        margin-top: 5px;
        display: flex;
        flex-flow: row nowrap;
        align-items: center;
        .actions {
          height: fit-content;
          .following {
            margin-right: 5px;
            user-select: none;
            cursor: pointer;
            padding: 2px 5px;
            background-color: lightgrey;
            border-radius: 4px;
            &:hover,
            &.followed {
              background-color: grey;
              color: #ffffff;
            }
          }
        }
        .info {
          margin-left: auto;
          display: flex;
          flex-flow: row;
          align-items: center;
          .author-avatar {
            width: 60px;
            height: 60px;
            border-radius: 60px;
            background-size: cover;
            background-position: center;
            margin-right: 5px;
          }
          div {
            display: flex;
            flex-flow: column nowrap;
            align-items: flex-start;
            .username {
              font-size: large;
            }
            .time {
              font-size: 14px;
            }
          }
        }
      }
    }
  }
}
</style>

<script lang='ts'>
import { Component, Vue, Prop } from 'vue-property-decorator';
import Tags from '@/components/QA/Tags.vue';
import { Dictionary } from 'vuex';
@Component({
  components: {
    Tags,
  },
})
export default class QuestionDetail extends Vue {
  @Prop()
  public qid: any;

  public question: any = {
    // followed: [],
  };
  public author: any = {};

  public get uid(): string {
    return this.$store.state.user.user._id.$oid;
  }

  public get time(): string {
    let timespan: number =
      new Date().getTime() - Date.parse(this.question.time);
    Math.floor(timespan / (1000 * 60 * 60 * 24));

    const days = Math.floor(timespan / (1000 * 60 * 60 * 24));
    timespan -= days * (1000 * 60 * 60 * 24);
    const hours = Math.floor(timespan / (1000 * 60 * 60));
    timespan -= hours * (1000 * 60 * 60);
    const mins = Math.floor(timespan / (1000 * 60));
    timespan -= mins * (1000 * 60);
    const seconds = Math.floor(timespan / 1000);
    timespan -= seconds * 1000;

    return this.getTimeString([days, hours, mins, seconds]);
  }

  public getTimeString(vs: number[]): string {
    const mapper: Dictionary<string> = {
      0: 'seconds',
      1: 'min(s)',
      2: 'hour(s)',
      3: 'day(s)',
    };
    while (vs.length !== 0) {
      const temp = vs.shift();
      if (temp !== 0) {
        return 'asked ' + temp + ' ' + mapper[vs.length] + ' ago';
      }
    }
    return '';
  }

  public followQuestion() {
    this.$store
      .dispatch('followQuestion', { qid: this.qid, uid: this.uid })
      .then((res) => {
        this.$store.dispatch('getQuestionById', this.qid).then((resQ) => {
          // if (resQ.data.code === 200) {
          this.question = resQ.data.question;
          // }
        });
      });
  }

  public mounted() {
    this.$store
      .dispatch('viewQuestion', { qid: this.qid, uid: this.uid })
      .then((res) => {
        this.$store
          .dispatch('getQuestionById', this.qid)
          .then((resQ) => {
            this.question = resQ.data.question;
          })
          .then(() => {
            this.$store
              .dispatch('getUserProfile', this.question.email)
              .then((resA) => {
                this.author = resA.data.user;
              });
          });
      });
  }
}
</script>