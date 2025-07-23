using SchoolManageMent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolManageMent.Models;
using SchoolManageMent.IRepository;
using SchoolManageMent.Repository;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SchoolManageMent.MiddileWare;



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


builder.Services.AddTransient<IStudentRepository, StudentRepository>(); 
 builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict | JsonNumberHandling.AllowReadingFromString;


}); 


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultCh allengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});

builder.Services.AddTransient<CustomMiddileware>(); ;

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
builder.Configuration.SetBasePath(app.Environment.ContentRootPath).
  AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
  AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", optional: true).AddEnvironmentVariables();

//builder.Services.Configure<>(builder.Configuration.GetSection());

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


app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<CustomMiddileware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Login}/{action=Index}");
});


//app.MapRazorPages();


app.Run();
