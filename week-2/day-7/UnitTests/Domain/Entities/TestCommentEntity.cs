using BlogApp.Domain.Entities;

namespace UnitTests.Domain;

public class TestCommentEntity
{
    [Fact]
    public void TestCommentProperties()
    {
        // Arrange
        var comment = new Comment
        {
            Id = 1,
            PostId = 2,
            Text = "Test Comment Text"
        };

        // Act
        var postId = comment.PostId;
        var text = comment.Text;

        // Assert
        Assert.Equal(1, comment.Id);
        Assert.Equal(2, postId);
        Assert.Equal("Test Comment Text", text);
    }

    [Fact]
    public void TestCommentToString()
    {
        // Arrange
        var comment = new Comment
        {
            Id = 1,
            PostId = 2,
            Text = "Test Comment Text"
        };

        // Act
        var commentString = comment.ToString();

        // Assert
        Assert.Contains("Post Id: 2, 1. Test Comment Text", commentString);
    }

    [Fact]
    public void TestCommentPostNavigationProperty()
    {
        // Arrange
        var comment = new Comment
        {
            Id = 1,
            PostId = 2,
            Text = "Test Comment Text"
        };
        var post = new Post { Id = 2, Title = "Test Post" };

        // Act
        comment.Post = post;

        // Assert
        Assert.Equal(post, comment.Post);
    }
}
