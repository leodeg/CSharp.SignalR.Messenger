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

	public static class ConsoleExtenstions
	{
		public static void Show(string text, ConsoleColor color)
		{
			System.Console.ForegroundColor = color;
			System.Console.WriteLine(text);
			System.Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
