using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SolidPrinciplesNETCoreDemo.Data;
using SolidPrinciplesNETCoreDemo.Interfaces;
using SolidPrinciplesNETCoreDemo.Repositories;
using SolidPrinciplesNETCoreDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurer les services
builder.Services.AddControllersWithViews();

// Configurer Entity Framework Core avec SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enregistrer les dépôts et services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddScoped<UserService>(); // Enregistrer UserService

var app = builder.Build();

// Configurer le pipeline middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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
    pattern: "{controller=User }/{action=Index}/{id?}");

app.Run();