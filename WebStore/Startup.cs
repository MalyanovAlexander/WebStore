using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Controllers;
using WebStore.DAL;
using WebStore.DomainNew.Entities;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Implementations;
using WebStore.Infrastructure.Interfaces;

namespace WebStore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Добавляем сервисы, необходимые для MVC
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SimpleActionFilter));    //подключение по типу
                //альтернативный вариант подключения
                //options.Filters.Add(new SimpleActionFilter());      //подключение по объекту
            });

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            
            //Добавляем разрешение зависимости
            services.AddSingleton<IEmployeesService, InMemoryEmployeeService>();
            services.AddScoped<IProductService, SQLProductService>();
            //services.AddTransient<IEmployeesService, InMemoryEmployeeService>();
            //services.AddScoped<IEmployeesService, InMemoryEmployeeService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()    //связываем с EntityFramework
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //services.ConfigureApplicationCookie(options =>    //необязательно
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.Expiration = TimeSpan.FromDays(150);
            //    //options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
            //    //options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
            //    //options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
            //    options.SlidingExpiration = true;
            //});

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookieCartService>();
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //Задействуем статические ресурсы (папка wwwroot)

            app.UseWelcomePage("/welcome");

            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            UseSample(app);

            var helloMessage = _configuration["CustomHelloWorld"];
            var logLevel = _configuration["Logging:LogLevel:Microsoft"];

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync(helloMessage);
                });
            });

            //После Run ничего выполняться не будет, т.к. у Run нет делегата next
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Мы дошли до финиша конвейера");
            //});
        }

        /// <summary>
        /// Кастомный фильтр
        /// </summary>
        /// <param name="app"></param>
        private void UseSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                bool isError = false;
                if (isError)
                {
                    await context.Response.WriteAsync("Error occured bla bla bla...");
                }
                else
                {
                    await next.Invoke();
                }
            });

        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from custom /Index handler");
            });
        }
    }
}
