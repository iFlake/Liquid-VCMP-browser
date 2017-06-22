using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Liquid_VCMP_browser
{
    public partial class ServersContent : UserControl
    {
        protected ServerView servers;

        protected List<IPEndPoint> favoriteservers = new List<IPEndPoint>();
        protected List<IPEndPoint> officialservers = new List<IPEndPoint>();
        protected List<IPEndPoint> normalservers = new List<IPEndPoint>();

        public string FavoritesText
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

        public string OfficialText
        {
            set
            {
                label2.Text = value;
            }
            get
            {
                return label2.Text;
            }
        }
        public string NormalText
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

        public ServersContent()
        {
            InitializeComponent();
        }

        public void Redraw()
        {
            panel1.Controls.Clear();

            foreach (IPEndPoint server in favoriteservers)
            {

            }
        }

        protected async void LoadFavoriteServer()
        {
            
        }
        
        public void AddFavoriteServer(IPEndPoint host)
        {
            favoriteservers.Add(host);
        }
        
        public void AddOfficialServer(IPEndPoint host)
        {
            officialservers.Add(host);
        }

        public void AddNormalServer(IPEndPoint host)
        {
            normalservers.Add(host);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ServersContent_Load(object sender, EventArgs e)
        {

        }
    }
}
