using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MySql.Web;
using MySql.EntityFrameworkCore;
using MySql.Data.MySqlClient;

using System;
using System.Windows.Input;

MySql.Data.MySqlClient.MySqlConnection conn;
string myConnectionString;

myConnectionString = "server=localhost;uid=root;" + "pwd=3004";

try
{
    conn = new MySql.Data.MySqlClient.MySqlConnection();
    conn.ConnectionString = myConnectionString;
    conn.Open();
}
catch (MySql.Data.MySqlClient.MySqlException ex)
{
    MessageBox(ex.Message);
}

var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MVCPlayerContext>(options =>
        options.UseMySQL(builder.Configuration.GetConnectionString("MVCPlayerContext")));
}
else
{
    builder.Services.AddDbContext<MVCPlayerContext>(options =>
        options.UseMySQL(builder.Configuration.GetConnectionString("ProductionMvcMovieContext")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
