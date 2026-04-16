var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddSession();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllers();
app.UseStaticFiles();
app.UseRouting();

// to enable session middleware
app.UseSession();

app.UseEndpoints(endpoints =>
{
    // this is for problem1
    //endpoints.MapControllerRoute("default", "{ controller=Student}/{action=Form}/{id?}");

    //this is for problem 2
    //endpoints.MapControllerRoute("default", "{ controller=Calculator}/{action=Index}/{id?}");

    //this is for problem 3
    // endpoints.MapControllerRoute("default", "{ controller=Product}/{action=Index}/{id?}");

    //this is for problem 4
    endpoints.MapControllerRoute("default", "{ controller=Feedback}/{action=Index}/{id?}");
});
    
app.Run();
