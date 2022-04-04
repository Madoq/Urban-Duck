using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UrbanDuck.Data;
using UrbanDuck.Interfaces;
using UrbanDuck.Repositories;
using UrbanDuck.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("localdb");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UrbanDuckDbConnection")));

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));

builder.Services.AddScoped(typeof(IContributorRepository), typeof(ContributorRepository));
builder.Services.AddScoped(typeof(IContributorService), typeof(ContributorService));

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

