using Messenger.Common;
using System.Threading.Tasks;

namespace Messenger.Server.Hubs
{
	public interface INotificationClient
	{
		Task Send(Message message);
	}
}