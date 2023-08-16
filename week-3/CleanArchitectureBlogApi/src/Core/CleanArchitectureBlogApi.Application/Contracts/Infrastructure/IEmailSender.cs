using CleanArchtectureBlogApi.Application.Models;

namespace CleanArchtectureBlogApi.Application.Contracts.Infrastructure;

public interface IEmailSender
{
    public Task<bool> SendEmail(Email email);
}
