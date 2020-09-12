using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using A2UserCRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace A2UserCRUD
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
            services.AddControllers();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<IMessagesService, MessagesService>();
            services.AddSingleton<IAdminsService, AdminService>();
            services.AddSingleton<IGroupsService, GroupService>();
            services.AddSingleton<IMenteeService, MenteeService>();
            services.AddSingleton<IMentorService, MentorService>();
            services.AddSingleton<IPageContentService, PageContentService>();
            services.AddSingleton<ISchoolService, SchoolService>();
            services.AddSingleton<IUserGroups, UserGroupsServices>();
            services.AddSingleton<ICourseService, CourseService>();
            services.AddSingleton<IChatListService, ChatListService>();
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
                app.UseHsts();
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")),
                RequestPath = "/api/gallery"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads")),
                RequestPath = "/api/gallery"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async(context)=>{
                await context.Response.WriteAsync("Could not find anything....");
            });
        }
    }
}
