using PersonalBlogServer.Application;
using PersonalBlogServer.Domain.Entities;
using PersonalBlogServer.Persistence;
using PersonalBlogServer.Persistence.Contexts;
using PersonalBlogServer.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddCors(action =>
    {
        action.AddPolicy("DefaultCors", policy =>
        {
            policy
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
    });

builder
    .Services
    .AddApplication();

builder
    .Services
    .AddPersistence(builder.Configuration);

builder
    .Services
    .AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder
    .Services
    .AddControllers();

builder
    .Services
    .AddEndpointsApiExplorer();

builder
    .Services
    .AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultCors");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Helper.CreateDummyData(app).Wait();

app.Run();
