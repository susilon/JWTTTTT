using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace JWTTTTT
{
    /* 
     * JWT Token Terrible Test Tool 
     * 
     * author : susilonurcahyo@gmail.com
     * for testing purposes only,
     * don't use in production, because it's terrible.
     */

    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }
}
