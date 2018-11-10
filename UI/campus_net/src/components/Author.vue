<template>
    <div class="author">
        <div class="avatar"></div>
        <a href="#">Author</a>
        <span>发布于</span>
        <a href="#">Contained-Blog</a>
        <span class="stars">
            <i class="fa fa-bookmark"/>15 收藏
        </span>
    </div>
</template>

<style lang="scss" scoped>
// :root{

// }
.author {
	margin: 5px 0;
	height: fit-content;
	display: inline-flex;
	flex-flow: row nowrap;
	justify-content: flex-start;
	line-height: 100%;
	font-size: medium;
	.avatar {
		background-color: grey;
		width: 20px;
		height: 20px;
		border-radius: 20px;
	}
	a {
		text-decoration: none;
		align-self: center;
		padding: 0 5px;
		font-size: medium;
	}
	a:hover {
		text-decoration: underline;
	}
	span {
		align-self: center;
		font-size: medium;
		font-weight: 400;
	}
	.stars {
		user-select: none;
		cursor: pointer;
		margin: 0 0 0 3px;
		font-size: small;
		color: grey;
		font-weight: 400;
		i {
			margin: 0 5px 0 2px;
			// align-self: center;
			padding: 3px 0 0 0;
			color: grey;
		}
	}
	.stars:hover {
		text-decoration: underline;
	}
}
</style>

<script lang="ts">
import Vue from 'vue';
import Component from 'vue-class-component';

@Component({

})
export default class Author extends Vue {

}
</script>
