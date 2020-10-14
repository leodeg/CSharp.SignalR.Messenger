using System;
using System.Collections.Generic;
using System.Text;

namespace Messenger.Common
{
	public class Message
	{
		public string Title { get; set; }
		public string Text { get; set; }
		public DateTime SendTime { get; set; } = DateTime.Now;
	}
}
