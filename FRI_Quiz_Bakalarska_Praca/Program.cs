using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using FRI_Quiz_Bakalarska_Praca.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using FRI_Quiz_Bakalarska_Praca.Data.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using FRI_Quiz_Bakalarska_Praca.Data;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//-----------------Db Context Dp Injection-----------------//
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32)); //Zmenene z 34 -> 32
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DbConnectionString"), serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information) //Debug info -> bude odstranene
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
//--------------End Db Context Dp Injection---------------//
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       builder.Configuration.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   })
   /*.AddFacebook(options =>
   {
       IConfigurationSection FBAuthNSection =
       builder.Configuration.GetSection("Authentication:FB");
       options.ClientId = FBAuthNSection["ClientId"];
       options.ClientSecret = FBAuthNSection["ClientSecret"];
   })*/
   .AddMicrosoftAccount(microsoftOptions =>
   {
       microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
       microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
   });

builder.Services.AddDefaultIdentity<User>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(360);
    options.SlidingExpiration = true;

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.Services.AddCascadingAuthenticationState();
/*builder.Services.AddAuthorization( 
options => //Vypnutie autorizacie k microsoftu a ponechanie stareho kodu nizsie
{
// By default, all incoming requests will be authorized according to the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});*/

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
//builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();
builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();
//builder.Services.AddScoped<AuthenticationStateProvider, OwnAuthenticationProvider>();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
//Configure(builder.Services);
var app = builder.Build();

/*void Configure(IServiceCollection services)
{   
    services.AddScoped<UserManager<User>>();
    services.AddScoped<SignInManager<User>>();
    services.AddScoped<AuthenticationStateProvider, OwnAuthenticationProvider>();
    var serviceProvider = services.BuildServiceProvider();
    using (var serviceScope = serviceProvider.CreateScope())
    {
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            roleManager.CreateAsync(new IdentityRole<int>("Admin")).Wait();
        }
        if (!roleManager.RoleExistsAsync("User").Result)
        {
            roleManager.CreateAsync(new IdentityRole<int>("User")).Wait();
        }
    }
}*/


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseCookiePolicy();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
