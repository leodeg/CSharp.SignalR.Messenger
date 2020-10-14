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

	class SetNameCommand : IHubCommand
	{
		public async Task<bool> Execute(HubConnection hubConnection, string methodName)
		{
			ConsoleExtenstions.Show("\nPlease write your name: ", ConsoleColor.Yellow);

			string name = System.Console.ReadLine();
			if (string.IsNullOrWhiteSpace(name))
			{
				ConsoleExtenstions.Show("\nName is not valid.\n", ConsoleColor.Red);
				return true;
			}

			await hubConnection.SendAsync(methodName, name);
			ConsoleExtenstions.Show("\nName sent\n", ConsoleColor.Green);
			return true;
		}
	}
}
