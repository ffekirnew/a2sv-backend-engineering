using BlogApp.Data;
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

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();
}

var app = builder.Build();


{
    // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
