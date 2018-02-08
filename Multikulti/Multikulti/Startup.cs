using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Multikulti.Interfaces;
using Multikulti.Services;
using Multikulti.Controllers;
using Multikulti.Model;

namespace Multikulti
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
            services.AddMvc();
            services.AddSingleton<IPizzaService, PizzaService>();
            services.AddSingleton<IPizzaAccess, PizzaAccess>();            
            services.AddSingleton<IChainOfResp, ChainOfResp>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();         
            }
            app.UseMvcWithDefaultRoute();
        }
    }
}
