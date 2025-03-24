<template>
    <v-container>
      <h2 class="text-h5">My posts</h2>
      
      
      <v-btn text="Load Posts" @click="fetchPosts">Load Posts</v-btn>
  
      
      <v-btn color="primary" @click="openCreateDialog">Create Post</v-btn>
  
      
      <v-list>
        <v-list-item
          class="postClass"
          variant="outlined"
          v-for="post in sortedPosts"
          :key="post.id"
        >
          <div>
            <h3>{{ post.title }}</h3>
            <p>{{ post.content }}</p>
            <p><strong>Status:</strong> {{ post.status }}</p>
            <p><em>Posted on: {{ post.createdOn }}</em></p>
          </div>
        </v-list-item>
      </v-list>
  
      
      <v-dialog v-model="showDialog" max-width="400">
        <v-card>
          <v-card-title class="headline">Create New Post</v-card-title>
          <v-card-text>
            <v-text-field v-model="post.title" label="Post Title"></v-text-field>
            <v-textarea v-model="post.content" label="Post Content"></v-textarea>
          </v-card-text>
          <v-card-actions>
            <v-btn color="green" @click="createPost">Create</v-btn>
            <v-btn color="grey" @click="closeDialog">Cancel</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-container>
  </template>
  
  <script>
  import axios from "axios";
  
  export default {
    name: "AddPost",
    props: {
      currentUser: String
    },
    data() {
      return {
        showDialog: false, 
        post: {
          title: "",
          content: "",
          status: "PENDING", 
          user: null
        }
      };
    },
    methods: {
      
      openCreateDialog() {
        this.showDialog = true; 
      },
      
      
      async createPost() {
        try {
          
          this.post.user = { id: 2}; 
          const response = await axios.post("http://localhost:8082/posts", this.post);
          console.log("Post created successfully:", response.data);
  
          
          this.showDialog = false;
  
          
          this.post = {
            title: "",
            content: "",
            status: "PENDING",
            user: null
          };
  
          
          this.$emit("postCreated", response.data);
        } catch (error) {
          console.error("Error creating post:", error);
        }
      },
  
      
      closeDialog() {
        this.showDialog = false;
        
        this.post = {
          title: "",
          content: "",
          status: "PENDING",
          user: null
        };
      },
  
      
      async fetchPosts() {
        try {
          const response = await axios.get("http://localhost:8082/posts");
          this.posts = response.data;
        } catch (error) {
          console.error("Error fetching posts:", error);
        }
      }
    }
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
  </style>
