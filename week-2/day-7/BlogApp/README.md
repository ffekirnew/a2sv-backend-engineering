# BlogApp
This is a bloging app created with ASP.NET Core Web Api. The project follows the Clean Architecture pattern where the files have been divided into Domain, Application, Infrastructure and Presentation. 

## Features
Users can add their posts and can also comment on blog posts.

## Endpoints
The end-points of this api are
1. GET `localhost:port/posts/` - Get all posts
2. GET `localhost:port/posts/{id}` - Get a specific post by ID
3. POST `localhost:port/posts/` - Create a new post
   The Request Body Shall be in the following form:
   ```
   {
     "Title": "The title",
     "Content": "The content"
   }
   ```
4. PUT `localhost:port/posts/{id}` - Update a post
5. DELETE `localhost:port/posts/{id}` - Delete a Post
