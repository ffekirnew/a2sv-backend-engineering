using CleanArchitectureBlogApi.Domain.Entities.Common;

namespace CleanArchitectureBlogApi.Domain.Entities;

public class BlogPost : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
