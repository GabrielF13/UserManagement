using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Infra.Repositories.Notifications;
using UserManagement.Infra.Repositories.Users;

namespace UserManagement.Infra.DependencyInjection
{
    public static class DbContextDependencyInjection
    {
        public static IServiceCollection Configuration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDbConnection(configuration);
            return services;
        }

        public static IServiceCollection AddMongoDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettingsSection = configuration.GetSection("MongoDbSettings");

            services.AddSingleton<MongoDbSettings>(sp =>
            {
                var settings = new MongoDbSettings();
                mongoDbSettingsSection.Bind(settings);
                return settings;
            });

            services.Configure<MongoDbSettings>(mongoDbSettingsSection);

            services.AddSingleton<UserManagementDbContext>(provider =>
            {
                var settings = provider.GetRequiredService<MongoDbSettings>();

                return new UserManagementDbContext(settings);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}