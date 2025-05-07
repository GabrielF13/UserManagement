using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;


namespace UserManagement.Infra.Message
{
    public class RabbitMQMessageBroker : IMessageBroker, IDisposable
    {

        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQMessageBroker(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"],
                VirtualHost = configuration["RabbitMQ:VirtualHost"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declarar exchanges
            _channel.ExchangeDeclare(
                exchange: "notification_exchange",
                type: "topic",
                durable: true,
                autoDelete: false);
        }

        public Task PublishAsync<T>(string topic, T message)
        {
            // Serializar a mensagem
            var messageJson = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(messageJson);

            // Configuração das propriedades da mensagem
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true; // Mensagem persistente
            properties.ContentType = "application/json";
            properties.MessageId = Guid.NewGuid().ToString();
            properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            // Publicar a mensagem
            _channel.BasicPublish(
                exchange: "notification_exchange",
                routingKey: topic,
                basicProperties: properties,
                body: body);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
