using SchoolManageMent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolManageMent.Models;
using SchoolManageMent.IRepository;
using SchoolManageMent.Repository;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins ,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/").AllowAnyHeader()
                                                  .AllowAnyMethod().AllowAnyOrigin();
                      });
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("DefaultConnection").ToString()));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.AddTransient<IStudentRepository,StudentRepository>();  
builder.Services.AddSingleton<IUserRepository,UserRepository>();
 builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict | JsonNumberHandling.AllowReadingFromString;


}); 


// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
    RequestPath = new PathString("/app-images")
});

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Login}/{action=Index}");
});

//app.MapRazorPages();

app.Run();
