using BlogWebApp.Application.CustomExceptions;
using BlogWebApp.Application.Interfaces;
using BlogWebApp.Domain.Entities;
using BlogWebApp.Infrastructure.Data;

namespace BlogWebApp.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context) => _context = context;

    public Post AddNewPost(Post post)
    {
        try
        {
            Console.WriteLine(_context);
            _context.Add(post);
            _context.SaveChanges();

            return post;
        }
        catch
        {
            throw new InternalServerException();
        }
    }

    public Post GetPostById(int postId)
    {
        try
        {
            Post? post = _context.Posts?.FirstOrDefault(p => p.Id == postId);

            if (post != null)
                return post;
            else
                throw new EntityNotFoundException("Post", postId);
        }
        catch (EntityNotFoundException)
        {
            throw;
        }
        catch
        {
            throw new InternalServerException();
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
        catch (EntityNotFoundException)
        {
            throw new EntityNotFoundException("Post", postId);
        }
        catch
        {
            throw new InternalServerException();
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
        catch (EntityNotFoundException)
        {
            throw new EntityNotFoundException("Post", postId);
        }
        catch
        {
            throw new InternalServerException();
        }
    }

    public List<Post> GetAllPosts()
    {
        try
        {
            List<Post> posts = new();

            foreach (Post post in _context.Posts)
            {
                posts.Add(post);
            }

            return posts;
        }
        catch
        {
            throw new InternalServerException();
        }
    }
}
