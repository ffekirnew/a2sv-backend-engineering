using BlogWebApp.Application.Interfaces;
using BlogWebApp.Domain.Entities;

namespace BlogWebApp.Application;

public class PostsApplication
{
    private readonly IPostRepository _postRepository;

    public PostsApplication(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public List<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post GetPost(int postId)
    {
        return _postRepository.GetPostById(postId);
    }

    public Post AddNewPost(Post post)
    {
        return _postRepository.AddNewPost(post);
    }

    public Post UpdatePost(int postId, Post post)
    {
        return _postRepository.UpdatePost(postId, post);
    }

    public Post DeletePost(int postId)
    {
        return _postRepository.DeletePost(postId);
    }
}
