using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory() { HostName = "localhost" };
var channel = factory.CreateConnection().CreateModel();
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var byteMessages = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(byteMessages);
    Console.WriteLine($"Message : {message}");
};
channel.BasicConsume(queue:"queueTest",autoAck:true,consumer:consumer);
Console.ReadKey();