<template>
  <div>
    <template v-for="(question, index) in latestQuestionList">
      <QuestionItem :key="index" :question="question"></QuestionItem>
    </template>
  </div>
</template>

<style lang='scss' scoped>
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
import QuestionItem from './QuestionItem.vue';
@Component({
  components: {
    QuestionItem,
  },
})
export default class LatestQuestions extends Vue {

  public get latestQuestionList(): any[] {
    return this.$store.state.question.latestQuestionList;
  }
}
</script>