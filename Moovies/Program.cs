using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Moovies.Utils.Filters;
using Movies.Common;
using Movies.Common.Notification.Interfcaes;
using Movies.Common.Utils;
using Movies.Core.Models;
using Movies.Core.Requests.Users;
using Movies.Data.Context;
using Movies.Data.Utils;
using Movies.Services.Utils;

var builder = WebApplication.CreateBuilder(args);

var appSettingsSection = builder.Configuration.GetRequiredSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();

RegisterData.Register(builder);
RegisterServices.Register(builder);
RegisterCommons.Register(builder);

builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<UserModel, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<NotificationActionFilter>();
builder.Services.AddScoped<ValidationFilter>();

builder.Services.AddControllersWithViews(options =>
    options.Filters.AddService<NotificationActionFilter>()
);

builder.Services.AddControllersWithViews(options =>
    options.Filters.AddService<ValidationFilter>()
);


ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateRequest>();

var app = builder.Build();

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

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dbContext!.Database.Migrate();
}

app.Run();
