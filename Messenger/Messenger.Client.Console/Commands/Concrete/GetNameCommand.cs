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

	class GetNameCommand : IHubCommand
	{
		public async Task<bool> Execute(HubConnection hubConnection, string methodName)
		{
			string name = await hubConnection.InvokeAsync<string>(methodName);
			ConsoleExtenstions.Show($"\nYour name: {name}\n", ConsoleColor.Green);
			return true;
		}
	}
}
