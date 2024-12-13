using BookingService.DataAccess.RabbitMqReceiver;

var builder = WebApplication.CreateBuilder(args);

// Get RabbitMQ URI from configuration or use the default value
var rabbitMqUri = builder.Configuration["RabbitMQ:Uri"] ?? "amqp://guest:guest@localhost:5444";

// Register RabbitMQ receiver service with the updated RabbitMQ URI
builder.Services.AddSingleton<RabbitMqReceiverService>(provider =>
    new RabbitMqReceiverService(rabbitMqUri));

var app = builder.Build();

// Start the RabbitMQ receiver service
var rabbitMqReceiver = app.Services.GetRequiredService<RabbitMqReceiverService>();
rabbitMqReceiver.StartListening();

app.Run();