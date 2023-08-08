using BlogApp.Domain.Entities;

namespace UnitTests.Domain;

public class TestPostEntity
{
    [Fact]
    public void TestPostProperties()
    {
        // Arrange
        var post = new Post
        {
            Id = 1,
            Title = "Test Title",
            Content = "Test Content"
        };

        // Act
        var title = post.Title;
        var content = post.Content;

        // Assert
        Assert.Equal(1, post.Id);
        Assert.Equal("Test Title", title);
        Assert.Equal("Test Content", content);
    }

    [Fact]
    public void TestPostToString()
    {
        // Arrange
        var post = new Post
        {
            Id = 1,
            Title = "Test Title",
            CreatedAt = new DateTime(2023, 8, 10)
        };

        // Act
        var postString = post.ToString();

        // Assert
        Assert.Contains("1. Test Title - 8/10/2023 12:00:00AM", postString);
    }

    [Fact]
    public void TestPostCommentsCollection()
    {
        // Arrange
        var post = new Post();
        var comment1 = new Comment { Id = 1, Text = "Comment 1" };
        var comment2 = new Comment { Id = 2, Text = "Comment 2" };
        var comments = new List<Comment> { comment1, comment2 };

        // Act
        post.Comments = comments;

        // Assert
        Assert.Equal(comments, post.Comments);
    }
}
