﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Messenger.Common;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Input;

namespace Messenger.Client.Console
{

	interface IHubCommand
	{
		Task<bool> Execute(HubConnection hubConnection, string methodName);
	}
}
