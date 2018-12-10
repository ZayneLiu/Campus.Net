<template>
  <div id="questions">
    <!-- <TheQuestionItem v-for="(question,index) in ['string','sdfasdf']" :key="index"/> -->
    <TheQuestionItem :question="getQuestion"/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';
import TheQuestionItem from '@/components/TheQuestionItem.vue';
import Question from '@/models/Question';
import Tags from '@/components/Tags.vue';
import Tag from '@/models/Tag';

@Component({
  components: {
    TheQuestionItem,
  },
})
export default class Questions extends Vue {
  public get getQuestion(): Question {
    return new Question().CreateQuestion(1, 3, 22, 'Title', [
      // new Tag().createTag('Java', 'id', './'),
    ]);
  }
}
</script>

<style lang="scss" scoped>
// #questions {
//   //   height: fit-content;
// }
</style>


