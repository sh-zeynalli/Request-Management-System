using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RequestData;
using RequestWebApi;
using RequestDataAccess.Interfaces;

using RequestDataAccess.Services;
using RequestWebApi.Endpoints.Security;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("RequestWebApi"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insert JWT with Bearer",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        }
                        },

                new string[] {}
            }
    });
});

builder.Services.AddScoped<ICategoryEndpointService, CategoryEndpointService>();
builder.Services.AddScoped<IRequestEndpointService, RequestEndpointService>();
builder.Services.AddScoped<IApiJwtTokenGenerator, ApiJwtTokenGenerator>();
builder.Services.AddScoped<IUserEndpointService, UsersEndpointService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(config =>
    {
        var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Key)
        };
    });

builder.Services.Configure<JwtIssuerOptions>(options =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:Key"]));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha512);

    options.Issuer = builder.Configuration["JWT:Issuer"];
    options.Audience = builder.Configuration["JWT:Audience"];
    options.SigningCredentials = signingCredentials;
    options.ValidFor = TimeSpan.FromMinutes(Double.Parse(builder.Configuration["JWT:ExpireMinutes"]));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.SeedDb();
    app.UseAuthentication();
    app.UseAuthorization();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
