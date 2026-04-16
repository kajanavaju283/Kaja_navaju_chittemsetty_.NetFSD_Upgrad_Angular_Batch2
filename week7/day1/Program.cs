using AppDemo.DataAccess;
using AppDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
// Add services
builder.Services.AddScoped<IContactRepo<ContactInfo>, ContactImplementation>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

// Endpoint mapping
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Run the app
app.Run();