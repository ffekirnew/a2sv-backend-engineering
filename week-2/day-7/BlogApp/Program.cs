using BlogApp.Application;
using BlogApp.Application.Interfaces;
using BlogApp.Data;
using BlogApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.
    builder.Services.AddControllers();
    // Add the Entity Framework
    builder.Services
        .AddEntityFrameworkNpgsql()
        .AddDbContext<AppDbContext>(
            opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection"))
        );

    builder.Services.AddScoped<IPostRepository, PostRepository>();
    builder.Services.AddScoped<ICommentRepository, CommentRepository>();

    builder.Services.AddScoped<PostApplication>();
    builder.Services.AddScoped<CommentApplication>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();


{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
