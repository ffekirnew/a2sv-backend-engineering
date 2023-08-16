using CleanArchitectureBlogApi.Domain.Entities.Common;

namespace CleanArchitectureBlogApi.Domain.Entities;

public class Comment : BaseEntity
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }

    public virtual BlogPost BlogPost {get; set;} = null!;
}
