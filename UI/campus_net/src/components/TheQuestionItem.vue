<template>
  <section id="question-item">
    <div class="rank">
      <div class="votes">
        <span>0</span>
        <small>得票</small>
      </div>
      <div class="answers">
        <span>0</span>
        <small>回答</small>
      </div>
      <div class="views">
        <span>0</span>
        <small>浏览</small>
      </div>
    </div>
    <div class="content">
      <div class="content-upper">
        <span>
          <a href="#">author</a> - 最新动态
        </span>
      </div>
      <div class="content-lower">
        <div class="title">{{question.title}}</div>
        <div class="tags">
          <Tags/>
        </div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import Tags from "@/components/Tags.vue";
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import Questions from "@/views/Community/Questions.vue";
import Question from "@/models/Question";

@Component({
  components: {
    Tags
  }
})
export default class TheQuestionItem extends Vue {
  @Prop({})
  public question!: Question;
}
</script>

<style lang="scss" scoped>
#question-item {
  width: 850px;
  background-color: #c5c5c5;
  display: flex;
  flex-flow: row nowrap;
  .rank {
    display: flex;
    flex-flow: row nowrap;
    justify-content: space-evenly;
    align-items: center;
    width: 150px;
    margin: 0 10px 0 0;
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
