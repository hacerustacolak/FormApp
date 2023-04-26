using FormApplication.Data.Contexts;
using FormApplication.Service.Abstract;
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

            services.AddScoped<IUserService, FormApplication.Service.Concrete.UserService>(); 
            services.AddScoped<IFormService, FormApplication.Service.Concrete.FormService>(); 
            services.AddScoped<FormApplicationContext>();


            #endregion

            return services;
        }
    }
}
