using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1Talent.Admin.BLL.Designation;
using _1Talent.Admin.BLL.Domain;
using _1Talent.Admin.BLL.Interfaces;
using _1Talent.Admin.DAL.Context;
using _1Talent.Admin.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OneRPP.Restful.DAO;
using OneRPP.Restful.Services;

namespace _1Talent.Admin
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
            services.AddScoped<DomainContext>();
            services.AddTransient<DomainModel>();
            services.AddTransient<IDomain, Domain>();

            services.AddScoped<DesignationContext>();
            services.AddTransient<DesignationModel>();
            services.AddTransient<IDesignation, Designation>();
            services.AddOneEndpointService();
            services.AddOneEndpointDataManagerService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseOneEndPoint();
            app.UseMvc();
        }
    }
}
