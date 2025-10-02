using BloodTrack.Application.Commands.DonorComands.RegisterDonor;
using BloodTrack.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodTrack.Application
{
    public static class AplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.
                AddHandlers()
                .AddValidators();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => 
            config.RegisterServicesFromAssemblyContaining<RegisterDonorCommand>());

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<RegisterDonorCommand>();

            return services;
        }
    }
}
