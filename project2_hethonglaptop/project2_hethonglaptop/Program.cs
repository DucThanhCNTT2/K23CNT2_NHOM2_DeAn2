using Microsoft.EntityFrameworkCore;
using project2_hethonglaptop.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký service trước khi Build
var connectionString = builder.Configuration.GetConnectionString("DbConnect");
builder.Services.AddDbContext<Project2HthonglaptopvaphukienmaytinhContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

// 2. Build app
var app = builder.Build();

// 3. Cấu hình middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
