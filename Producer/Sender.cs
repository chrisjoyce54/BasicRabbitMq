﻿using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
	public class Sender
	{
		public static void Main(string[] args)
		{
			var factory = new ConnectionFactory()
			{
				HostName = "localhost"
			};
			using (var connection = factory.CreateConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare("BasicTest", false, false, false, null);
					var message = "getting started with .Net Core RabbitMQ";
					var body = Encoding.UTF8.GetBytes(message);
					channel.BasicPublish("", "BasicTest", null, body);
					Console.WriteLine($"Sent message {message}...");
				}
			}
			Console.WriteLine("Press enter to exit sender....");
			Console.ReadLine();
		}
	}
}
