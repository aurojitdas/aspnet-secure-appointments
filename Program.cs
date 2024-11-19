using AppointmentScheduling1.Models;
using DoctorAppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

//adding services for IdentityManager of ASP.NET core and passing the dbContext
//passing application user bcz we are not using the default DB table for IdentityUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Specifying path to the login page for unauthorized users
    options.LoginPath = "/Account/Login";
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    // Making the cookie as HttpOnly, for making it inaccessible to client-side scripts
    options.Cookie.HttpOnly = true;
    // Setting the cookie's expiration time span to 30 minutes
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    // Enabling sliding expiration, so the cookie's expiration time is reset with each user interaction
    options.SlidingExpiration = true;
});

//Adding Service appointmentService.
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

//Adding AddHttpContextAccessor service for getting userId and Role
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");     
}
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    //Used for managing user authentication.
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
