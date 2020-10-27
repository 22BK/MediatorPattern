using MediatorPattern.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;
using MediatorPattern.App.Queries.Users;
using MediatorPattern.App.Queries.Product;

namespace MediatorPattern
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMediatR(typeof(UserHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProductHandler).GetTypeInfo().Assembly);
            services.AddEntityFrameworkNpgsql().AddDbContext<PostgreDbContext>(opt =>
        opt.UseNpgsql(Configuration.GetConnectionString("PostgreDbContext")));
            services.AddDbContext<MediatorDBContext>(options => {
            options.UseSqlServer("Server=BUGRAK;Database=MediatorDB;Trusted_Connection=True;");
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}"
                    );
            });
        }
    }
}
