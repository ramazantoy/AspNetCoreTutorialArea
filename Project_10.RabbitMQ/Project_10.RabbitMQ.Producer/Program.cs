// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

var factory=new ConnectionFactory()
{
    HostName = "localhost",
   // Uri = new Uri("")
};
var connection=factory.CreateConnection();
var channel=connection.CreateModel();

channel.QueueDeclare(queue:"queueTest",durable:false,exclusive:false,autoDelete: false,arguments:null);

var message="Hello, RabbitMQ";
var byteMessage = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange:"",routingKey:"queueTest",basicProperties:null,body:byteMessage);
Console.WriteLine(" [x] Sent {0}", message);
Console.ReadKey();

