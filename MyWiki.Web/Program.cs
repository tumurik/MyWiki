using MyWiki.Web.Data;
using Microsoft.EntityFrameworkCore;
using MyWiki.Web.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string myWikiConnectionString = builder.Configuration.GetConnectionString("MyWikiDbConnectionString");
string myWikiAuthConnectionString = builder.Configuration.GetConnectionString("MyWikiAuthDbConnectionString");

builder.Services.AddDbContext<MyWikiDbContext>(options => options.UseSqlServer(myWikiConnectionString));
builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(myWikiAuthConnectionString));

builder.Services.AddIdentity<MyWikiUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();

//builder.Services.;
//services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//        .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    //Password requirements
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;
});

// Inject implementation of repository interfaces
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IIssueTypeRepository, IssueTypeRepository>();

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

app.MapRazorPages();

app.Run();
