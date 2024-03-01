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
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

//Treba urobit identity FB, microsoft, lokalny

// Add services to the container.

//-----------------Db Context Dp Injection-----------------//
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32)); //Zmenene z 34 -> 32
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DbConnectionString"), serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information) //Debug info -> bude odstranene
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
//--------------End Db Context Dp Injection---------------//
builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();
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
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
Configure(builder.Services);
var app = builder.Build();

void Configure(IServiceCollection services)
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
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
