using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


// MySql.Data.MySqlClient.MySqlConnection conn;



//try
//{
//    conn = new MySql.Data.MySqlClient.MySqlConnection();
//    conn.ConnectionString = myConnectionString;
//    conn.Open();
//}
//catch (MySql.Data.MySqlClient.MySqlException ex)
//{
//    MessageBox.Show(ex.Message);
//}

var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MVCPlayerContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("MVCPlayerContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MVCPlayerContext"))));
        // options.UseMySQL(MVCPlayerContext));
}
else
{
    builder.Services.AddDbContext<MVCPlayerContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MVCPlayerContext")));
        // options.UseMySQL(MVCPlayerContext));
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
