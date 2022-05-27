using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoSGShoots6.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDBContextConnection") ??
                       throw new InvalidOperationException(
                           "Connection string 'ApplicationDBContextConnection' not found.");
var anotherString = builder.Configuration.GetConnectionString("AzureConnectionDBContext");
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
{
    microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
    microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(anotherString));
;

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>();
;

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();