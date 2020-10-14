using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Common;
using Messenger.Server.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Messenger.Server.Controllers.Api
{
	[ApiController]
	[Route("[controller]")]
	public class MessageController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Push([FromBody]NewMessage message,
			[FromServices]IHubContext<MessageHub, IMessageClient> hubContext)
		{
			await hubContext.Clients.All.Send(message);
			return Ok();
		}
	}
}
