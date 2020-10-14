using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Messenger.Client.Console
{
	class Program
	{
		static HubConnection HubConnection;

		static async Task Main(string[] args)
		{
			HubConnection = new HubConnectionBuilder()
				.WithUrl("http://localhost:3744/notification")
				.Build();

			HubConnection.On<string>("Send", message => System.Console.WriteLine($"Message from server: {message}"));

			await HubConnection.StartAsync();

			bool isExit = false;
			while (!isExit)
			{
				var message = System.Console.ReadLine();

				if (message != "exit")
					await HubConnection.SendAsync("SendMessage", message);
				else isExit = true;
			}

			System.Console.WriteLine("Press any key...");
			System.Console.ReadLine();
		}
	}
}
