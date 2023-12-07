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

var builder = WebApplication.CreateBuilder(args);


//Treba urobit identity FB, microsoft, lokalny

// Add services to the container.

//-----------------Db Context Dp Injection-----------------//
var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
builder.Services.AddControllers();
var connectionString = $"server=localhost;userid=bpuser;password=FRI!@!222DB;port=3306;database=BPDB"; //Neskor prehodit do DBCOntext classy ak pojde
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information) //Debug info -> bude odstranene
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
//--------------End Db Context Dp Injection---------------//
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
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
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();
var app = builder.Build();

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
