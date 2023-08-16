using CleanArchitectureBlogApi.Domain.Entities.Common;

namespace CleanArchitectureBlogApi.Domain.Entities;

public class BlogPost : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;

    public virtual ICollection<Comment> Comments {get; set;} = null!;

    public BlogPost()
    {
      Comments = new HashSet<Comment>();
    }
}
