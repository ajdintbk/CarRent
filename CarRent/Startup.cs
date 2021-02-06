using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.WebApi.Interfaces;
using CarRent.WebApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CarRent
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<WebApi.Database.CarRentContext>(c => c.UseSqlServer(Configuration.GetConnectionString("CarRent")));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRent API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUserInterface, UserService>();
            services.AddScoped<IService<Model.City, Model.Requests.City.CitySearchRequest>, CityService>();
            services.AddScoped<IService<Model.Fuel, Model.Requests.Fuel.FuelSearchRequest>, FuelService>();
            services.AddScoped<IService<Model.Brand, Model.Requests.Brand.BrandSearchRequest>, BrandService>();
            services.AddScoped<ICRUDService<Model.Vehicle, Model.Requests.Vehicle.VehicleSearchRequest, Model.Requests.Vehicle.VehicleInsert, Model.Requests.Vehicle.VehicleInsert>, VehicleService>();
            services.AddScoped<ICRUDService<Model.Message, Model.Requests.Message.MessageSearchRequest, Model.Requests.Message.MessageInsert, Model.Requests.Message.MessageInsert>, MessageService>();
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<IRecommendService, RecommendService>();
            services.AddScoped<ICRUDService<Model.Review, Model.Requests.Review.ReviewSearchRequest, Model.Requests.Review.ReviewInsert, Model.Requests.Review.ReviewInsert>, ReviewService>();
            services.AddScoped<ICRUDService<Model.Role, Model.Requests.Role.RoleSearchRequest, Model.Requests.Role.RoleInsert, Model.Requests.Role.RoleInsert>, RoleService>();
            services.AddScoped<ICRUDService<Model.Favorites, Model.Requests.Favorites.FavoritesSearchRequest, Model.Requests.Favorites.FavoritesInsert, Model.Requests.Favorites.FavoritesInsert>, FavoritesService>();
            services.AddScoped<ICRUDService<Model.VehicleModel, Model.Requests.VehicleModel.VehicleModelSearchRequest, Model.Requests.VehicleModel.VehicleModelInsert, Model.Requests.VehicleModel.VehicleModelInsert>, VehicleModelService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Rent API");

            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
