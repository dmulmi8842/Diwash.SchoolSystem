using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diwash.SchoolSystem.Services
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IClassService, ClassService>();
            return services;
        }
    }
}
