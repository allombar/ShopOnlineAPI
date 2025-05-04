
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShopOnline.API.Services;
using ShopOnline.BLL.interfaces;
using ShopOnline.BLL.Services;
using ShopOnline.DAL.interfaces;
using ShopOnline.DAL.Repositories;
using ShopOnline.DAL;
using System.Text;

namespace ShopOnline.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                // Définir les informations générales de notre API dans Swagger
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ShopManager",
                    Version = "v1"
                });

                // Déclarer un schéma de sécurité de type Bearer pour Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Token Bearer utilisant le schéma (Bearer {token})",
                    Name = "Authorization", // Nom de l'en-tête HTTP
                    In = ParameterLocation.Header, // Indique que l'info est envoyée dans le header HTTP
                    Type = SecuritySchemeType.ApiKey, // Déclare une clé API de type Bearer
                    Scheme = "Bearer" // Nom du schéma utilisé
                });

                // Ajoute une exigence de sécurité globale pour toutes les routes protégées par [Authorize]
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2", // Nécessaire pour Swagger (interface)
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<ShopOnlineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            builder.Services.AddSingleton<TokenManager>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
