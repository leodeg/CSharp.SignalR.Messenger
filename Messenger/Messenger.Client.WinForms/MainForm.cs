using Messenger.Common;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger.Client.WinForms
{
	public partial class MainForm : Form
	{
		private const string URL = "http://localhost:2667/messages";

		private readonly HubConnection hubConnection;

		private const string SendToAll = "SendToAll";
		private const string SetName = "SetName";
		private const string GetName = "GetName";

		public MainForm()
		{
			InitializeComponent();

			hubConnection = new HubConnectionBuilder()
				.WithUrl(URL)
				.Build();

			hubConnection.On<NewMessage>("Send", message =>
			{
				AssinNewMessage(message.Sender, message.Text, Color.Black);
			});

			hubConnection.Closed += error =>
			{
				MessageBox.Show($"Connection closed. {error.Message}");
				return Task.CompletedTask;
			};

			hubConnection.Reconnected += id =>
			{
				MessageBox.Show($"Connection reconnected with id: {id}");
				return Task.CompletedTask;
			};

			hubConnection.Reconnecting += error =>
			{
				MessageBox.Show($"Connection reconnecting. {error.Message}");
				return Task.CompletedTask;
			};
		}

		private void AssinNewMessage(string sender, string text, Color color)
		{
			richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
			richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
			richTextBoxChat.SelectionLength = 0;

			richTextBoxChat.SelectionColor = color;
			richTextBoxChat.AppendText(string.Format("Author: {0}{2}Text: {1}{2}{2}", sender, text, Environment.NewLine));
			richTextBoxChat.SelectionColor = richTextBoxChat.ForeColor;
		}

		private async void buttonConnect_Click(object sender, EventArgs e)
		{
			if (hubConnection.State == HubConnectionState.Disconnected)
			{
				try
				{
					await hubConnection.StartAsync();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

				if (hubConnection.State == HubConnectionState.Connected)
				{
					buttonConnect.Text = "Disconnect";
					labelStateStatus.ForeColor = Color.Green;
					labelStateStatus.Text = "Connected";
				}
			}
			else if (hubConnection.State == HubConnectionState.Connected)
			{
				await hubConnection.StopAsync();
				buttonConnect.Text = "Connect";
				labelStateStatus.ForeColor = Color.Red;
				labelStateStatus.Text = "Disconnected";
			}
		}

		private async void buttonSend_Click(object sender, EventArgs e)
		{
			if (hubConnection.State == HubConnectionState.Connected)
			{
				var message = new Common.Message
				{
					Text = textBoxText.Text
				};

				try
				{

					await hubConnection.SendAsync(SendToAll, message);
					AssinNewMessage("Me", message.Text, Color.Green);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					textBoxText.Clear();
				}
			}
		}

		private async void buttonGet_Click(object sender, EventArgs e)
		{
			if (hubConnection.State == HubConnectionState.Connected)
			{
				try
				{
					var name = await hubConnection.InvokeAsync<string>(GetName);

					if (string.IsNullOrWhiteSpace(name))
						textBoxName.Text = "Anonymous";
					else textBoxName.Text = name;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private async void buttonSet_Click(object sender, EventArgs e)
		{
			if (hubConnection.State == HubConnectionState.Connected)
			{
				try
				{
					await hubConnection.SendAsync(SetName, textBoxName.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}


	}
}
