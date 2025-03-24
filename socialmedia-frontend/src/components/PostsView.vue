<template>
    <v-container>
      <h2 class="text-h5">My posts</h2>
    
      
      <v-btn text="Load Posts" @click="fetchPosts">Load Posts</v-btn>
    
      
      <v-select
        v-if="posts.length > 0"
        v-model="selectedPostId"
        :items="posts"
        item-text="title"
        item-value="id"
        label="Select a Post"
        outlined
        dense
      ></v-select>
    
      
      <div v-if="selectedPost" class="selected-post-details">
        <h3>{{ selectedPost.title }}</h3>
        <p>{{ selectedPost.content }}</p>
        <p><strong>Status:</strong> {{ selectedPost.status }}</p>
        <p>
          <em>Posted on: {{ selectedPost.createdOn }} by
            {{ selectedPost.user?.name || "Unknown" }}</em>
        </p>
    
      
        <div style="display: flex; gap: 10px; margin-top: 10px;">
          <v-btn
            color="red"
            small
            @click="openConfirmDialog(selectedPost.id)"
          >
            Delete Post
          </v-btn>
          <v-btn
            color="blue"
            small
            @click="toggleComments(selectedPost.id)"
          >
            {{ showComments[selectedPost.id] ? "Hide Comments" : "View Comments" }}
          </v-btn>
          <v-btn
            color="green"
            small
            @click="openEditDialog(selectedPost.id)"
          >
            Edit Post
          </v-btn>
        </div>
    
      
        <ViewComments
          v-if="showComments[selectedPost.id]"
          :postId="selectedPost.id"
          :currentUser="selectedPost.user"
        />
      </div>
    
      
      <v-list v-if="posts.length > 0">
        <v-list-item
          class="postClass"
          variant="outlined"
          v-for="post in sortedPosts"
          :key="post.id"
        >
          <div style="display: flex; flex-direction: column;">
            <div>
              <h3>{{ post.title }}</h3>
              <p>{{ post.content }}</p>
              <p><strong>Status:</strong> {{ post.status }}</p>
              <p>
                <em>Posted on: {{ post.createdOn }} by {{ post.user?.name || 'Unknown' }}</em>
              </p>
            </div>
    
      
            <div style="display: flex; gap: 10px;">
              <v-btn
                color="red"
                small
                @click="openConfirmDialog(post.id)"
              >
                Delete
              </v-btn>
              <v-btn
                color="blue"
                small
                @click="toggleComments(post.id)"
              >
                {{ showComments[post.id] ? 'Hide Comments' : 'View Comments' }}
              </v-btn>
              <v-btn
                color="green"
                small
                @click="openEditDialog(post.id)"
              >
                Edit
              </v-btn>
            </div>
    
      
            <ViewComments
              v-if="showComments[post.id]"
              :postId="post.id"
              :currentUser="post.user"
            />
          </div>
        </v-list-item>
      </v-list>
    
      
      <v-dialog v-model="showDialog" max-width="400">
        <v-card>
          <v-card-title class="headline">Confirm Delete</v-card-title>
          <v-card-text>Are you sure you want to delete this post?</v-card-text>
          <v-card-actions>
            <v-btn color="red" text @click="confirmDelete">Yes</v-btn>
            <v-btn color="grey" text @click="closeDialog">Cancel</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    
      
      <v-dialog v-model="showEditDialog" max-width="600">
        <EditPost
          v-if="selectedPostId"
          :postId="selectedPostId"
          @postUpdated="fetchPosts"
          @cancelEdit="closeEditDialog"
        />
      </v-dialog>
    
      
      <v-snackbar v-model="showSnackbar" :timeout="3000" color="green">
        {{ snackbarMessage }}
      </v-snackbar>
    </v-container>
  </template>
  
  <script>
  import axios from "axios";
  import ViewComments from "@/components/ViewComments.vue";
  import EditPost from "@/components/EditPost.vue";
  
  export default {
    name: "PostsView",
    components: {
      ViewComments,
      EditPost,
    },
    data() {
      return {
        posts: [], 
        selectedPostId: null,
        showDialog: false, 
        postToDelete: null, 
        showEditDialog: false, 
        showSnackbar: false, 
        snackbarMessage: "", 
        showComments: {}, 
      };
    },
    computed: {
      sortedPosts() {
        return [...this.posts].sort(
          (a, b) => new Date(b.createdOn) - new Date(a.createdOn)
        );
      },
      selectedPost() {
        return this.posts.find((post) => post.id === this.selectedPostId);
      },
    },
    methods: {
      async fetchPosts() {
        try {
          const response = await axios.get("http://localhost:8082/posts");
          this.posts = response.data; 
        } catch (error) {
          console.error("Error fetching posts:", error);
        }
      },
      openConfirmDialog(postId) {
        this.postToDelete = postId;
        this.showDialog = true; 
      },
      closeDialog() {
        this.showDialog = false; 
        this.postToDelete = null; 
      },
      async confirmDelete() {
        try {
          await axios.delete(`http://localhost:8082/posts/${this.postToDelete}`);
          this.posts = this.posts.filter((post) => post.id !== this.postToDelete);
          this.showSnackbarMessage("Post deleted successfully");
        } catch (error) {
          console.error(`Error deleting post with ID ${this.postToDelete}:`, error);
          this.showSnackbarMessage("Error deleting post"); 
        }
        this.closeDialog(); 
      },
      showSnackbarMessage(message) {
        this.snackbarMessage = message; 
        this.showSnackbar = true;
      },
      toggleComments(postId) {
        this.showComments = {
          ...this.showComments,
          [postId]: !this.showComments[postId],
        };
      },
      openEditDialog(postId) {
        this.selectedPostId = postId;         this.showEditDialog = true; 
      },
      closeEditDialog() {
        this.showEditDialog = false; 
        this.selectedPostId = null; 
      },
    },
  };
  </script>
  
  <style scoped>
  .postClass {
    margin-bottom: 10px;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 5px;
    background-color: #f9f9f9;
  }
  .selected-post-details {
    margin-top: 20px;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 5px;
    background-color: #f9f9f9;
  }
  </style>
  