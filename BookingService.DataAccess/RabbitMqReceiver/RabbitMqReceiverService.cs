using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using IModel = RabbitMQ.Client.IModel;

namespace BookingService.DataAccess.RabbitMqReceiver
{
    public class RabbitMqReceiverService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName = "BookingExchange";
        private readonly string _queueName = "BookingQueue";
        private readonly string _routingKey = "Booking-routing-key";

        public RabbitMqReceiverService(string uriString)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(uriString),
                ClientProvidedName = "Rabbit Receiver App"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare exchange and queue
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(_queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(_queueName, _exchangeName, _routingKey);

            // Set QoS to process one message at a time
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        }

        public void StartListening()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Message Received: {message}");

                // Acknowledge the message
                _channel.BasicAck(args.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

            Console.WriteLine("Waiting for messages...");
        }

        public void StopListening()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
