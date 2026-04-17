using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using ContactAPI.Services;
using ContactAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromSeconds(60);
    });

    options.RejectionStatusCode = 429;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRateLimiter();

app.MapControllers();

app.Run();
