using BlogApp.Data;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests.Infrastructure;

public class TestCommentRepository
{
    [Fact]
    public void TestCreateComment()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var commentRepository = new CommentRepository(context);

        // Act
        commentRepository.AddNewComment(new Comment());
        context.SaveChanges();

        // Assert
        Assert.Single(context.Comments);
    }

    [Fact]
    public void TestGetCommentById()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var commentRepository = new CommentRepository(context);
        var comment = new Comment { Id = 1, Text = "Test Comment" };
        context.Comments.Add(comment);
        context.SaveChanges();

        // Act
        var retrievedComment = commentRepository.GetCommentById(1);

        // Assert
        Assert.Equal("Test Comment", retrievedComment.Text);
    }

    [Fact]
    public void TestUpdateComment()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var commentRepository = new CommentRepository(context);
        var comment = new Comment { Id = 1, Text = "Original Comment" };
        context.Comments.Add(comment);
        context.SaveChanges();

        // Act
        var updatedComment = new Comment { Id = 1, Text = "Updated Comment" };
        commentRepository.UpdateComment(1, updatedComment);
        context.SaveChanges();
        var retrievedComment = context.Comments.FirstOrDefault(c => c.Id == 1);

        // Assert
        Assert.Equal("Updated Comment", retrievedComment.Text);
    }

    [Fact]
    public void TestDeleteComment()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var commentRepository = new CommentRepository(context);
        var comment = new Comment { Id = 1, Text = "Test Comment" };
        context.Comments.Add(comment);
        context.SaveChanges();

        // Act
        commentRepository.DeleteComment(1);
        context.SaveChanges();
        var remainingComments = context.Comments.ToList();

        // Assert
        Assert.Empty(remainingComments);
    }

    [Fact]
    public void TestGetAllCommentsOfPost()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(
            Guid.NewGuid().ToString()
        );
        var context = new AppDbContext(optionsBuilder.Options);
        var commentRepository = new CommentRepository(context);
        var postId = 1;
        context.Comments.AddRange(
            new Comment
            {
                Id = 1,
                PostId = postId,
                Text = "Comment 1"
            },
            new Comment
            {
                Id = 2,
                PostId = postId,
                Text = "Comment 2"
            }
        );
        context.SaveChanges();

        // Act
        var postComments = commentRepository.GetAllCommentsOfPost(postId);

        // Assert
        Assert.Equal(2, postComments.Count);
    }
}
