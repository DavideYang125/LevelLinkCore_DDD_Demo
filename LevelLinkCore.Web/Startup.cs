using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LevelLinkCore.Application;
using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.InfrastructureTest;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IContainer = Autofac.IContainer;

namespace LevelLinkCore.Web
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var builder = new ContainerBuilder();

            //注意以下写法
            //builder.RegisterType<GuidTransientAppService>().As<IGuidTransientAppService>();
            //builder.RegisterType<OrderRepository>()
            //    .As<IOrderRepository>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
               .As<IUnitOfWork>()
               .InstancePerLifetimeScope();
            builder.RegisterType<LevelLinkAppService>()
              .As<ILevelLinkAppService>()
              .InstancePerLifetimeScope();

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
