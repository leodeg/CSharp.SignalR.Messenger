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
	class Program
	{
		private const string URL = "http://localhost:2667/messages";

		static async Task Main(string[] args)
		{
			IMessenger messenger = new Messenger(URL);
			await messenger.ConnectAsync();
			await messenger.StartChatAsync();
		}
	}
}
