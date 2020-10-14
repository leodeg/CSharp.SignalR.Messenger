using Messenger.Common;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Server.Hubs
{
	public class MessageHub : Hub<IMessageClient>
	{
		private const string Name = "user_name";
		private const string Anonymous = "Anonymous";

		#region Getters/Setters

		public Task SetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return Task.CompletedTask;

			if (Context.Items.ContainsKey(Name))
				Context.Items[Name] = name;
			else Context.Items.Add(Name, name);

			return Task.CompletedTask;
		}

		public Task<string> GetName()
		{
			if (Context.Items.ContainsKey(Name))
				return Task.FromResult(Context.Items[Name] as string);

			return Task.FromResult(Anonymous);
		}

		#endregion

		#region Send

		public Task SendToAll(Message message)
		{
			var messageForAll = NewMessage.Create(
				Context.Items[Name] as string,
				message);

			return Clients.Others.Send(messageForAll);
		}

		#endregion

		#region Override Events

		public override Task OnConnectedAsync()
		{
			Clients.Others.Send(GetInfoMessage("New cliend connected"));
			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			Clients.Others.Send(GetInfoMessage("Client disconnected"));
			return base.OnDisconnectedAsync(exception);
		}

		private NewMessage GetInfoMessage(string info, string text = null)
		{
			return NewMessage.Create(
				Context.ConnectionId,
				new Message
				{
					Title = $"{info}, from ID:{Context.ConnectionId}",
					Text = text ?? string.Empty
				}
			);
		}

		protected override void Dispose(bool disposing)
		{
			Debug.WriteLine("Hub disposed.");
			base.Dispose(disposing);
		}

		#endregion
	}
}
