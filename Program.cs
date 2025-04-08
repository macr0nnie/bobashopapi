var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // ← Required for MVC controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//add the db connection
builder.Services.AddDbContext<BobaShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
