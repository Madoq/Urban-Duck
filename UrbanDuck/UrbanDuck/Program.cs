using EmailService;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using UrbanDuck.Data;
using UrbanDuck.Interfaces;
using UrbanDuck.Models;
using UrbanDuck.Repositories;
using UrbanDuck.Services;

var builder = WebApplication.CreateBuilder(args);
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailService.EmailConfiguration>();

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UrbanDuckDbConnection")));
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>(); builder.Services.AddDbContext<DatabaseContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("UrbanDuckDbConnection")));

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));

builder.Services.AddScoped(typeof(IContributorRepository), typeof(ContributorRepository));
builder.Services.AddScoped(typeof(IContributorService), typeof(ContributorService));

builder.Services.AddScoped(typeof(IListingService), typeof(ListingService));
builder.Services.AddScoped(typeof(IListingRepository), typeof(ListingRepository));

builder.Services.AddScoped(typeof(IBookingService), typeof(BookingService));
builder.Services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));


builder.Services.AddSingleton(emailConfig); 
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IEmailSenderService, EmailSender>();
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Logging.AddNLog();

builder.Services.AddMemoryCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

