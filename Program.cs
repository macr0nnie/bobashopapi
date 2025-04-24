using Microsoft.EntityFrameworkCore;
using BobaShopApi.Data;
using BobaShopApi.Repositories;
using BobaShopApi;
using BobaShopApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // ← Required for MVC controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDrinkRepository, DrinkRepository>();


//db connection
builder.Services.AddDbContext<BobaShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
