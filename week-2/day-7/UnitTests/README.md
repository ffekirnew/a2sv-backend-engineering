# Blog App: Unit Tests
## Table of Contents
- [Introduction](#introduction)
- [Unit Tests](#unit-tests)
- [Conclusion](#conclusion)

## Introduction
In this part, we will be writing unit tests for the blog app. The main goal of this module is to be able to test the functionality of the blog app. Through that, the connection with the PostgreSQL database achieved with Microsoft Entity Framework Core will be tested. The unit tests will be written in C# using the xUnit framework. Moreover, when needed the Moq framework will be used to mock the database context and the EntityFrameworkCore.InMemory package will be used to create an in-memory database.

Summary of Technologies Used:
- C#
- xUnit
- Moq
- EntityFrameworkCore.InMemory

## Unit Tests
The unit tests will be written in C# using the xUnit framework. Moreover, when needed the Moq framework will be used to mock the database context and the EntityFrameworkCore.InMemory package will be used to create an in-memory database.
The organization of the unit tests is as follows:
```bash
├── UnitTests
│   ├── Domain
│   │   ├── Entities
│   │   │   ├── TestPostEntity.cs
│   │   │   ├── TestCommentEntity.cs
│   ├── Application
│   │   ├── TestPostApplication.cs
│   │   ├── TestCommentApplication.cs
│   ├── Infrastructure
│   │   ├── Repositories
│   │   │   ├── TestPostRepository.cs
│   │   │   ├── TestCommentRepository.cs
```

### 1. Domain
The domain layer is responsible for the business entities of the application. The domain layer is independent of the other layers. The domain layer has no dependencies on any other layer. The domain layer is the core of the application. It contains the business logic and the business entities. The domain layer is the most stable layer. It contains the entities Post and Comment. They are basic classes, which contain only properties and no methods and will be tested as such.

### 2. Application
The application layer is responsible for the business logic of the application. The application layer depends on the domain layer and has an inverted dependency on the infrastructure layer achieved through the use of interfaces. The concrete implementations of the interfaces are injected into the application layer through the constructor of the application service classes. But for testign purposes they need to be mocked. This is achieved through the use of Moq. Moq is a mocking library for .NET. It is used to mock interfaces so that a dummy functionality can be added to a mock interface that can be used in unit testing.

#### 2.1. TestPostApplication
The TestPostApplication class is used to test the functionality of the PostApplication class. The PostApplication class is responsible for the business logic of the Post entity. The PostApplication class depends on the IPostRepository interface. The IPostRepository interface is injected into the PostApplication class through the constructor. 

The PostApplication class has the following methods:
```csharp
public Post GetPost(int id);
public List<Post> GetAllPosts();
public Post CreatePost(Post post);
public Post AddNewPost(Post post);
public Post DeletePost(int id);
```

#### 2.2. TestCommentApplication
The TestCommentApplication class is used to test the functionality of the CommentApplication class. The CommentApplication class is responsible for the business logic of the Comment entity. The CommentApplication class depends on the ICommentRepository interface. The ICommentRepository interface is injected into the CommentApplication class through the constructor.
Teh CommentApplication class has the following methods:
```csharp
public Comment GetComment(int id);
public List<Comment> GetAllComments();
public Comment UpdateComment(Comment comment);
public Comment AddNewComment(Comment comment);
public Comment DeleteComment(int id);
```

### 3. Infrastructure
The infrastructure layer is responsible for the data access of the application. The infrastructure layer depends on both the domain and the application layers. It contains the repositories for the Post and Comment entities. The repositories are responsible for the CRUD operations of the entities. The repositories depend on the database context. The database context is injected into the repositories through the constructor. The database context is responsible for the connection with the database. The database context is mocked using the EntityFrameworkCore.InMemory package. The EntityFrameworkCore.InMemory package is used to create an in-memory database. The in-memory database is used for testing purposes. The in-memory database is created and disposed of for each test. The in-memory database is seeded with data for each test. The data is seeded using the SeedData class. 



