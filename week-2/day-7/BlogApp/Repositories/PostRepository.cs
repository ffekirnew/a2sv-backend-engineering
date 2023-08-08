using BlogApp.Data;
using BlogApp.Models;

namespace BlogApp.Services;

class PostService
{
    private readonly AppDbContext _context;

    public PostService(AppDbContext context) => _context = context;

    public Post AddNewPost(Post post)
    {
        _context.Add(post);

        return post;
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

    public Post GetPostById(int postId)
    {
        Post? post = _context.Posts?.FirstOrDefault(p => p.Id == postId);

        if (post != null)
        {
            return post;
        }
        else
        {
            throw new ArgumentException("Post not found.");
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
            return post;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
