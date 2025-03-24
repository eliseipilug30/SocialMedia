<template>
  <v-container class="edit-post-container">
    <h2 class="text-h5">Edit Post</h2>
    <v-form ref="form" v-model="isValid">
      <v-text-field
        v-model="post.title"
        label="Title"
        :rules="[rules.required]"
      ></v-text-field>
      <v-textarea
        v-model="post.content"
        label="Content"
        :rules="[rules.required]"
      ></v-textarea>
      <div class="button-group">
        <v-btn color="primary" @click="updatePost" :disabled="!isValid">Save</v-btn>
        <v-btn color="grey" @click="cancelEdit">Cancel</v-btn>
      </div>
    </v-form>
    <v-snackbar v-model="showSnackbar" :timeout="3000" color="green">
      {{ snackbarMessage }}
    </v-snackbar>
  </v-container>
</template>

<script>
import axios from "axios";

export default {
  name: "EditPost",
  props: {
    postId: {
      type: Number,
      required: true,
    },
  },
  data() {
    return {
      post: {
        title: "",
        content: "",
      },
      isValid: false,
      showSnackbar: false,
      snackbarMessage: "",
      rules: {
        required: (value) => !!value || "This field is required.",
      },
    };
  },
  methods: {
    async fetchPost() {
      try {
        const response = await axios.get(
          `http://localhost:8082/posts/${this.postId}`
        );
        this.post = response.data;
      } catch (error) {
        console.error("Error fetching post:", error);
      }
    },
    async updatePost() {
      try {
        await axios.put(
          `http://localhost:8082/posts/${this.postId}`,
          this.post
        );
        this.showSnackbarMessage("Post updated successfully");
        this.$emit("postUpdated", this.post); 
        this.cancelEdit(); 
      } catch (error) {
        console.error("Error updating post:", error);
        this.showSnackbarMessage("Failed to update post");
      }
    },
    cancelEdit() {
      this.$emit("cancelEdit"); 
    },
    showSnackbarMessage(message) {
      this.snackbarMessage = message;
      this.showSnackbar = true;
    },
  },
  mounted() {
    this.fetchPost();
  },
};
</script>

<style scoped>
.edit-post-container {
  background-color: #fff; 
  padding: 20px; 
  border-radius: 10px; 
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1); 
}

.button-group {
  display: flex;
  gap: 10px; 
  margin-top: 20px;
}
</style>
