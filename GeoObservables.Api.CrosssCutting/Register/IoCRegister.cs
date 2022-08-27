using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoObservables.Api.Aplication.Configuration;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using GeoObservables.Api.Aplication.Contracts.Services;
using GeoObservables.Api.Aplication.Services;
using GeoObservables.Api.DataAccess.Contracts.Repositories;
using GeoObservables.Api.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GeoObservables.Api.CrosssCutting.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositaries(services);

            AddRegisterServices(services);

            AddRegisterOthers(services);

            return services;
        }

        public static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IOriginServices, OriginServices>();

            services.AddTransient<IUsersServices, UsersServices>();

            services.AddTransient<IRolesServices, RolesServices>();

            services.AddTransient<IHFlowdataServices, HFlowdataServices> ();

            return services;
        }

        public static IServiceCollection AddRegisterRepositaries(IServiceCollection services)
        {
            services.AddTransient<IOriginRepository, OriginRepository>();

            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IRolesRepository, RolesRepository>();

            services.AddTransient<IHFlowdataRepository, HFlowdataRepository>();

            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {

            services.AddTransient<IAppConfig, AppConfig>();
            //services.AddTransient<IApiCaller, ApiCaller>();

            return services;
        }
    }
}
