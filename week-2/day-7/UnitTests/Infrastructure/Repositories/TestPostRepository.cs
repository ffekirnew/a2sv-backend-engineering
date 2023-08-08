using BlogApp.Data;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Infrastructure;

public class TestPostRepository
{
    [Fact]
    public void TestAddNewPost()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var postRepository = new PostRepository(context);
        var post = new Post
        {
            Id = 1,
            Title = "Test Post",
            Content = "Test Content"
        };

        // Act
        postRepository.AddNewPost(post);
        context.SaveChanges();

        // Assert
        Assert.Single(context.Posts);
    }

    [Fact]
    public void TestGetPostById()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var postRepository = new PostRepository(context);
        var post = new Post
        {
            Id = 1,
            Title = "Test Post",
            Content = "Test Content"
        };
        context.Posts.Add(post);
        context.SaveChanges();

        // Act
        var retrievedPost = postRepository.GetPostById(1);

        // Assert
        Assert.Equal("Test Post", retrievedPost.Title);
    }

    [Fact]
    public void TestUpdatePost()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var postRepository = new PostRepository(context);
        var post = new Post
        {
            Id = 1,
            Title = "Original Post",
            Content = "Original Content"
        };
        context.Posts.Add(post);
        context.SaveChanges();

        // Act
        var updatedPost = new Post
        {
            Id = 1,
            Title = "Updated Post",
            Content = "Updated Content"
        };
        postRepository.UpdatePost(1, updatedPost);
        context.SaveChanges();
        var retrievedPost = context.Posts.FirstOrDefault(p => p.Id == 1);

        // Assert
        Assert.Equal("Updated Post", retrievedPost.Title);
        Assert.Equal("Updated Content", retrievedPost.Content);
    }

    [Fact]
    public void TestDeletePost()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var postRepository = new PostRepository(context);
        var post = new Post
        {
            Id = 1,
            Title = "Test Post",
            Content = "Test Content"
        };
        context.Posts.Add(post);
        context.SaveChanges();

        // Act
        postRepository.DeletePost(1);
        context.SaveChanges();
        var remainingPosts = context.Posts.ToList();

        // Assert
        Assert.Empty(remainingPosts);
    }

    [Fact]
    public void TestGetAllPosts()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var postRepository = new PostRepository(context);
        context.Posts.AddRange(
            new Post
            {
                Id = 1,
                Title = "Post 1",
                Content = "Content 1"
            },
            new Post
            {
                Id = 2,
                Title = "Post 2",
                Content = "Content 2"
            }
        );
        context.SaveChanges();

        // Act
        var allPosts = postRepository.GetAllPosts();

        // Assert
        Assert.Equal(2, allPosts.Count);
    }
}
