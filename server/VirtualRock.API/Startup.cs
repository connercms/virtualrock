using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualRock.Core.Repositories;
using VirtualRock.Core.Services;
using VirtualRock.Services;
using VirtualRock.Data;
using VirtualRock.Data.Repositories;
using Microsoft.OpenApi.Models;
using AutoMapper;
using FluentValidation.AspNetCore;
using VirtualRock.API.Validators;
using Microsoft.EntityFrameworkCore;

namespace VirtualRock.API
{
    public class Startup
    {
        private readonly string AllowedOrigins = "_allowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHealthChecks();

            services.AddCors(options =>
            {
                // Allow angular app to access resources
                options.AddPolicy(name: AllowedOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200");
                                  });
            });

            services.AddDbContext<VirtualRockDataContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySql")));
            

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SaveUserResourceValidator>());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Virtual Rock", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

            // TODO: Move to different files

            //services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
            
            /* Validators */
            //services.AddTransient<IValidator<SaveNominationResource>, SaveNominationResourceValidator>();
            //services.AddTransient<IValidator<SaveUserResource>, SaveUserResourceValidator>();

            /* Services */
            services.AddTransient<INominationService, NominationService>();
            services.AddTransient<IUserService, UserService>();

            /* Repositories */
            services.AddScoped<INominationRepository, NominationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Virtual Rock V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(AllowedOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
