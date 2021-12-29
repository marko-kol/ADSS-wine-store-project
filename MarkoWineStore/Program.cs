using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MarkoWineStore.Data;
using Microsoft.AspNetCore.Identity;
using MarkoWineStore.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin"));
});

builder.Services.AddDbContext<MarkoWineStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarkoWineStoreContext")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MarkoWineStoreContext>();builder.Services.AddDbContext<MarkoWineStoreContext>(options =>
    options.UseSqlServer(connectionString));
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
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Wines}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
