using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MetaBuilders.Irc.Messages;
using MetaBuilders.Irc.Network;
using MetaBuilders.Irc;
using System.Diagnostics;
using System.IO;
using DevAtanIRC;
using System.Collections.Generic;
namespace DevAtanIRC
{
    
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button GoCommand;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox ChatEntry;
		private System.Windows.Forms.Button SayIt;
		private System.Windows.Forms.Button SendIt;
		private Button button2;
        private TextBox textBox2;
        private Label label3;
        bool isReady = false;
        private Button button3;
        private Button button4;
        private ListBox listBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			String logFolder = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ), @"DevAtan" );
			String logFile = Path.Combine( logFolder, "Log.txt" );

			Trace.Listeners.Clear();
			DefaultTraceListener defaultListener;
			defaultListener = new DefaultTraceListener();
			Trace.Listeners.Add( defaultListener );
			defaultListener.LogFileName = logFile;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				if ( components != null )
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GoCommand = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ChatEntry = new System.Windows.Forms.TextBox();
            this.SayIt = new System.Windows.Forms.Button();
            this.SendIt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // GoCommand
            // 
            this.GoCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoCommand.Location = new System.Drawing.Point(620, 44);
            this.GoCommand.Name = "GoCommand";
            this.GoCommand.Size = new System.Drawing.Size(112, 23);
            this.GoCommand.TabIndex = 4;
            this.GoCommand.Text = "Connect And Join";
            this.GoCommand.Click += new System.EventHandler(this.GoCommand_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(8, 86);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(585, 364);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(518, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Disconnect";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChatEntry
            // 
            this.ChatEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatEntry.Location = new System.Drawing.Point(8, 457);
            this.ChatEntry.Name = "ChatEntry";
            this.ChatEntry.Size = new System.Drawing.Size(662, 20);
            this.ChatEntry.TabIndex = 8;
            this.ChatEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatEntry_KeyPress);
            // 
            // SayIt
            // 
            this.SayIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SayIt.Location = new System.Drawing.Point(676, 456);
            this.SayIt.Name = "SayIt";
            this.SayIt.Size = new System.Drawing.Size(64, 23);
            this.SayIt.TabIndex = 9;
            this.SayIt.Text = "Say";
            this.SayIt.Click += new System.EventHandler(this.SayIt_Click);
            // 
            // SendIt
            // 
            this.SendIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendIt.Location = new System.Drawing.Point(184, 44);
            this.SendIt.Name = "SendIt";
            this.SendIt.Size = new System.Drawing.Size(64, 23);
            this.SendIt.TabIndex = 10;
            this.SendIt.Text = "About";
            this.SendIt.Click += new System.EventHandler(this.SendIt_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(411, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Log";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(8, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(724, 20);
            this.textBox2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(293, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Register";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(80, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Log in";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Users:"});
            this.listBox1.Location = new System.Drawing.Point(612, 86);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 355);
            this.listBox1.TabIndex = 16;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(752, 486);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SendIt);
            this.Controls.Add(this.SayIt);
            this.Controls.Add(this.ChatEntry);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GoCommand);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Name = "Form1";
            this.Text = "DevAtan IRC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion



       
		private void GoCommand_Click( object sender, System.EventArgs e )
		{
            
			// Create a new General.client to the given address with the given nick
			General.client = new Client("irc.freenode.net", this.textBox2.Text );
			Ident.Service.User = General.client.User;


			// Once I'm welcomed, I can start joining channels
			General.client.Messages.Welcome += new EventHandler<IrcMessageEventArgs<WelcomeMessage>>( welcomed );

			
			General.client.Messages.Chat += new EventHandler<IrcMessageEventArgs<TextMessage>>( chatting );

			General.client.Messages.TimeRequest += new EventHandler<IrcMessageEventArgs<TimeRequestMessage>>( timeRequested );

			General.client.DataReceived += new EventHandler<ConnectionDataEventArgs>( dataGot );
			General.client.DataSent += new EventHandler<ConnectionDataEventArgs>( dataSent );

			General.client.Connection.Disconnected += new EventHandler<ConnectionDataEventArgs>( logDisconnected );

			General.client.EnableAutoIdent = false;

			// Since I'm a Windows.Forms application, i pass in this form to the Connect method so it can sync with me.
			try
			{
				General.client.Connection.Connect( this );
                textBox1.Text += "Connecting to Freenode..." + Environment.NewLine;
			}
			catch ( Exception ex )
			{
				MessageBox.Show( ex.Message );
			}

		}

		private void logDisconnected( Object sender, ConnectionDataEventArgs e )
		{
			String data = "*** Disconnected: " + e.Data;
			this.textBox1.Text += data + System.Environment.NewLine;
			this.textBox1.Select( this.textBox1.Text.Length - 1, 1 );
			this.textBox1.ScrollToCaret();
		}

		private void dataGot( Object sender, ConnectionDataEventArgs e )
		{
            if (isReady)
            {
                if (e.Data.StartsWith("PING"))
                {
                    textBox1.Text += "Ping request recieved!" + Environment.NewLine;
                  
                }
                else if (e.Data.StartsWith("ERROR"))
                {
                    //Ignore
                }
                else if (e.Data.Contains("ACTION"))
                {
                    int a = e.Data.IndexOf('');
                    string sub = e.Data.Substring(a + 8);
                    char[] datachars = e.Data.ToCharArray();
                    string user = "";
                    for (int i = 0; i < datachars.Length; i++)
                    {
                        if (datachars[i] == '!')
                        {
                            break;
                        }
                        else
                        {
                            user += datachars[i];
                        }
                    }
                    user = user.Substring(1);
                    textBox1.Text +=  user + " " + sub + Environment.NewLine;
                }
                else
                {
                    String data = e.Data;
                    char[] datachars = data.ToCharArray();
                    string user = "";
                    for (int i = 0; i < datachars.Length; i++)
                    {
                        if (datachars[i] == '!')
                        {
                            break;
                        }
                        else
                        {
                            user += datachars[i];
                        }
                    }
                    user = user.Substring(1);
                    string message = "";
                    int start = 0;
                    for (int i = 0; i < datachars.Length; i++)
                    {
                        if (datachars[i] == ':')
                        {
                            start++;
                        }
                        if (start >= 2)
                        {
                            message += datachars[i];
                        }
                    }
                    this.textBox1.Text += "<" + user + "> :" + message + System.Environment.NewLine;
                    this.textBox1.Select(this.textBox1.Text.Length - 1, 1);
                    this.textBox1.ScrollToCaret();
                }
            }
            else if (e.Data.Contains("End of /NAMES list."))
            {
                isReady = true;
                textBox1.Text += "Connected!" + Environment.NewLine;
                for (int i = 0; i < General.client.Channels[0].Users.Count; i++)
                {
                    listBox1.Items.Add(General.client.Channels[0].Users[i].Nick);
                }
            }
            else if (e.Data.Contains("This nickname is registered. Please choose a different nickname, or identify via /msg NickServ identify <password>."))
            {
                textBox1.Text += "Nickname registered. Please authorize through the log in button or disconnect and choose a different nickname" + Environment.NewLine;
            }
            
		}

		private void dataSent( Object sender, ConnectionDataEventArgs e )
		{
            if (isReady)
            {
               
                string data = "<" + textBox2.Text + "> :" + e.Data.Substring(17);
                this.textBox1.Text += data + System.Environment.NewLine;
                this.textBox1.Select(this.textBox1.Text.Length - 1, 1);
                this.textBox1.ScrollToCaret();
            }
		}

		private void chatting( Object sender, IrcMessageEventArgs<TextMessage> e )
		{
            if (e.Message.Text.StartsWith(this.textBox2.Text + ":"))
            {
                Console.Beep(1000,500);
            }
		}

		private void timeRequested( Object sender, IrcMessageEventArgs<TimeRequestMessage> e )
		{
			MetaBuilders.Irc.Messages.TimeReplyMessage reply = new MetaBuilders.Irc.Messages.TimeReplyMessage();
			reply.CurrentTime = DateTime.Now.ToLongTimeString();
			reply.Target = e.Message.Sender.Nick;
			General.client.Send( reply );
		}

		private void welcomed( Object sender, IrcMessageEventArgs<WelcomeMessage> e )
		{
			General.client.SendJoin("#devatan");
            textBox1.Text += "Connecting to channel..." + Environment.NewLine;
            General.client.DefaultQuitMessage = "DevAtan IRC - faster, easier, better";
        }



        public string[] users;
		private void button1_Click( object sender, System.EventArgs e )
		{
			if ( General.client != null )
			{
				General.client.SendQuit("DevAtan IRC - The best IRC client for DevAtan");
			}
		}
        /*List<IPlugin> _plugins;
        public void LoadPlugins(string path)
        {
            _plugins = new List<IPlugin>();
            string[] files = Directory.GetFiles(path, "*.dll");
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(new FileInfo(files[i]).FullName);
                    Type[] pluginTypes = assembly.GetTypes();
                    for (int j = 0; j < pluginTypes.Length; j++)
                    {
                        if (pluginTypes[j].GetInterfaces().Contains(typeof(IPlugin)))
                        {
                            
                            Console.WriteLine(files[i]);
                            IPlugin iCCPlugin = (IPlugin)Activator.CreateInstance(pluginTypes[i]);
                            _plugins.Add(iCCPlugin);
                            MessageBox.Show("Got plugin!");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }*/
		private void SayIt_Click( object sender, System.EventArgs e )
		{
            if (this.ChatEntry.Text.StartsWith("/msg"))
            {
                string[] arr = this.ChatEntry.Text.Split(' ');
                string target = arr[1];
                string message = "";
                for (int i = 2; i < arr.Length; i++)
                {
                    message += arr[i];
                    message += " ";
                }
                General.client.SendChat(message, target);
            }
            else if (this.ChatEntry.Text.StartsWith("/me"))
            {
                General.client.SendChat("ACTION " + this.ChatEntry.Text.Substring(4), "#devatan");
            }
            else
            {
	    		General.client.SendChat( this.ChatEntry.Text, "#devatan" );
		    	this.ChatEntry.Text = "";
            }
		}

		private void About_Click( object sender, System.EventArgs e )
		{
			MetaBuilders.Irc.Messages.GenericMessage msg = new MetaBuilders.Irc.Messages.GenericMessage();
			if ( msg.CanParse( this.ChatEntry.Text ) )
			{
				msg.Parse( this.ChatEntry.Text );
				General.client.Send( msg );
			}
			else
			{
				MessageBox.Show( "Cannot Parse Your Command." );
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			System.Diagnostics.Trace.WriteLine( "Stuff" );
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SendIt_Click(object sender, EventArgs e)
        {
            AboutBox abtbox = new AboutBox();
            abtbox.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DevAtanIRC.Register reg = new Register();
            reg.Show();
        }

        private void ChatEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SayIt_Click(this, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

	}
    public static class ArrayHelper
    {
        public static bool Contains(this object[] haystack, object needle)
        {
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
