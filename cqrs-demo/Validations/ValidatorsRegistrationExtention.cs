using cqrs_demo.Services.Customers.Commands;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace cqrs_demo.Validations
{
    public static class ValidatorsRegistrationExtention
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterClientCommand>, RegisterClientCommandValidator>();
            return services;
        }
    }
}
