using MyWiki.Web.Data;
using Microsoft.EntityFrameworkCore;
using MyWiki.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string connectionString = builder.Configuration.GetConnectionString("MyWikiDbConnectionString");
builder.Services.AddDbContext<MyWikiDbContext>(options => options.UseSqlServer(connectionString));
//add authdbcontext

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
