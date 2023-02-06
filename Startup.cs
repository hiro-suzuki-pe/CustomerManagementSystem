using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomerManagementSystem
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Cookie による認証スキームを追加する
            services
              .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie();

            services.AddAuthorization(options =>
            {
                // AllowAnonymous 属性が指定されていないすべての Action などに対してユーザー認証が必要となる
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. ...
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // [追加] 認証
            app.UseAuthorization(); // 認可

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}