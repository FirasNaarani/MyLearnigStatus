using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnSchoolApp.Entities;
using LearnSchoolApp.Infra;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using node.Infra;

namespace LearnSchoolApp
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Home/Login";
                options.Cookie.Name = "AuthenticationKey";
            });
            services.AddMvc();
            services.AddControllers();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.Configure<HeadOfDepramentDBSettings>(
            Configuration.GetSection(nameof(HeadOfDepramentDBSettings)));
            services.AddSingleton<IHeadOfDepramentDBSettings>(sp => sp.GetRequiredService<IOptions<HeadOfDepramentDBSettings>>().Value);

            services.Configure<StudentDBSettings>(
            Configuration.GetSection(nameof(StudentDBSettings)));
            services.AddSingleton<IStudentDBSettings>(sp => sp.GetRequiredService<IOptions<StudentDBSettings>>().Value);

            services.Configure<ProjectDBSettings>(
            Configuration.GetSection(nameof(ProjectDBSettings)));
            services.AddSingleton<IProjectDBSettings>(sp => sp.GetRequiredService<IOptions<ProjectDBSettings>>().Value);

            services.Configure<ProjectProposalDBSettings>(
            Configuration.GetSection(nameof(ProjectProposalDBSettings)));
            services.AddSingleton<IProjectProposalDBSettings>(sp => sp.GetRequiredService<IOptions<ProjectProposalDBSettings>>().Value);

            services.Configure<ManagerDBSettings>(
            Configuration.GetSection(nameof(ManagerDBSettings)));
            services.AddSingleton<IManagerDBSettings>(sp => sp.GetRequiredService<IOptions<ManagerDBSettings>>().Value);

            services.Configure<GuideDBSettings>(
            Configuration.GetSection(nameof(GuideDBSettings)));
            services.AddSingleton<IGuideDBSettings>(sp => sp.GetRequiredService<IOptions<GuideDBSettings>>().Value);

            services.AddSingleton<ManagerService>();

            var tokenKey = Configuration.GetValue<string>("TokenKey");
            var key = Encoding.ASCII.GetBytes(tokenKey);

            services.AddSingleton<IJWTAuthenticationOptions>(new JWTAuthenticationOptions(tokenKey));
            services.AddSingleton<AuthenticationService>();
            services.AddSingleton<StudentService>();
            services.AddSingleton<GuideService>();
            services.AddSingleton<HeadOfDepramentService>();
            services.AddSingleton<ProjectService>();
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
            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
