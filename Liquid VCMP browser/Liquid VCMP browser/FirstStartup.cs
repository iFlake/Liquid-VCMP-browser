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
    public partial class FirstStartup : Form
    {
        protected Dictionary<string, string> languages = new Dictionary<string, string>();

        public FirstStartup()
        {
            InitializeComponent();
        }
        
        private void FirstStartup_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConfigurationManager.configuration.defaultidentity.nickname = metroTextBox1.Text;

            ConfigurationManager.configuration.updater.url = metroTextBox2.Text;
            ConfigurationManager.configuration.updater.password = metroTextBox3.Text;
            ConfigurationManager.configuration.updater.check = checkBox1.Checked;

            ConfigurationManager.configuration.downloadmirror.url = metroTextBox5.Text;
            ConfigurationManager.configuration.downloadmirror.check = checkBox2.Checked;

            ConfigurationManager.configuration.directories.vicecity = metroTextBox4.Text;

            ConfigurationManager.configuration.internationalization.language = languages[comboBox1.Text];

            try
            {
                System.IO.File.Create(Application.StartupPath + "/vcmp-config.json").Close();
            }
            catch
            {
                Error error = new Error();
                error.labelError.Text = "Failed to create the file 'vcmp-config.json'";
                error.Show();

                Close();
            }

            try
            {
                ConfigurationManager.Save();
            }
            catch
            {
                Error error = new Error();
                error.labelError.Text = "Failed to save configuration";
                error.Show();

                Close();

                return;
            }

            Application.Restart();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            metroTextBox4.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void FirstStartup_Shown(object sender, EventArgs e)
        {
            string[] languagefiles = new string[0];

            try
            {
                languagefiles = System.IO.Directory.GetFiles(Application.StartupPath + "/internationalization");
            }
            catch
            {
                Error error = new Error();
                error.labelError.Text = "Failed to read directory 'internationalization' - please verify your installation";
                error.Show();

                Close();

                return;
            }

            foreach (string _language in languagefiles)
            {
                string language = System.IO.Path.GetFileName(_language).Replace(".json", "");

                try
                {
                    LanguageManager.Load(language);
                    languages.Add(LanguageManager.language.name, language);
                    comboBox1.Items.Add(LanguageManager.language.name);
                    comboBox1.SelectedItem = LanguageManager.language.name;
                }
                catch
                {
                    Error error = new Error();
                    error.labelError.Text = "Failed to process language file '" + language + "'";
                    error.Show();

                    Close();

                    return;
                }
            }
        }

        private void FirstStartup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
