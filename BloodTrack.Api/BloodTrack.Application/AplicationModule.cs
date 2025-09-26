using BloodTrack.Application.Commands.DonorComands.RegisterDonor;
using Microsoft.Extensions.DependencyInjection;

namespace BloodTrack.Application
{
    public static class AplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.
                AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => 
            config.RegisterServicesFromAssemblyContaining<RegisterDonorCommand>());

            return services;
        }
    }
}
