using Messenger.Common;
using System.Threading.Tasks;

namespace Messenger.Server.Hubs
{
	public interface IMessageClient
	{
		Task Send(NewMessage message);
	}
}