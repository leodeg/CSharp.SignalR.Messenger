using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Messenger.Common;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Input;

namespace Messenger.Client.Console
{
	public class Messenger : IMessenger
	{
		private HubConnection HubConnection;

		private Dictionary<string, IHubCommand> commands = new Dictionary<string, IHubCommand>
		{
			{"help", new HelpCommand () },
			{"setname", new SetNameCommand () },
			{"getname", new GetNameCommand () },
			{"exit", new ExitCommand () },
			{"sendmessage", new SendMessageCommand () }
		};

		private Dictionary<string, string> hubMethods = new Dictionary<string, string>
		{
			{"setname", "SetName" },
			{"getname", "GetName" },
			{"sendmessage", "SendToAll" }
		};

		public Messenger(string connectionUrl)
		{
			HubConnection = new HubConnectionBuilder()
				.WithUrl(connectionUrl)
				.Build();

			HubConnection.On<NewMessage>("Send", OnNewMessage);
		}

		private void OnNewMessage(NewMessage message)
		{
			System.Console.WriteLine();
			System.Console.WriteLine($"New message");
			System.Console.WriteLine($"Sender: {message.Sender}");
			System.Console.WriteLine($"Title: {message.Title}");
			System.Console.WriteLine($"Text: {message.Text}");
			System.Console.WriteLine($"Send time: {message.SendTime}");
			System.Console.WriteLine();
		}

		public async Task ConnectAsync()
		{
			await HubConnection.StartAsync();
		}

		public async Task StartChatAsync()
		{
			bool isRunning = true;

			while (isRunning)
			{
				System.Console.WriteLine("\nEnter your command (help - show all commands):");

				var input = System.Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input))
					continue;

				if (commands.ContainsKey(input))
				{
					IHubCommand command = commands.GetValueOrDefault(input);
					if (command != null)
						isRunning = await command.Execute(HubConnection, hubMethods.GetValueOrDefault(input));
				}
				else
				{
					ConsoleExtenstions.Show($"\nError:: Command [{input}] is not valid\n", ConsoleColor.Red);
				}
			}

			ConsoleExtenstions.Show("\nPress any key...\n", ConsoleColor.Yellow);
			System.Console.ReadLine();
		}
	}
}
