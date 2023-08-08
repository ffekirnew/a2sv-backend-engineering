using BlogApp.Domain.Entities;

namespace BlogApp.Application.Interfaces;

public interface IPostRepository
{
    public Post AddNewPost(Post post);
    public List<Post> GetAllPosts();
    public Post GetPostById(int postId);
    public Post UpdatePost(int postId, Post post);
    public Post DeletePost(int postId);
}
