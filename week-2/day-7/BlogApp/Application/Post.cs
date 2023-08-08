using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application;

public class PostApplication
{
    private readonly IPostRepository _postRepository;

    public PostApplication(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public List<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post GetPost(int postId)
    {
        try
        {
            return _postRepository.GetPostById(postId);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Post AddNewPost(Post post)
    {
        return _postRepository.AddNewPost(post);
    }

    public Post UpdatePost(int postId, Post post)
    {
        try
        {
            return _postRepository.UpdatePost(postId, post);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public Post DeletePost(int postId)
    {
        try
        {
            return _postRepository.DeletePost(postId);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
