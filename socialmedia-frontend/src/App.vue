<template>
  <v-app>
    <v-main>
      <div style="max-width: 1000px; margin-left: 200px">
        <posts-view ref="postsView" />
        <v-btn style="align-content: center" @click="openDialog">Create new post</v-btn>
      </div>
      <add-post
        :currentUser="username"
        ref="addPostDialog"
        @postCreated="refreshPosts"
      ></add-post>
    </v-main>
  </v-app>
</template>

<script>
import PostsView from "@/components/PostsView.vue";
import AddPost from "@/components/AddPost.vue";

export default {
  name: "App",
  components: {
    PostsView,
    AddPost
  },
  data: () => ({
    username: "Nume utilizator"
  }),
  methods: {
    openDialog() {
      this.$refs.addPostDialog.showDialog = true;
    },
    refreshPosts(newPost) {
      this.$refs.postsView.posts.unshift(newPost);
    }
  }
};
</script>
