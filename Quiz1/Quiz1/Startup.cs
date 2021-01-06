using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseNpgsql(
                    _configuration.GetConnectionString("IdentityConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    _configuration.GetConnectionString("AppConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddControllersWithViews();

            // For Authorisation -- building and using a policy
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageRolesAndUsers",
                    policy => policy.RequireClaim("Manage Roles and Users"));
                options.AddPolicy("ManageBookRecords",
                    policy => policy.RequireClaim("Manage Book Records"));
                options.AddPolicy("ManageCheckInAndCheckOut",
                    policy => policy.RequireClaim("Manage Check In and Check Out"));
            });

            services.AddScoped<AppIdentityDbContext>();
            services.AddScoped<ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // When in production shows Error page to user.
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
