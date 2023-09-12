using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Infrastructure;
using Infrastructure.Services.Storage.Local;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using WebAPI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration); 
//builder.Services.AddInfrastructureServices();

builder.Services.AddHttpContextAccessor();


builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = "127.0.0.1:6379";
    //option.InstanceName = "FrostlineGamesRedis";
}); // Redis

const string tokenOptionsConfigurationSection = "TokenOptions";
TokenOptions tokenOptions =
    builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
    ?? throw new InvalidOperationException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration.");
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "ReactJsDomain",
    policy => policy.WithOrigins("http://localhost:3000")
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});



builder.Services.AddStorage<LocalStorage>();

builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(
        name: "Bearer",
        securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
                "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
        }
    );
    opt.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                new string[] { }
            }
        }
    );
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "WebAPI V1");
        c.DocExpansion(DocExpansion.None);
    });
}



if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();



app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//app.UseDeveloperExceptionPage();


const string webApiConfigurationSection = "WebAPIConfiguration";

WebAPIConfiguration webApiConfiguration = app
    .Configuration
    .GetSection(webApiConfigurationSection)
    .Get<WebAPIConfiguration>() ?? throw new InvalidOperationException($"\"{webApiConfigurationSection}\" section cannot found in configuration.");

app.UseCors(opt 
    => opt.WithOrigins(webApiConfiguration.AllowedOrigins)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseStaticFiles();
app.UseCors("ReactJsDomain");
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "WebAPI V1");
});

app.Run();