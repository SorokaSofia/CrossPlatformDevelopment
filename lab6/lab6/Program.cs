using Auth0.AspNetCore.Authentication;
using DotNetEnv;
using Lab6.Controllers;
using Lab6.Data; // Підключаємо DbContext
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore; // Для конфігурації БД
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Підключення до бази даних
builder.Services.AddDbContext<CarServiceCenterContext>(options =>
{
    var dbType = builder.Configuration.GetValue<string>("DatabaseType");
    switch (dbType)
    {
        case "SqlServer":
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
            break;
        case "Postgres":
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
            break;
        case "Sqlite":
            options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"));
            break;
        case "InMemory":
            options.UseInMemoryDatabase("InMemoryDb");
            break;
        default:
            throw new Exception("Unsupported database type");
    }
});

// Додати підтримку Auth0
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
});


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<Auth0Service>();

var app = builder.Build();

// Налаштування середовища
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

// Додати авторизацію через OpenID/Auth0
app.UseAuthentication();
app.UseAuthorization();

// Налаштування маршрутів
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

// Ініціалізація бази даних
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CarServiceCenterContext>();
    DbInitializer.Initialize(context);
}

app.Run();
