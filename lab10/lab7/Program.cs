using Lab7.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    var configuration = builder.Configuration;
    var dbType = builder.Configuration.GetValue<string>("DatabaseType");
    if (dbType == "SqlServer")
        options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
    else if (dbType == "Postgres")
        options.UseNpgsql(configuration.GetConnectionString("Postgres"));
    else if (dbType == "Sqlite")
        options.UseSqlite(configuration.GetConnectionString("Sqlite"));
    else
        options.UseInMemoryDatabase("InMemoryDb");
});

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
