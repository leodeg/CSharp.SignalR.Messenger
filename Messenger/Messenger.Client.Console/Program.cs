﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Messenger.Common;

namespace Messenger.Client.Console
{
	class Program
	{
		private const string URL = "http://localhost:2667/messages";

		static async Task Main(string[] args)
		{
			Messenger messenger = new Messenger(URL);
			await messenger.ConnectAsync();
			await messenger.StartChatAsync();
		}
	}

	public class Messenger
	{
		private const string SendMessage = "SendToAll";
		private const string SetName = "SetName";
		private const string GetName = "GetName";
		private HubConnection HubConnection;

		public Messenger(string connectionUrl)
		{
			HubConnection = new HubConnectionBuilder()
				.WithUrl(connectionUrl)
				.Build();

			AssignOnSendEvent();
		}

		private void AssignOnSendEvent()
		{
			HubConnection.On<NewMessage>("Send", message =>
			{
				System.Console.WriteLine();
				System.Console.WriteLine($"New message");
				System.Console.WriteLine($"Sender: {message.Sender}");
				System.Console.WriteLine($"Title: {message.Title}");
				System.Console.WriteLine($"Text: {message.Text}");
				System.Console.WriteLine();
			});
		}

		public async Task ConnectAsync()
		{
			await HubConnection.StartAsync();
		}

		public async Task StartChatAsync()
		{
			bool isExit = false;

			while (!isExit)
			{
				System.Console.WriteLine("Enter your message or command:");

				var input = System.Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
					continue;

				if (input == "exit")
				{
					isExit = true;
				}
				else if (input == "setname")
				{
					System.Console.WriteLine("Please write your name: ");

					string name = System.Console.ReadLine();

					if (string.IsNullOrWhiteSpace(name))
					{
						System.Console.WriteLine("Name is not valid.");
						continue;
					}

					await HubConnection.SendAsync(SetName, name);

					System.Console.WriteLine("Name sent");
					System.Console.WriteLine();
				}
				else if (input == "getname")
				{
					System.Console.WriteLine();
				}
				else
				{
					var message = new Message
					{
						Title = "New Message",
						Text = input
					};

					await HubConnection.SendAsync(SendMessage, message);

					System.Console.WriteLine("Message sent");
					System.Console.WriteLine();
				}
			}

			System.Console.WriteLine("Press any key...");
			System.Console.ReadLine();
		}
	}
}
