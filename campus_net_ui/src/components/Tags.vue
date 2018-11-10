<template>
	<div class="tags">
		<a href="#" class="tag ">Python</a>
		<a href="#" class="tag">Database</a>
		<a href="#" class="tag">Flask</a>
		<a href="#" class="tag">Web</a>
	</div>
</template>

<style lang="scss" scoped>
.tags {
	user-select: none;
	background-color: #fff;
	width: 100%;
	margin: 0;
	padding: 0;
	display: inline-flex;
	justify-content: flex-start;
	border: 0;
	.tag {
		color: gray;
		text-decoration: none;
		margin: 0 10px 0 0;
		padding-inline-start: 5px;
		padding-inline-end: 5px;
		font-size: small;
		display: block;
		border: 1px #d1d1d1 solid;
		border-radius: 2px;
		background-color: #fff;
	}
	.tag:hover {
		color: #fff;
		background-color: gray;
	}
}
</style>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';

@Component({})
export default class Tags extends Vue { }
</script>
