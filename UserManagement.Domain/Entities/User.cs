using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Domain.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public User(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}