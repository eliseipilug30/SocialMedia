This project is a distributed social media and blogging application where users can create, view, and manage posts and comments. The app has three main parts: a backend server, a frontend web interface, and a desktop client.

Overview
The backend of the application is built using Java Spring, which handles the business logic and manages the data stored in a MySQL database. The frontend is built with Vue.js and Vuetify, allowing users to interact with the app through a modern web interface. The desktop client is developed in C# and offers basic functionalities for managing posts.

Key Features
Backend:

Manages users, posts, and comments.

Allows users to create, update, view, and delete posts and comments.

Includes special functionality to fetch posts by specific users and comments related to each post.

Frontend:

Users can create new posts, view pending and published posts, and add or update comments.

Provides a simple interface for interacting with posts and comments in the application.

Desktop Client:

Allows users to search for posts or comments by keyword.

Includes options to approve or remove posts.

Database
The application stores data in a MySQL database, with the following key entities:

User: Each user has a unique ID, name, and email.

Post: Posts contain a title, content, and a status (e.g., pending or published).

Comment: Comments are linked to specific posts and include content along with the user who posted them.

Technologies Used
Backend: Java Spring, MySQL

Frontend: Vue.js, Vuetify, Axios

Desktop Client: C#
