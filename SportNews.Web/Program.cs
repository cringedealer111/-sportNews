using Microsoft.AspNetCore.Authentication.Cookies;
using SportNews.Data;
using SportNews.WebApp;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<UserRepository>();

builder.Services.AddSingleton<PostRepository>();

builder.Services.AddSingleton<PostService>();

builder.Services.AddAuthentication("Bearer")  
                .AddJwtBearer();


builder.Services.AddAuthorization();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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


app.UseSession();

app.MapControllerRoute(
    
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id=1}");

app.Run();
