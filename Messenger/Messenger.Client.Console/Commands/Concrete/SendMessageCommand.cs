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

	class SendMessageCommand : IHubCommand
	{
		public async Task<bool> Execute(HubConnection hubConnection, string methodName)
		{
			ConsoleExtenstions.Show("\nPlease write your message: ", ConsoleColor.Yellow);
			string text = System.Console.ReadLine();

			System.Console.WriteLine();
			var message = new Message
			{
				Title = "New Message",
				Text = text
			};

			await hubConnection.SendAsync(methodName, message);
			ConsoleExtenstions.Show("Message sent\n", ConsoleColor.Green);

			return true;
		}
	}
}
