using FormApplication.Data.Contexts;
using FormApplication.Service.Abstract;
using FormApplication.Service.Concrete;
using Microsoft.Extensions.DependencyInjection; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public static class StartupManager
    {
        public static IServiceCollection AddDependencyToService(this IServiceCollection services)
        {
            #region ContainerObject

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<FormApplicationContext>();


            #endregion

            return services;
        }
    }
}
