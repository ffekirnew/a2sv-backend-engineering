using CleanArchitectureBlogApi.Application;
using CleanArchitectureBlogApi.Infrastructure;
using CleanArchtectureBlogApi.Persistence;

var builder = WebApplication.CreateBuilder(args);


{
    // Add services to the container.
    builder.Services.AddControllers();

    // Configure Dependency Injections of other projects
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPersistence(builder.Configuration);

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
