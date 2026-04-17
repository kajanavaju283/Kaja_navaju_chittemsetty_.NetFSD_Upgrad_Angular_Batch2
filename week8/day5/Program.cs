using Microsoft.EntityFrameworkCore;
using Week8_day5.Middleware;
using Week8_day5.Data;
using Week8_day5.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// ✅ ADD THESE TWO LINES
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("ContactDb"));

// DI
builder.Services.AddScoped<ContactService>();

var app = builder.Build();

// ✅ ADD THIS BLOCK
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();