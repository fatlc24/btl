using BTLwebNC.Models;
using BTLwebNC.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//conect sql
var connectionString = builder.Configuration.GetConnectionString("connectDB");
builder.Services.AddDbContext<RentalDbContext>(x => x.UseSqlServer(connectionString));

// sử dụng interface
builder.Services.AddScoped<IcontactRepository, ContactRepositoryImpl>();
builder.Services.AddScoped<INewsRepository, NewsRepositoryImpl>();
builder.Services.AddScoped<ILeaseRepository, LeaseRepositoryImpl>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
    option.LoginPath = "/Access/Login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
});
// config sesstion
builder.Services.AddSession(options =>
{

});
builder.Services.AddHttpContextAccessor();
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

app.UseAuthorization();
// session 
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
