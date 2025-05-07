namespace UserManagement.Infra.Message
{
    public interface IMessageBroker
    {
        Task PublishAsync<T>(string topic, T message);
    }
}
