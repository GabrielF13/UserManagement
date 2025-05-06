using MongoDB.Driver;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Events;

namespace UserManagement.Infra.Configuration
{
    public static class MongoDbInitializer
    {
        public static void Initialize(UserManagementDbContext context)
        {
            // Criar índice de email único para usuários
            var indexKeysDefinition = Builders<User>.IndexKeys.Ascending(u => u.Email);
            var indexOptions = new CreateIndexOptions { Unique = true };
            var indexModel = new CreateIndexModel<User>(indexKeysDefinition, indexOptions);
            context.Users.Indexes.CreateOne(indexModel);

            // Criar índice composto para NotificationEvents para pesquisas de intervalo de data
            var notificationIndexKeys = Builders<NotificationEvent>.IndexKeys
                .Ascending(n => n.Type)
                .Ascending(n => n.Timestamp);
            context.NotificationEvents.Indexes.CreateOne(new CreateIndexModel<NotificationEvent>(notificationIndexKeys));
        }
    }
}