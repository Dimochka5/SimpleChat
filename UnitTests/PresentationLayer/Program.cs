using DataAccessLayer.Data;
using DataAccessLayer.Repositors;
using DataAccessLayer.Contacts;
using BusinessAccessLayer.Services;
using BusinessAccessLayer.SignalR;
using Microsoft.EntityFrameworkCore;
using BusinessAccessLayer.Services.Contracts;
using DataAccessLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<SimpleChatDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IService<Chat>, ServiceChat>();
builder.Services.AddScoped<IService<User>, ServiceUser>();
builder.Services.AddScoped<IService<Message>, ServiceMessage>();
builder.Services.AddScoped<IService<UserInChat>, ServiceUserInChat>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

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
