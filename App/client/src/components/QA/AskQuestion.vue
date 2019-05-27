<template>
  <div class="ask-question">
    <span class="label">Title:</span>
    <input
      class="title"
      placeholder="Title :: Please describe your question..."
      type="text"
      v-model="question.title"
    >
    <span class="label">Tags:</span>
    <Select class="tags" filterable multiple v-model="question.tags">
      <Option :key="item.value" :value="item.value" v-for="item in tagList">{{ item.label }}</Option>
    </Select>
    <main>
      <span class="label">Content:</span>
      <span class="label">Preview:</span>
      <textarea
        cols="30"
        placeholder="Question :: Expain what troubbles you..."
        rows="10"
        v-model="question.content"
      ></textarea>
      <div class="preview" v-html="preview"></div>
    </main>
  </div>
</template>

<style lang='scss'>
code {
  //   background-color: #fff;
  color: #f66;
}
pre {
  background-color: #fff;
  padding: 5px;
  border-radius: 4px;
}
</style>

<style lang='scss' scoped>
.ask-question {
  height: calc(100vh - 80px);
  display: flex;
  flex-flow: column wrap;
  align-items: center;
  flex-wrap: wrap;
  padding: 10px 0;
  .label {
    font-size: x-large;
    text-align: start;
    width: 100%;
  }
  .tags {
    width: fit-content;
    min-width: 200px;
    align-self: flex-start;
  }
  .title {
    width: 100%;
    padding: 5px 15px;
    border: 1px solid #d5d5d5;
    border-radius: 4px;
    margin-bottom: 5px;
  }
  main {
    width: 100%;
    padding: 0;
    margin: 0;
    display: flex;
    flex-flow: row wrap;
    flex: 1;
    .label {
      font-size: x-large;
      text-align: start;
      height: 36px;
      width: 50%;
    }
    textarea {
      width: 50%;
      height: calc(100% - 36px);
      resize: none;
      outline: none;
      padding: 15px;
      border-radius: 4px 0 0 4px;
      border: 1px solid #d5d5d5;
      outline: none;
    }
    .preview {
      padding: 20px;
      width: 50%;
      text-align: start;
      background-color: #e5e5e5;
      flex: 1;
      border-radius: 0 4px 4px 0;
      border: 1px solid #d5d5d5;
      display: inline-block;
      vertical-align: top;
    }
  }
}
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
import marked from 'marked';
@Component({})
export default class AskQuestion extends Vue {

  public question: any = {
    content: '',
    title: '',
    tags: [],
  };

  public tagList = [
    {
      value: 'Python',
      label: 'Python',
    },
    {
      value: 'C#',
      label: 'C#',
    },
    {
      value: 'JavaScript',
      label: 'JavaScript',
    },
    {
      value: 'TypeScript',
      label: 'TypeScript',
    },
    {
      value: 'Java',
      label: 'Java',
    },
    {
      value: 'Network',
      label: 'Network',
    },
    {
      value: 'TCP/UDP',
      label: 'TCP/UDP',
    },
    {
      value: 'Vue',
      label: 'Vue',
    },
    {
      value: 'Axios',
      label: 'Axios',
    },
  ];


  public get preview() {
    return marked(this.question.content, { sanitize: true });
  }

  public ask() {
    if (this.question.content === '' || this.question.title === '') {
      this.$Modal.warning({
        title: 'Warning',
        content: 'Please fill the form with enough infomation.',
      });
      return;
    }
    this.$store.dispatch('askQuestion',
      {
        title: this.question.title,
        tags: this.question.tags,
        content: this.preview,
        email: this.$store.state.user.user.email,
      },
    ).then((res) => {
      if (res.data.code === 200) {
        this.$Message.success({
          content: res.data.message,
          duration: 2,
        });
        this.$router.replace('/qa');
      } else {
        this.$Message.warning({
          content: res.data.message,
          duration: 2,
        });
      }
    });
  }

  public created() {
    this.$EventBus.$on('ask-question', this.ask);
  }
}
</script>