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
	class ExitCommand : IHubCommand
	{
		public async Task<bool> Execute(HubConnection hubConnection, string methodName)
		{
			return false;
		}
	}
}
