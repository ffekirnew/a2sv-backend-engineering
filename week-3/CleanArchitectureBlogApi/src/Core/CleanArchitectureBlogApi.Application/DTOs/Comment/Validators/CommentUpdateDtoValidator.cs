using CleanArchtectureBlogApi.Application.Persistence.Contract;
using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.Comment.Validators;

public class CommentUpdateDtoValidator : AbstractValidator<CommentUpdateDto>
{
    public readonly IBlogPostRepository _blogPostRepository;

    public CommentUpdateDtoValidator(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
        Include(new ICommentDtoValidator());

        RuleFor(c => c.PostId)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be a valid Id.")
            .MustAsync(
                async (id, token) =>
                {
                    var commentExists = await _blogPostRepository.Exists(id);
                    return !commentExists;
                }
            )
            .WithMessage("{PropertyName} doesn't exist.");
    }
}
