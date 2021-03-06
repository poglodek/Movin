using Microsoft.EntityFrameworkCore;
using Movin;
using Movin.Database;
using Movin.Schedule;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

ServiceCollectionHelper.AddServices(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//TODO: add ErrorHandlingMiddleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
var scope = app.Services.CreateScope();
scope.ServiceProvider.GetService<MovinDbContext>().Database.Migrate();
scope.ServiceProvider.GetService<Schedule>().StartService();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
