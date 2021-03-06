﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Autofac;
using AutoMapper;
using BookingSystem.Commands.Commands.HotelCommands.MappingProfiles;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.Common.Utils;
using BookingSystem.Queries.Infrastructure;
using BookingSystem.ReadPersistence;
using BookingSystem.WebApi.JwtProvider;
using BookingSystem.WebApi.Utils;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace BookingSystem.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();

            services.AddHandlers();

            services.AddDbContext<BookingWriteContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("BookingDatabase")));
            services.AddDbContext<BookingReadContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("BookingDatabase")));

            services.AddTransient<IBookingConfiguration, BookingConfiguration>();
            services.AddTransient<HotelService>();
            services.AddTransient<BookingService>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();


            services.AddAutoMapper(typeof(HotelMappingProfiles));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                    { Title = "BookingSystem API", Version = "v1",
                      License = new License()
                      {
                          Name = "WTFPL",
                          Url = @"http://www.wtfpl.net/",
                      }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[]{}}
                });
            });

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };

            var expirationTime = Configuration.GetValue("BookingRules:TimeOutMinutes", TimeSpan.FromMinutes(30));

            services.AddScoped(provider => new JwtGenerator(new JwtOptions(tokenValidationParameters, expirationTime)));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => { options.TokenValidationParameters = tokenValidationParameters; });

            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowCredentials();
                    });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHsts();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseHsts();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingSystem API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("CORSPolicy");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {      
//            builder.RegisterGeneric(typeof(PagedQueryHandler<,>));
//            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
//                .AsClosedTypesOf(typeof(IQueryHandler<,>)).AsImplementedInterfaces();
//            builder.RegisterGenericDecorator(typeof(PagedQueryHandler<,>), typeof(IQueryHandler<,>));
        }



    }
}
