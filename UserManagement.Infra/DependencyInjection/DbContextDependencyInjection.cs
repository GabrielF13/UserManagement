using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Infra.Repositories.Users;

namespace UserManagement.Infra.DependencyInjection
{
    public static class DbContextDependencyInjection
    {
        public static IServiceCollection Configuration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoriesServices();        
            services.AddSqlConnection();        
        }

        private static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
        { 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }

        private static IServiceCollection AddSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<UserManagementDbContext>(optitons =>
                optitons.UseSqlServer(connectionString));

            return services;
        }
    }
}
