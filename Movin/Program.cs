using Microsoft.EntityFrameworkCore;
using Movin.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovinDbContext>(x => x.UseSqlServer("Server=.;Database=Movin;Trusted_Connection=True;"));
//for docker
//builder.Services.AddDbContext<MovinDbContext>(x => x.UseSqlServer("Server=sql-server;Database=HostelSystem;User=sa;Password=P@s5Word&;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
var scope = app.Services.CreateScope();
scope.ServiceProvider.GetService<MovinDbContext>().Database.Migrate();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
