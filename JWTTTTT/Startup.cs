using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.DependencyInjection;


namespace JWTTTTT
{
    /* 
     * JWT Token Terrible Test Tool 
     * 
     * author : susilonurcahyo@gmail.com
     * for testing purposes only,
     * don't use in production, because it's terrible.
     */

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "api/{controller=JWT}/{action=Get}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=JWT}/{action=Get}/{id?}");
            });
        }
    }
}
