namespace Messenger.Client.WinForms
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelState = new System.Windows.Forms.Label();
			this.labelStateStatus = new System.Windows.Forms.Label();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonSet = new System.Windows.Forms.Button();
			this.buttonGet = new System.Windows.Forms.Button();
			this.labelText = new System.Windows.Forms.Label();
			this.textBoxText = new System.Windows.Forms.TextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// labelState
			// 
			this.labelState.AutoSize = true;
			this.labelState.Location = new System.Drawing.Point(16, 16);
			this.labelState.Name = "labelState";
			this.labelState.Size = new System.Drawing.Size(33, 15);
			this.labelState.TabIndex = 0;
			this.labelState.Text = "State";
			// 
			// labelStateStatus
			// 
			this.labelStateStatus.AutoSize = true;
			this.labelStateStatus.Location = new System.Drawing.Point(55, 16);
			this.labelStateStatus.Name = "labelStateStatus";
			this.labelStateStatus.Size = new System.Drawing.Size(79, 15);
			this.labelStateStatus.TabIndex = 0;
			this.labelStateStatus.Text = "Disconnected";
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(153, 12);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(75, 23);
			this.buttonConnect.TabIndex = 1;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(16, 45);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(39, 15);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(61, 42);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(167, 23);
			this.textBoxName.TabIndex = 2;
			this.textBoxName.Text = "Anonymous";
			// 
			// buttonSet
			// 
			this.buttonSet.Location = new System.Drawing.Point(152, 72);
			this.buttonSet.Name = "buttonSet";
			this.buttonSet.Size = new System.Drawing.Size(75, 23);
			this.buttonSet.TabIndex = 3;
			this.buttonSet.Text = "Set";
			this.buttonSet.UseVisualStyleBackColor = true;
			this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// buttonGet
			// 
			this.buttonGet.Location = new System.Drawing.Point(71, 72);
			this.buttonGet.Name = "buttonGet";
			this.buttonGet.Size = new System.Drawing.Size(75, 23);
			this.buttonGet.TabIndex = 3;
			this.buttonGet.Text = "Get";
			this.buttonGet.UseVisualStyleBackColor = true;
			this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(16, 103);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(28, 15);
			this.labelText.TabIndex = 4;
			this.labelText.Text = "Text";
			// 
			// textBoxText
			// 
			this.textBoxText.Location = new System.Drawing.Point(61, 103);
			this.textBoxText.Multiline = true;
			this.textBoxText.Name = "textBoxText";
			this.textBoxText.Size = new System.Drawing.Size(166, 157);
			this.textBoxText.TabIndex = 5;
			// 
			// buttonSend
			// 
			this.buttonSend.Location = new System.Drawing.Point(153, 266);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(75, 23);
			this.buttonSend.TabIndex = 3;
			this.buttonSend.Text = "Send";
			this.buttonSend.UseVisualStyleBackColor = true;
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// richTextBoxChat
			// 
			this.richTextBoxChat.Location = new System.Drawing.Point(234, 12);
			this.richTextBoxChat.Name = "richTextBoxChat";
			this.richTextBoxChat.Size = new System.Drawing.Size(588, 387);
			this.richTextBoxChat.TabIndex = 6;
			this.richTextBoxChat.Text = "";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 411);
			this.Controls.Add(this.richTextBoxChat);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.textBoxText);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.buttonGet);
			this.Controls.Add(this.buttonSet);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.labelStateStatus);
			this.Controls.Add(this.labelState);
			this.MaximumSize = new System.Drawing.Size(850, 450);
			this.MinimumSize = new System.Drawing.Size(850, 450);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Messenger";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelState;
		private System.Windows.Forms.Label labelStateStatus;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Button buttonSet;
		private System.Windows.Forms.Button buttonGet;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.TextBox textBoxText;
		private System.Windows.Forms.Button buttonSend;
		private System.Windows.Forms.Button b;
		private System.Windows.Forms.RichTextBox richTextBoxChat;
	}
}

