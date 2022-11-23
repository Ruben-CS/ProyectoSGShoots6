using Microsoft.EntityFrameworkCore;
using ProyectoSGShoots6.Areas.Identity.Data;
// using ProyectoSGShoots6.Data;
using Microsoft.AspNetCore.Identity;
using ProyectoSGShoots6.Data;

var builder           = WebApplication.CreateBuilder(args);
var azureDbConnection = builder.Configuration.GetConnectionString("AzureConnectionDBContext");
var services          = builder.Services;
var configuration     = builder.Configuration;

services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
{
	microsoftOptions.ClientId     = configuration["Authentication:Microsoft:ClientId"];
	microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
});

// services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(azureDbConnection,
//     providerOptions =>
//         providerOptions.EnableRetryOnFailure()));
//
// services.AddDbContext<ModelosDBContext>(options => options.UseSqlServer(azureDbConnection, providerOptions =>
//     providerOptions.EnableRetryOnFailure()));

<<<<<<< HEAD
services.AddDbContext<ModelosDBContext>(options =>
	                                        options.UseNpgsql(builder.Configuration
		                                                          .GetConnectionString("PostgresConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
	                                                     options.SignIn.RequireConfirmedAccount =
		                                                     true).AddRoles<IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDBContext>();
=======
services.AddDbContext<ModelosDBContext>(options => options.UseSqlServer(azureDbConnection, providerOptions =>
    providerOptions.EnableRetryOnFailure()));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();
>>>>>>> main

//configuracion de contrasena
builder.Services.Configure<IdentityOptions>(options =>
{
<<<<<<< HEAD
	options.Password.RequireDigit           = true;
	options.Password.RequireLowercase       = true;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase       = true;
	options.Password.RequiredLength         = 6;
	options.Password.RequiredUniqueChars    = 0;
=======
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
>>>>>>> main
});
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

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
