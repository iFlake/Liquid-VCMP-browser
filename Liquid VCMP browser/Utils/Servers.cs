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
    public partial class Servers : UserControl
    {
        public string FavoritesText
        {
            set
            {
                serversContent1.FavoritesText = value;
            }
            get
            {
                return serversContent1.FavoritesText;
            }
        }

        public string InternetText
        {
            set
            {
                serversContent1.OfficialText = value;
            }
            get
            {
                return serversContent1.OfficialText;
            }
        }

        public string OfficialText
        {
            set
            {
                serversContent1.OfficialText = value;
            }
            get
            {
                return serversContent1.OfficialText;
            }
        }

        public Servers()
        {
            InitializeComponent();
        }

        private void Servers_Resize(object sender, EventArgs e)
        {
            metroScrollBar1.LargeChange = 0;
            metroScrollBar1.Maximum = Height;
        }
    }
}
