<template>
  <div class="qa">
    <main>
      <Tabs value="latest">
        <TabPane label="Latest" name="latest">
          <LatestQuestions/>
        </TabPane>
        <TabPane label="Unsolved" name="unsolved">
          <UnsolvedQuestions/>
        </TabPane>
        <!-- <TabPane label="标签三" name="name3">标签三的内容</TabPane> -->
      </Tabs>
    </main>
    <aside>
      <span>提问</span>
    </aside>
    <!-- TODO: QuestionsList MAIN -->
    <!-- TODO: My Account ASIDE -->
  </div>
</template>

<style lang='scss' scoped>
.qa {
  display: flex;
  flex-flow: row nowrap;
  justify-content: center;
  // height: 100%;
  main {
    flex: 4;
  }
  aside {
    flex: 1;
    background-color: grey;
  }
}
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
import QuestionItem from '@/components/QA/QuestionItem.vue';
import LatestQuestions from '@/components/QA/LatestQuestions.vue';
import UnsolvedQuestions from '@/components/QA/UnsolvedQuestions.vue';


@Component({
  components: {
    QuestionItem,
    LatestQuestions,
    UnsolvedQuestions,
  },
})
export default class QA extends Vue {
  public searchKeyword: string = '';


  public beforeCreate() {
    this.$store.dispatch('getLatestQuestionList');
  }
  public search() {
    // alert('asdf')
  }
}
</script>