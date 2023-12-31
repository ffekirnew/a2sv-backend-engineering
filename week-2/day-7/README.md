# BlogApp
This is a bloging app created with ASP.NET Core Web Api. The main goal of this task was to be able to use EFCore to integrate PostgreSQL with .Net development. The method to allow users to access it was our choice and I have gone with a REST(ful) API. The project follows the Clean Architecture pattern where the code base has been divided into Domain, Application, Infrastructure and Presentation. The project also contains a test module, which contains unit tests for the application.

P.S.: I am not using a Roslyn-based linter. For that reason, my code might show some formatting/linting differences from popular text-editor code (VSCode...), but it's just the linter.

## Table of Contents
1. [Features](#features)
2. [Code Organization](#code-organization)
3. [Endpoints](#endpoints)

## Features
Users can add their posts and can also comment on blog posts.

## Code Organization
The code is organized into the following folders:
```bash
├── Day 7: Blog App
│   ├── BlogApp
│   │   ├── Domain
│   │   │   ├── Entities
│   │   │   │   ├── Post.cs
│   │   │   │   ├── Comment.cs
│   │   ├── Application
│   │   │   ├── Interfaces
│   │   │   │   ├── IPostsRepository.cs
│   │   │   │   ├── ICommentsRepository.cs  
│   │   │   ├── Posts.cs
│   │   │   ├── Comments.cs
│   │   ├── Infrastucture
│   │   │   ├── Repositories
│   │   │   │   ├── PostsRepository.cs (BlogPostManager)
│   │   │   │   ├── CommentsRepository.cs (CommentManager)
│   │   ├── Presentation
│   │   │   ├── Controllers
│   │   │   │   ├── PostsController.cs
│   │   │   │   ├── CommentsController.cs
│   │   ├── Data
│   │   │   ├── AppDbContext.cs
│   │   ├── BlogApp.csproj
│   │   ├── Program.cs
│   ├── UnitTests
│   ├── day-7.sln
│   ├── README.md
```

## Endpoints
![image](https://github.com/ffekirnew/a2sv-backend-engineering/assets/98191496/fb928263-2f7e-4c99-bc40-037200348008)
The end-points of this application can be generally divided into two categories: [Post](#1-post) and [Comment](#2-comment).
The end-points of this api are based on the REST architecture. The request and response formats are in JSON. They are described below. Then the end points will follow:
### 1. Post
#### Request Format
```js
{
    "title": "string",
    "content": "string",
}
```

#### Response Format
```js
{
    "id": "string",
    "title": "string",
    "content": "string",
    "createdOn": "string",
}
```
#### Endpoints
##### Get all posts
```js
GET /posts
```

##### Get post by id
```js
GET /posts/{id}
```

##### Create post
```js
POST /posts
```

##### Update post
```js
PUT /posts/{id}
```

##### Delete post
```js
DELETE /posts/{id}
```

### 2. Comment
#### Request Format
```js
{
    "content": "string",
}
```

#### Response Format
```js
{
    "commentId": "string",
    "postId": "string",
    "text": "string",
    "createdOn": "string",
}
```

#### Endpoints
##### Get all comments
```js
GET /posts/{postId}/comments
```

##### Get comment by id
```js
GET /posts/{postId}/comments/{id}
```

##### Create comment
```js
POST /posts/{postId}/comments
```

##### Update comment
```js
PUT /posts/{postId}/comments/{id}
```

##### Delete comment
```js
DELETE /posts/{postId}/comments/{id}
```
