namespace UserManagement.Infra
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string UsersCollectionName { get; set; } = "Users";
        public string NotificationEventsCollectionName { get; set; } = "NotificationEvents";
    }
}