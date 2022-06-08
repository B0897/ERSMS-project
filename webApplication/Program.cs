using Microsoft.EntityFrameworkCore;
using webApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ErsmsConnection");
builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AnimalUserContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AnimalPicContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<LikedContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PictureContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserAnimalFrontContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AnimalPictureFrontContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<LoginContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

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

app.UseCors();
app.Run();
