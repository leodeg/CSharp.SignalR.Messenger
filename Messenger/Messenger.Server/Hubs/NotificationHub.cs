using Messenger.Common;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Server.Hubs
{
	public class NotificationHub : Hub<INotificationClient>
	{
		private const string UserName = "user_name";
		private const string AnonymousUser = "Anonymous user";

		private string TryGetUserName()
		{
			if (Context.Items.ContainsKey(UserName))
				return Context.Items[UserName] as string;
			return null;
		}

		public Task SetName(string name)
		{
			Context.Items.TryAdd(UserName, name);
			return Task.CompletedTask;
		}

		public Task SendMessage(Message message)
		{
			Debug.WriteLine(Context.ConnectionId);
			message.Title = $"Message from user: {TryGetUserName() ?? AnonymousUser}";
			return Clients.Others.Send(message);
		}

		public override Task OnConnectedAsync()
		{
			var message = new Message
			{
				Title = $"New client connected, ID: {Context.ConnectionId}",
				Body = string.Empty
			};

			Clients.Others.Send(message);
			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			var message = new Message
			{
				Title = $"Client disconnected: {TryGetUserName() ?? AnonymousUser}, ID: {Context.ConnectionId}",
				Body = string.Empty
			};

			Clients.Others.Send(message);
			return base.OnDisconnectedAsync(exception);

		}

		protected override void Dispose(bool disposing)
		{
			Debug.WriteLine("Hub disposed.");
			base.Dispose(disposing);
		}
	}
}
