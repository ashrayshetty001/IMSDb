using IMSDb.WebApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IMSDb.WebApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<MyAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyAppDbContext") ?? throw new InvalidOperationException("Connection string 'MyAppDbContext' not found.")));

builder.Services.AddSingleton<DatabaseConnectionManager>();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddAntiforgery();



builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{
    // In development expose the EF Core migrations endpoint and developer exception page
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// Enable authentication/authorization middleware so SignInAsync and auth policies work
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("/suppliers/delete", async ([Microsoft.AspNetCore.Mvc.FromForm] int SupplierId, Microsoft.EntityFrameworkCore.IDbContextFactory<IMSDb.WebApp.Data.MyAppDbContext> dbFactory) =>
{
    using var db = await dbFactory.CreateDbContextAsync();
    var supplier = await db.Suppliers.FindAsync(SupplierId);
    if (supplier is not null)
    {
        db.Suppliers.Remove(supplier);
        await db.SaveChangesAsync();
    }
    return Microsoft.AspNetCore.Http.Results.Redirect("/suppliers");
}).DisableAntiforgery();

app.Run();
