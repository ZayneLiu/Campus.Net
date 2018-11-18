<template>
    <div id="editor">
        <mavon-editor style="height: 100%"></mavon-editor>
    </div>
</template>

<script>
// Local Registration
import { mavonEditor } from 'mavon-editor';
import 'mavon-editor/dist/css/index.css';
export default {
  name: 'editor',
  components: {
    mavonEditor,
    // or 'mavon-editor': mavonEditor
  },
};
</script>


<style>
#editor {
  /* margin: auto; */
  /* max-height: 100vh; */
  /* overflow: scroll; */
  margin: 10px 0 0 0;
  border: 1px #c5c5c5 solid;
  border-radius: 4px;
  overflow: hidden;
  /* box-shadow: none; */
  /* text-shadow: none; */
  /* width: 80%; */
  /* height: 580px; */
  height: calc(100vh - 200px);
}
</style>