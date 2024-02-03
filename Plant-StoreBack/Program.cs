using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireNonAlphanumeric = true; //simvol olab biler
    option.Password.RequireDigit = true; //reqem olmalidir
    option.Password.RequireLowercase = true; //balaca herf olmalidir
    option.Password.RequireUppercase = true; //boyuk olmalidir
    option.Password.RequiredLength = 6; //minimum 6 

    option.User.RequireUniqueEmail = true;

    //option.SignIn.RequireConfirmedEmail = true;
    //Default lockout  settings

    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    option.Lockout.MaxFailedAccessAttempts = 5;
    option.Lockout.AllowedForNewUsers = true;

});


builder.Services.AddScoped<ISettingsService, SettingService>();
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<IElementorService, ElementorService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IFeaturedService, FeaturedService>();
builder.Services.AddScoped<IHelpsService, HelpService>();
builder.Services.AddScoped<IInterestedService, InterestedService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ILayoutService, LayoutService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IWishlistService, WishlistService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();








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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
