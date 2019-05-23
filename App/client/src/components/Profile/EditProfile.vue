<template>
  <div>
    <input @change="previewFiles" accept="image/*" name="avatar" ref="myAvatar" single type="file">
    <img :src="image" alt>
  </div>
</template>

<style lang='scss' scoped>
</style>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
@Component({})
export default class EditProfile extends Vue {

  public avatar: any = {};
  public image: any = '';

  public previewFiles(event: any) {
    // @ts-ignore
    this.avatar = this.$refs.myAvatar.files[0];
    // Reference to the DOM input element
    const input = event.target;
    // Ensure that you have a file before attempting to read it
    if (input.files && input.files[0]) {
      // create a new FileReader to read this image and convert to base64 format
      const reader = new FileReader();
      // Define a callback function to run, when FileReader finishes its job
      reader.onload = (e) => {
        // Note: arrow function used here, so that "this.imageData" refers to the imageData of Vue component
        // Read image as base64 and set to image
        // @ts-ignore
        this.image = e.target.result;
      };
      // Start the reader job - read file as a data url (base64 format)
      reader.readAsDataURL(input.files[0]);
    }
  }

}
</script>