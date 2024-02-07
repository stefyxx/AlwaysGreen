
using AlwaysGreen.BLL.Infrastructs;
using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.DAL.Context;
using AlwaysGreen.SecurityJWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;


namespace AlwaysGreen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AlwaysgreenContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.")));

            // Add services to the container.

            //1- per avere il vaue_string dell'enum e non il n�
            builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Title = "My API",
                //    Version = "v1"
                //});

                //Add key 'Authorization' into 'Header' of REQUEST --> value is 'Bearer +space+ myGeneratedToken' 
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });


            builder.Services.AddDbContext<AlwaysgreenContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            // security
            builder.Services.AddScoped<JwtSecurityTokenHandler>();
            builder.Services.AddScoped<JwtManager>();
            builder.Services.AddSingleton(builder.Configuration.GetSection("Jwt").Get<JwtManager.JwtConfig>());


            //psw
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


            //security
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Signature"]))
                    };
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
