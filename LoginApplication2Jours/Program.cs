using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginApplication2Jours.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("App2JoursDbContextConnection") ?? throw new InvalidOperationException("Connection string 'App2JoursDbContextConnection' not found.");

builder.Services.AddDbContext<App2JoursDbContext>(options => options.UseSqlite(connectionString));


builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<App2JoursDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 


builder.Services.Configure<IdentityOptions>(options => { 
    
    options.Password.RequireUppercase = false; 
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;

});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
