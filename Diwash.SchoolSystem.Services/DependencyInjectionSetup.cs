using Microsoft.Extensions.DependencyInjection;

namespace Diwash.SchoolSystem.Services
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();

            ////OR (Alternative of using AddTransient) use below with adding ASPNETCore.App framework in the current layer (please see .csproj of the SchoolSystem)
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddRazorPages();

            //Implementation of ClassService and StudentService is different using 2 different concepts
            //ClassService is implemented by adding ADDScoped in the app's Startup.ConfigureServices method.

            //services.AddTransient<IClassService, ClassService>();
            return services;
        }
    }
}
