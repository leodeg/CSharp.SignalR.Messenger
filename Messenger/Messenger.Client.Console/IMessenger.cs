using System.Threading.Tasks;

namespace Messenger.Client.Console
{
	public interface IMessenger
	{
		Task ConnectAsync();
		Task StartChatAsync();
	}
}