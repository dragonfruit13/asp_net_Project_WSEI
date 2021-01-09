using asp_net_Project_WSEI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using asp_net_Project_WSEI.Extensions;

namespace asp_net_Project_WSEI
{
    public class Startup
    {
        
        public Startup(IConfiguration config) {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.AddRazorPages();
            services.AddMvc();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(option => 
            option.UseSqlServer(Configuration["Data:ItemShop:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                                           .AddDefaultTokenProviders()
                                           .AddEntityFrameworkStores<AppDbContext>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseRouting();
                app.UseHttpsRedirection();
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseElapsedTimeMiddleware();
                app.UseRouting();
                app.UseEndpoints(routes => {
                    routes.MapControllerRoute(
                        name: "default",
                        pattern: "{ controller = Product }/{ action = List }/{id?}"
                        );
                    routes.MapControllerRoute(
                        name: null,
                        pattern: "Product/{category}",
                        defaults: new {
                            controller = "Product",
                            aciont = "List"
                        });
                    routes.MapControllerRoute(
                        name: null,
                        pattern: "Admin/{action=Index}",
                        defaults: new {
                            controller = "Admin",
                        });
                });
                SeedData.EnsurePopulated(app);
            }
        }
    }
}
