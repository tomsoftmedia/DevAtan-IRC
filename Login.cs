using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetaBuilders.Irc;
namespace DevAtanIRC
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General.client.SendChat("identify " + this.textBox1.Text, "nickserv");
        }
    }
    public static class General
    {
        public static Client client;
    }
}
