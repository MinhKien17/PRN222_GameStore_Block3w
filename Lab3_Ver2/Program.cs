using BusinessLayer.Service.Implement;
using BusinessLayer.Service.Interface;
using DataLayer.Models;
using DataLayer.Repository.Implement;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Database Config
builder.Services.AddDbContext<GameStoreDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("GameStoreDB")));

// Service Config
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IGameRepo, GameRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameServcie>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Auth Config
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); 
    });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
