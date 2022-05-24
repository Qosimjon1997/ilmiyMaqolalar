using BusinessLayer.IService;
using BusinessLayer.Service;
using DataLayer.Data;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Models.Auth;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Core.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<ICreate<Article>, ArticleRepo>();
            services.AddTransient<IDelete<Article>, ArticleRepo>();
            services.AddTransient<IRead<Article>, ArticleRepo>();
            services.AddTransient<IReadRange<Article>, ArticleRepo>();

            services.AddTransient<ICreate<Author>, AuthorRepo>();
            services.AddTransient<IDelete<Author>, AuthorRepo>();
            services.AddTransient<IRead<Author>, AuthorRepo>();
            services.AddTransient<IReadRange<Author>, AuthorRepo>();

            services.AddTransient<ICreate<Curriculum>, CurriculumRepo>();
            services.AddTransient<IReadRange<Curriculum>, CurriculumRepo>();
            services.AddTransient<IRead<Curriculum>, CurriculumRepo>();
            services.AddTransient<IDelete<Curriculum>, CurriculumRepo>();

            services.AddTransient<ICreateRange<SubAuthor>, SubAuthorRepo>();
            services.AddTransient<IDeleteRange<SubAuthor>, SubAuthorRepo>();
            services.AddTransient<IRead<SubAuthor>, SubAuthorRepo>();
            services.AddTransient<IReadSubAuthor, SubAuthorRepo>();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICurriculumService, CurriculumService>();
            services.AddScoped<ISubAuthorService, SubAuthorService>();

            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
            }));

            return services;
        }
    }
}
