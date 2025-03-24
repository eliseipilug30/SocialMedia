<template>
  <v-container>
    <h3>Comments</h3>

    
    <v-list>
      <v-list-item v-for="comment in comments" :key="comment.id">
        <v-list-item-content>
         
          <v-list-item-title>
            {{ comment.user ? comment.user.name : "Unknown" }}: {{ comment.content }}
          </v-list-item-title>
          <v-list-item-subtitle>Posted on: {{ comment.createdOn }}</v-list-item-subtitle>
        </v-list-item-content>
        <v-btn color="red" small @click="deleteComment(comment.id)">
          Delete
        </v-btn>
      </v-list-item>
    </v-list>

    
    <v-card>
      <v-card-title>Add a Comment</v-card-title>
      <v-card-text>
        <v-textarea
          v-model="newCommentContent"
          label="Write your comment"
          outlined
          :rules="[rules.required]"
        ></v-textarea>
      </v-card-text>
      <v-card-actions>
    
        <v-btn
          :disabled="!newCommentContent.trim()"
          color="green"
          @click="addComment"
        >
          Add Comment
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
import axios from "axios";

export default {
  name: "ViewComments",
  props: {
    postId: {
      type: Number,
      required: true,
    },
    currentUser: {
      type: Object, 
      required: true,
    },
  },
  data() {
    return {
      comments: [], 
      newCommentContent: "",
      rules: {
        required: (value) => !!value || "This field is required", 
      },
    };
  },
  methods: {
    
    async fetchComments() {
      try {
        const response = await axios.get(
          `http://localhost:8082/comments/post/${this.postId}`
        );
        this.comments = response.data;
      } catch (error) {
        console.error("Error fetching comments:", error);
      }
    },
    
    async addComment() {
      if (!this.newCommentContent.trim()) {
        alert("Comment cannot be empty!"); 
        return;
      }

      const newComment = {
        content: this.newCommentContent,
        post: { id: this.postId }, 
        user: this.currentUser, 
      };

      try {
        const response = await axios.post(
          "http://localhost:8082/comments",
          newComment
        );
        this.comments.push(response.data); 
        this.newCommentContent = ""; 
      } catch (error) {
        console.error("Error adding comment:", error);
      }
    },
    
    async deleteComment(commentId) {
      try {
        await axios.delete(`http://localhost:8082/comments/${commentId}`);
        this.comments = this.comments.filter((comment) => comment.id !== commentId);
      } catch (error) {
        console.error("Error deleting comment:", error);
      }
    },
  },
  mounted() {
    this.fetchComments();
  },
};
</script>

<style scoped>
.commentClass {
  margin-bottom: 10px;
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 5px;
  background-color: #f9f9f9;
}
</style>
