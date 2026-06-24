using Infoway.eCommerce.Mvc.Dal;
using Infoway.eCommerce.Mvc.Models;
using Infoway.eCommerce.Mvc.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ecomDbConStr = builder.Configuration.GetConnectionString("InfowayEComDbConStr");

builder.Services.AddDbContext<eCommerceDbContext>(options => options.UseMySQL(ecomDbConStr));

builder.Services.AddScoped<ICommonRepository<Category>,CommonRepository<Category>>();
builder.Services.AddScoped<ICommonRepository<Product>, CommonRepository<Product>>();
builder.Services.AddScoped<ICommonRepository<Customer>, CommonRepository<Customer>>();
builder.Services.AddScoped<ICommonRepository<Cart>, CommonRepository<Cart>>();
builder.Services.AddScoped<ICommonRepository<CartItem>, CommonRepository<CartItem>>();
builder.Services.AddScoped<ICommonRepository<Invoice>, CommonRepository<Invoice>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<eCommerceDbContext>();
    DbSeeder.Seed(context);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
