using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            //��������� �������, ����������� ��� MVC
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SimpleActionFilter));    //����������� �� ����
                //�������������� ������� �����������
                //options.Filters.Add(new SimpleActionFilter());      //����������� �� �������
            });

            services.AddDbContext<WebStoreContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            //��������� ���������� �����������
            services.AddSingleton<IEmployeesService, InMemoryEmployeeService>();
            services.AddScoped<IProductService, SQLProductService>();
            //services.AddTransient<IEmployeesService, InMemoryEmployeeService>();
            //services.AddScoped<IEmployeesService, InMemoryEmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); //����������� ����������� ������� (����� wwwroot)

            app.UseWelcomePage("/welcome");

            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            UseSample(app);

            var helloMessage = _configuration["CustomHelloWorld"];
            var logLevel = _configuration["Logging:LogLevel:Microsoft"];

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync(helloMessage);
                });
            });

            //����� Run ������ ����������� �� �����, �.�. � Run ��� �������� next
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("�� ����� �� ������ ���������");
            //});
        }

        /// <summary>
        /// ��������� ������
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
