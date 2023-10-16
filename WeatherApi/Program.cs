using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var coonectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WeatherContextt>(options =>
{
    options.UseMySQL(coonectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WeatherContextt>();

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