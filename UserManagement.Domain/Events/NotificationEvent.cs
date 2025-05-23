﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Domain.Events
{
    public class NotificationEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("type")]
        [BsonRepresentation(BsonType.String)]
        public NotificationType Type { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("data")]
        public Dictionary<string, string> Data { get; set; }

        public NotificationEvent(Guid id, NotificationType type, DateTime timestamp, Dictionary<string, string> data)
        {
            Id = id;
            Type = type;
            Timestamp = timestamp;
            Data = data;
        }

        public NotificationEvent(NotificationType type,Dictionary<string, string> data)
        {
            Type = type;
            Data = data;
        }

        public NotificationEvent()
        {
            Data = new Dictionary<string, string>();
        }
    }
}