# Blog Web Api
This is a simple Blog API created with ASP.NET. The project follows the clean architecture principles and has a generic repository pattern implementation.

## Table of Contents
`TODO`

## Project Setup
As mentioned before, the project follows a minimal version of the Clean Architecture. To implement it, the solution is setup in the following file tree structure (With only the most outstanding files and folders included) - a brief description of what they do is also included.

```bash
BlogWebAppSolution
├── BlogWebApp.WebApi
│   ├── Controllers
│   ├── appSettings.json
│   ├── Program.cs
│   └── Startup.cs
├── BlogWebApp.Domain
│   ├── Entities
│   └── ValueObjects (if applicable)
├── BlogWebApp.Application
│   ├── Interfaces
│   ├── Services
│   ├── CustomExceptions
│   └── DependencyInjection.cs
├── BlogWebApp.Infrastructure
│   ├── Data
│   ├── Repositories
│   └── DependencyInjection.cs
└── BlogWebApp.Contracts
    └── ContentNegotiation (if applicable)
```

Out of the 5 projects in the solution, only the WebApi is an ASP.NET Web Api project and the rest are just Class Libraries (as they should be).
The direct dependency between the projects is as follows:
- BlogWebApp.WebApi -> BlogWebApp.Application, BlogWebApp.Domain, BlogWebApp.Contracts
- BlogWebApp.Application -> BlogWebApp.Domain
- BlogWebApp.Infrastructure -> BlogWebApp.Application, BlogWebApp.Domain

The inverted dependency between the projects is as follows (which are later injected via the DependencyInjection package):
- BlogWebApp.Application -> BlogWebApp.Infrastructure

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
    "text": "string",
}
```

#### Response Format
```js
{
    "commentId": "string",
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

## Other Features
### 1. Error Handling
The application has a custom exception handling mechanism. The exceptions are handled in the Application layer and are then passed to the WebApi layer. The WebApi layer then returns the appropriate response to the client. The custom exceptions are as follows:
- EntityNotFoundException
- InternalServerException

### 2. HTTP Response Code
The application returns the appropriate HTTP response code for each request. The response codes are as follows:
- 200 - OK
- 201 - created
- 204 - no content
- 404 - not found

### 3. Robust Dependency Injection
The application uses the built-in dependency injection mechanism of ASP.NET. The dependency injection is done in the WebApi project and is then passed to the Application layer. The Application layer then passes the dependency to the Infrastructure layer. The dependency injection is done in the following files:

### 4. App Settings file
The application has an appSettings.json file which contains the connection string to the database. The file is located in the WebApi project.
