using MongoDB.Driver;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Events;

namespace UserManagement.Infra
{
    public class UserManagementDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _client;

        public UserManagementDbContext(MongoDbSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoDatabase Database => _database;

        public IMongoCollection<User> Users =>
            _database.GetCollection<User>("Users");

        public IMongoCollection<NotificationEvent> NotificationEvents =>
            _database.GetCollection<NotificationEvent>("NotificationEvents");
    }
}