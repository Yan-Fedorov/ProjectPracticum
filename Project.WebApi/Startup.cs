﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Project.Domain.Services.UserField;
using Project.Domain.Services.CompanyField;
using Project.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Project.Domain.Services.TaskField;
using Project.Domain.Services.CourseField;
using Project.Domain.Services.UserAndCoursesField;
using Project.Domain.Services.UserNotificationField;
using Project.Domain.Services.CompanyNotificationField;
using Project.Domain.Services.CompletedTaskField;

namespace Project.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string assemblyName = typeof(ModelContext).Namespace;
            services.AddMvc();
            services.AddDbContext<ModelContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DemoContext")
                ));
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });
        }

        // Configure Autofac. Called after ConfigureServices()
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<CompanyService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<TaskService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<CourseService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<UserAndCoursesService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<UserNotificationService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<CompanyNotificationService>().AsImplementedInterfaces().AsSelf();
            builder.RegisterType<CompletedTaskService>().AsImplementedInterfaces().AsSelf();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ModelContext dbContext)
        {
            app.UseCors(cfg =>
            {
                cfg.AllowAnyHeader();
                cfg.AllowAnyMethod();
                cfg.AllowAnyOrigin();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            SeedData.Initialize(dbContext);
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
           

            //dbContext.Database.EnsureExist
            //OWIN AUTH
        }
        
    }
}
