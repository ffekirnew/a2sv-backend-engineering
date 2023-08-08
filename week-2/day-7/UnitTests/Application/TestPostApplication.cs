using BlogApp.Application;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;

namespace UnitTests.Application;

public class PostApplicationTests
{
    [Fact]
    public void GetAllPosts_ShouldReturnListOfPosts()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock
            .Setup(repo => repo.GetAllPosts())
            .Returns(
                new List<Post>
                {
                    new Post
                    {
                        Id = 1,
                        Title = "Test Post 1",
                        Content = "Content 1"
                    }
                }
            );

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act
        var posts = postApplication.GetAllPosts();

        // Assert
        Assert.NotNull(posts);
        Assert.Single(posts); // Assuming one post is returned in this case
    }

    [Fact]
    public void GetPost_ShouldReturnPost_WhenPostExists()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock
            .Setup(repo => repo.GetPostById(1))
            .Returns(
                new Post
                {
                    Id = 1,
                    Title = "Test Post",
                    Content = "Content"
                }
            );

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act
        var post = postApplication.GetPost(1);

        // Assert
        Assert.NotNull(post);
        Assert.Equal(1, post.Id);
        Assert.Equal("Test Post", post.Title);
        Assert.Equal("Content", post.Content);
    }

    [Fact]
    public void GetPost_ShouldThrowException_WhenPostDoesNotExist()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.GetPostById(1)).Throws<Exception>(); // Mocking that the repository throws an exception

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act and Assert
        Assert.Throws<Exception>(() => postApplication.GetPost(1));
    }

    [Fact]
    public void AddNewPost_ShouldReturnAddedPost()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        var newPost = new Post { Title = "New Post", Content = "New Content" };
        postRepositoryMock
            .Setup(repo => repo.AddNewPost(newPost))
            .Returns(
                new Post
                {
                    Id = 1,
                    Title = "New Post",
                    Content = "New Content"
                }
            );

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act
        var addedPost = postApplication.AddNewPost(newPost);

        // Assert
        Assert.NotNull(addedPost);
        Assert.Equal("New Post", addedPost.Title);
        Assert.Equal("New Content", addedPost.Content);
    }

    [Fact]
    public void UpdatePost_ShouldReturnUpdatedPost()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        var updatedPost = new Post
        {
            Id = 1,
            Title = "Updated Post",
            Content = "Updated Content"
        };
        postRepositoryMock.Setup(repo => repo.UpdatePost(1, updatedPost)).Returns(updatedPost);

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act
        var result = postApplication.UpdatePost(1, updatedPost);

        // Assert
        Assert.Equal(updatedPost, result);
    }

    [Fact]
    public void DeletePost_ShouldReturnDeletedPost()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        var deletedPost = new Post
        {
            Id = 1,
            Title = "Deleted Post",
            Content = "Deleted Content"
        };
        postRepositoryMock.Setup(repo => repo.DeletePost(1)).Returns(deletedPost);

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act
        var result = postApplication.DeletePost(1);

        // Assert
        Assert.Equal(deletedPost, result);
    }

    [Fact]
    public void DeletePost_ShouldThrowException_WhenPostDoesNotExist()
    {
        // Arrange
        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.DeletePost(1)).Throws<Exception>();

        var postApplication = new PostApplication(postRepositoryMock.Object);

        // Act and Assert
        Assert.Throws<Exception>(() => postApplication.DeletePost(1));
    }
}
