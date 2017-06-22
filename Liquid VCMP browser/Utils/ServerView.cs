using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquid_VCMP_browser
{
    public partial class ServerView : UserControl
    {
        public ServerView()
        {
            InitializeComponent();
        }

        public string ServerName
        {
            set
            {
                label1.Text = value;
            }
            get
            {
                return label1.Text;
            }
        }

        public int Ping
        {
            set
            {
                label2.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(label2.Text);
            }
        }

        public string Players
        {
            set
            {
                label3.Text = value;
            }
            get
            {
                return label3.Text;
            }
        }

        public string Version
        {
            set
            {
                label4.Text = value;
            }
            get
            {
                return label4.Text;
            }
        }
        
        public string Gamemode
        {
            set
            {
                label5.Text = value;
            }
            get
            {
                return label5.Text;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
