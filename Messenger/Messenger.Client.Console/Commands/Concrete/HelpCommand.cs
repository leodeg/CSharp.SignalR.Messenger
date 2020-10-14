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

	class HelpCommand : IHubCommand
	{
		public async Task<bool> Execute(HubConnection hubConnection, string methodName)
		{
			System.Console.WriteLine();
			System.Console.WriteLine("- exit");
			System.Console.WriteLine("- help");
			System.Console.WriteLine("- setname");
			System.Console.WriteLine("- getname");
			System.Console.WriteLine("- sendmessage");
			System.Console.WriteLine();
			return true;
		}
	}
}
