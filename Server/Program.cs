using CDPModule1.Server;
using CDPModule1.Server.DataSeed;
using CDPModule1.Server.IRepository;
using CDPModule1.Server.IServices;
using CDPModule1.Server.Repository;
using CDPModule1.Server.Services;
using CDPModule1.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// register connection string 
var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();
builder.Services.AddDbContext<CDPDbContext>(options => options.UseSqlServer(
                config.GetConnectionString("CdpModuleConnection"), b => b.EnableRetryOnFailure()
            ));

builder.Services.AddScoped(typeof(BaseEntity));
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{

    var context = scope.ServiceProvider.GetRequiredService<CDPDbContext>();
    await SeedData.SeedAdminData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.Run();