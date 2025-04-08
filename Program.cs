var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // ← Required for MVC controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.MapControllers();             // ← Discovers controllers

app.UseHttpsRedirection();


app.Run();
