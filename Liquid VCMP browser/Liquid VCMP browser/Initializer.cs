using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liquid_VCMP_browser
{
    public partial class Initializer : Form
    {
        public Initializer()
        {
            InitializeComponent();
        }

        private void Initializer_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (System.IO.File.Exists(Application.StartupPath + "/vcmp-config.json") == false)
            {
                this.Invoke(new Action(() =>
                {
                    FirstStartup firststartup = new FirstStartup(); firststartup.Show(); this.Hide();
                }));
                return;
            }

            try
            {
                ConfigurationManager.Load();
            }
            catch
            {
                this.Invoke(new Action(() =>
                {
                    Error error = new Error();
                    error.labelError.Text = "Failed to load configuration";
                    error.Show();
                    Hide();
                    return;
                }));
            }

            try
            {
                LanguageManager.Load();
            }
            catch
            {
                this.Invoke(new Action(() =>
                {
                    Error error = new Error();
                    error.labelError.Text = "Failed to load internationalization";
                    error.Show();
                    Hide();
                    return;
                }));
            }

            this.Invoke(new Action(() =>
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                Hide();
            }));
        }

        private void Initializer_Load(object sender, EventArgs e)
        {

        }
    }
}
