using System.Text;
using Comm.WebAPI.src.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using SailOnHolidays.Business.src.Interfaces;
using SailOnHolidays.Business.src.Services;
using SailOnHolidays.Business.src.Shared;
using SailOnHolidays.Core.src.Entities;
using SailOnHolidays.Core.src.Interfaces;
using SailOnHolidays.WebAPI.src.Database;
using SailOnHolidays.WebAPI.src.ExternalServices;
using SailOnHolidays.WebAPI.src.Repositories;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services
.AddScoped<IUserService, UserService>()
.AddScoped<IUserRepo, UserRepo>()
.AddScoped<IAvatarService, AvatarService>()
.AddScoped<IAvatarRepo, AvatarRepo>()
.AddScoped<ITokenService, TokenService>()
.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

var connectionString = builder.Configuration.GetConnectionString("LocalDb");
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.MapEnum<Role>();
dataSourceBuilder.MapEnum<Status>();
var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options
        .UseNpgsql(dataSource)
        .UseSnakeCaseNamingConvention()
        .AddInterceptors(new TimeStampAsyncInterceptor());
});

builder.Services.AddTransient<ExceptionHandlerMiddleware>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer" ?? "Default Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience" ?? "Default Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "Default Key")),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
     options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        }
    );
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


