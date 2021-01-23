using asp_net_Project_WSEI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using asp_net_Project_WSEI.Extensions;
using asp_net_Project_WSEI.Hubs;

namespace asp_net_Project_WSEI
{
    public class Startup
    {
        
        public Startup(IConfiguration config) {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.AddSignalR();
            services.AddRazorPages();
            services.AddMvc();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(option => 
            option.UseSqlServer(Configuration["Data:ItemShop:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                                           .AddDefaultTokenProviders()
                                           .AddEntityFrameworkStores<AppDbContext>();
            services.AddSwaggerGen();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                {
                    app.UseDeveloperExceptionPage();
                }

                
                app.UseSwagger();
                app.UseSwaggerUI(endpoint =>
                {
                    endpoint.SwaggerEndpoint("/swagger/v1/swagger.json", "ItemShop API");
                    endpoint.RoutePrefix = "API";
                });

                app.UseStaticFiles();
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseElapsedTimeMiddleware();
                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseEndpoints(routes => {

                    routes.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Product}/{action=List}/{id?}"
                        );
                    routes.MapControllerRoute(
                        name: null,
                        pattern: "Product/{category}",
                        defaults: new {
                            controller = "Product",
                            action = "List"
                        });
                    routes.MapControllerRoute(
                        name: "Admin",
                        pattern: "Admin/{action=Index}",
                        defaults: new {
                            controller = "Admin",
                            action = "Index"
                        });

                    routes.MapHub<ChatHub>("/chatHub");
                    routes.MapHub<CountUser>("/userCounter");
                });
                SeedData.EnsurePopulated(app);
            }
        }
    }
}
