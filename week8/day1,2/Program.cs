using DataAccessLayer.Data;
using DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Dependency Injection
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=ShowContacts}/{id?}");

app.Run();
