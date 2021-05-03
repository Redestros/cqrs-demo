using cqrs_demo.CQRS;
using cqrs_demo.Handlers;
using cqrs_demo.Services.Customers;
using Microsoft.Extensions.DependencyInjection;
using Rammus.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cqrs_demo
{
    public static class DependencyRegistrationExtention
    {
        public static IServiceCollection RegisterDemoServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            return services;
        }

        public static IServiceCollection RegisterCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<IRegisterClientCommandHandler, RegisterClientCommandHandler>();
            services.AddScoped<IUpdateClientInfoCommandHandler, UpdateClientInfoCommandHandler>();
            return services;
        }

        public static IServiceCollection RegisterQueriesHandlers(this IServiceCollection services)
        {
            services.AddScoped<ISearchClientsQueryHandler, SearchClientsQueryHandler>();
            services.AddScoped<IGetClientByIdQueryHandler, GetClientByIdQueryHandler>();
            return services;
        }

        public static IServiceCollection RegisterProcessors(this IServiceCollection services)
        {
            services.AddScoped<ICommandProcessor, CommandProcessor>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            return services;
        }
    }
}
