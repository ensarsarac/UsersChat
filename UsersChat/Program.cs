using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using UsersChat.Data.Concrete;
using UsersChat.Data.Entities;
using UsersChat.Data.Repository.DraftRepo;
using UsersChat.Data.Repository.ImportantRepo;
using UsersChat.Data.Repository.Inbox;
using UsersChat.Data.Repository.Message;
using UsersChat.Data.Repository.Sendbox;
using UsersChat.Data.Repository.TrashRepo;
using UsersChat.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMessageRepository,MessageRepository>();
builder.Services.AddScoped<IInboxRepository,InboxRepository>();
builder.Services.AddScoped<ISendboxRepository,SendboxRepository>();
builder.Services.AddScoped<IDraftRepository,DraftRepository>();
builder.Services.AddScoped<IImportantRepository,ImportantRepository>();
builder.Services.AddScoped<ITrashRepository,TrashRepository>();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityError>();

builder.Services.AddMvc(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index";
    
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Index");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
