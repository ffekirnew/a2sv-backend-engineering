using BlogApp.Application.Interfaces;
using BlogApp.Data;
using BlogApp.Domain.Entities;

namespace BlogApp.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context) => _context = context;

    public Post AddNewPost(Post post)
    {
        Console.WriteLine(_context);
        _context.Add(post);
        _context.SaveChanges();

        return post;
    }

    public Post GetPostById(int postId)
    {
        Post? post = _context.Posts?.FirstOrDefault(p => p.Id == postId);

        if (post != null)
        {
            return post;
        }
        else
        {
            throw new Exception("Post is not found.");
        }
    }

    public Post UpdatePost(int postId, Post post)
    {
        try
        {
            var existingPost = GetPostById(postId);
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;

            _context.SaveChanges();
            return existingPost;
        }
        catch
        {
            throw;
        }
    }

    public Post DeletePost(int postId)
    {
        try
        {
            Post post = GetPostById(postId);
            _context.Remove(post);
            _context.SaveChanges();
            return post;
        }
        catch
        {
            throw;
        }
    }

    public List<Post> GetAllPosts()
    {
        List<Post> posts = new();

        foreach (Post post in _context.Posts)
        {
            posts.Add(post);
        }

        return posts;
    }
}
