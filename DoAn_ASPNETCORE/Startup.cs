﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_ASPNETCORE.Areas.Admin.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static DoAn_ASPNETCORE.Controllers.PagesController;

namespace DoAn_ASPNETCORE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDistributedMemoryCache();

            services.Configure<ForwardedHeadersOptions>(options => options.ForwardedHeaders =
            ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto);


            services.AddControllersWithViews();
            services.AddDbContext<Webbanhang>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Webbanhang")));
            services.AddAntiforgery(o => o.HeaderName = "CSRF-TOKEN");
            services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(30000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                 name: "MyArea",
                 areaName: "Admin",
                 pattern: "Admin/{controller=SanPham}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "Areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Pages}/{action=Index}/{id?}");

            });

        }

    }
}
