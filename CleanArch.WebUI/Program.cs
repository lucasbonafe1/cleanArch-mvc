using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Handlers;
using CleanArch.Application.Services;
using CleanArch.Domain.Account;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Identity;
using CleanArch.Infra.Data.Repositories;
using CleanArch.Infra.IoC;
using CleanArch.WebUI.AuthService;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
    options.AccessDeniedPath = "/Account/AccessDenied"
);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IAuthenticate, AuthenticateService>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(GetProductsQueryHandler).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage(); // Para mostrar erros no navegador
else
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var seedUserRoleInitial = scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
    seedUserRoleInitial.SeedRoles();
    seedUserRoleInitial.SeedUsers();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
