# BlogApp
This is a bloging app created with ASP.NET Core Web Api. The project follows the Clean Architecture pattern where the files have been divided into Domain, Application, Infrastructure and Presentation. 

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
│   │   │   │   ├── PostsRepository.cs
│   │   │   │   ├── CommentsRepository.cs
│   │   ├── Presentation
│   │   │   ├── Controllers
│   │   │   │   ├── PostsController.cs
│   │   │   │   ├── CommentsController.cs
│   │   ├── Data
│   │   │   ├── AppDbContext.cs
│   │   ├── BlogApp.csproj
│   │   ├── Program.c
│   ├── UnitTests
│   │   ├── Application
│   │   │   ├── PostsTests.cs
│   │   │   ├── CommentsTests.cs
│   │   ├── Infrastructure
│   │   │   ├── Repositories
│   │   │   │   ├── PostsRepositoryTests.cs
│   │   │   │   ├── CommentsRepositoryTests.cs
│   │   ├── Domain
│   │   │   ├── Entities
│   │   │   │   ├── PostTests.cs
│   │   │   │   ├── CommentTests.cs
│   │   ├── BlogApp.UnitTests.csproj
│   ├── BlogApp.sln
│   ├── README.md
```

## Endpoints
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
GET /api/posts
```

##### Get post by id
```js
GET /api/posts/{id}
```

##### Create post
```js
POST /api/posts
```

##### Update post
```js
PUT /api/posts/{id}
```

##### Delete post
```js
DELETE /api/posts/{id}
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
GET /api/posts/{postId}/comments
```

##### Get comment by id
```js
GET /api/posts/{postId}/comments/{id}
```

##### Create comment
```js
POST /api/posts/{postId}/comments
```

##### Update comment
```js
PUT /api/posts/{postId}/comments/{id}
```

##### Delete comment
```js
DELETE /api/posts/{postId}/comments/{id}
```
