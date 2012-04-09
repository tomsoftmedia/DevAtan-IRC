using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetaBuilders.Irc.Messages;
using MetaBuilders.Irc.Network;
using MetaBuilders.Irc;

namespace DevAtanIRC
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = true;
            textBox5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = true;
            button1.Enabled = false;
            button2.Enabled = true;
            RegisterMember(this.textBox5.Text, this.textBox3.Text, this.textBox2.Text);
        }
        private void welcomed(object xObject, IrcMessageEventArgs<WelcomeMessage> e)
        {
            client.SendChat("register " + pass + " " + email, "nickserv"); 
        }
        MetaBuilders.Irc.Client client;
        string email;
        string pass;
        public void RegisterMember(string user,string email, string pass)
        {
            client = new MetaBuilders.Irc.Client("irc.freenode.net", user);
            this.email = email;
            this.pass = pass;
            // Once I'm welcomed, I can start register
            client.Messages.Welcome += new EventHandler<IrcMessageEventArgs<WelcomeMessage>>(welcomed);
            client.Messages.Chat += new EventHandler<IrcMessageEventArgs<TextMessage>>(chatting);

            client.Messages.TimeRequest += new EventHandler<IrcMessageEventArgs<TimeRequestMessage>>(timeRequested);

            client.DataReceived += new EventHandler<ConnectionDataEventArgs>(dataGot);
            client.DataSent += new EventHandler<ConnectionDataEventArgs>(dataSent);

            client.Connection.Disconnected += new EventHandler<ConnectionDataEventArgs>(logDisconnected);

            client.EnableAutoIdent = false;

            // Since I'm a Windows.Forms application, i pass in this form to the Connect method so it can sync with me.
            try
            {
                client.Connection.Connect(this);
                textBox1.Text += "Connecting to Freenode..." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void logDisconnected( Object sender, ConnectionDataEventArgs e )
		{
			
		}

		private void dataGot( Object sender, ConnectionDataEventArgs e )
		{
            if (e.Data.Contains(" is now registered to "))
            {
                this.textBox1.Text = "";
                this.textBox1.Text += "Registration complete. Please check your e-mail for a registration code";
            }
            else
            {
                String data = e.Data;
                this.textBox1.Text += data + System.Environment.NewLine;
                this.textBox1.Select(this.textBox1.Text.Length - 1, 1);
                this.textBox1.ScrollToCaret();
            }
		}

		private void dataSent( Object sender, ConnectionDataEventArgs e )
		{

            string data = e.Data;
                this.textBox1.Text += data + System.Environment.NewLine;
                this.textBox1.Select(this.textBox1.Text.Length - 1, 1);
                this.textBox1.ScrollToCaret();
            
		}

		private void chatting( Object sender, IrcMessageEventArgs<TextMessage> e )
		{
            if (e.Message.Text.StartsWith(this.textBox2.Text + ":"))
            {
                Console.Beep();
            }
		}

		private void timeRequested( Object sender, IrcMessageEventArgs<TimeRequestMessage> e )
		{
			MetaBuilders.Irc.Messages.TimeReplyMessage reply = new MetaBuilders.Irc.Messages.TimeReplyMessage();
			reply.CurrentTime = DateTime.Now.ToLongTimeString();
			reply.Target = e.Message.Sender.Nick;
			client.Send( reply );
		}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label4.Visible == true)
            {
                client.SendChat("VERIFY REGISTER " + textBox5.Text + " " + textBox4.Text, "nickserv");
            }
        }

    }
}
