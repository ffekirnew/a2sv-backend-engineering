using BlogApp.Application;
using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;

namespace UnitTests.Application;

public class CommentApplicationTests
{
    [Fact]
    public void GetAllCommentsOfPost_ShouldReturnListOfComments()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock
            .Setup(repo => repo.GetAllCommentsOfPost(1))
            .Returns(
                new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        Text = "Test Comment",
                        PostId = 1
                    }
                }
            );

        var commentApplication = new CommentApplication(commentRepositoryMock.Object);

        // Act
        var comments = commentApplication.GetAllCommentsOfPost(1);

        // Assert
        Assert.NotNull(comments);
        Assert.Single(comments);
    }

    [Fact]
    public void GetComment_ShouldReturnComment_WhenCommentExists()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock
            .Setup(repo => repo.GetCommentById(1))
            .Returns(
                new Comment
                {
                    Id = 1,
                    Text = "Test Comment",
                    PostId = 1
                }
            );

        var commentApplication = new CommentApplication(commentRepositoryMock.Object);

        // Act
        var comment = commentApplication.GetComment(1);

        // Assert
        Assert.NotNull(comment);
        Assert.Equal(1, comment.Id);
        Assert.Equal("Test Comment", comment.Text);
        Assert.Equal(1, comment.PostId);
    }

    [Fact]
    public void AddNewComment_ShouldReturnAddedComment()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        var newComment = new Comment
        {
            Id = 1,
            Text = "New Comment",
            PostId = 1
        };
        commentRepositoryMock.Setup(repo => repo.AddNewComment(newComment)).Returns(newComment);

        var commentApplication = new CommentApplication(commentRepositoryMock.Object);

        // Act
        var addedComment = commentApplication.AddNewComment(newComment);

        // Assert
        Assert.NotNull(addedComment);
        Assert.Equal(newComment.Id, addedComment.Id);
        Assert.Equal(newComment.Text, addedComment.Text);
        Assert.Equal(newComment.PostId, addedComment.PostId);
    }

    [Fact]
    public void UpdateComment_ShouldReturnUpdatedComment_WhenCommentExists()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        var existingComment = new Comment
        {
            Id = 1,
            Text = "Existing Comment",
            PostId = 1
        };
        var updatedComment = new Comment
        {
            Id = 1,
            Text = "Updated Comment",
            PostId = 1
        };
        commentRepositoryMock
            .Setup(repo => repo.UpdateComment(1, updatedComment))
            .Returns(updatedComment);

        var commentApplication = new CommentApplication(commentRepositoryMock.Object);

        // Act
        var result = commentApplication.UpdateComment(1, updatedComment);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedComment.Id, result.Id);
        Assert.Equal(updatedComment.Text, result.Text);
        Assert.Equal(updatedComment.PostId, result.PostId);
    }

    [Fact]
    public void DeleteComment_ShouldReturnDeletedComment_WhenCommentExists()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        var existingComment = new Comment
        {
            Id = 1,
            Text = "Existing Comment",
            PostId = 1
        };
        commentRepositoryMock.Setup(repo => repo.DeleteComment(1)).Returns(existingComment);

        var commentApplication = new CommentApplication(commentRepositoryMock.Object);

        // Act
        var result = commentApplication.DeleteComment(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(existingComment.Id, result.Id);
        Assert.Equal(existingComment.Text, result.Text);
        Assert.Equal(existingComment.PostId, result.PostId);
    }
}
