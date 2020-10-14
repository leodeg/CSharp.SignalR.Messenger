using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Common
{
	public class NewMessage : Message
	{
		public string Sender { get; set; }

		private NewMessage() { }

		public static NewMessage Create(string sender, Message message)
		{
			return new NewMessage
			{
				Sender = string.IsNullOrWhiteSpace(sender) ? "Anonymous" : sender,
				Title = message.Title,
				Text = message.Text
			};
		}
	}
}
