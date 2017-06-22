using CefSharp;
using CefSharp.WinForms;
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
    public partial class Dashboard : Form
    {
        protected ChromiumWebBrowser display;

        public Dashboard()
        {
            InitializeComponent();

            LoadFavorites();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = LanguageManager.language.phrases.servers;
            label2.Text = LanguageManager.language.phrases.settings;

            tab1._RightToLeft = LanguageManager.language.ltr == true ? RightToLeft.No : RightToLeft.Yes;
            tab1.Text = LanguageManager.language.phrases.favorites;

            tab2._RightToLeft = LanguageManager.language.ltr == true ? RightToLeft.No : RightToLeft.Yes;
            tab2.Text = LanguageManager.language.phrases.internet;

            tab3._RightToLeft = LanguageManager.language.ltr == true ? RightToLeft.No : RightToLeft.Yes;
            tab3.Text = LanguageManager.language.phrases.official;

            tab4._RightToLeft = LanguageManager.language.ltr == true ? RightToLeft.No : RightToLeft.Yes;
            tab4.Text = LanguageManager.language.phrases.settings;

            metroTextBox1.WaterMark = LanguageManager.language.phrases.nickname;


            metroTextBox1.Text = ConfigurationManager.configuration.defaultidentity.nickname;
            metroTextBox1.Select(metroTextBox1.Text.Length, 0);
        }
        
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        protected void LoadFavorites()
        {
            display = new ChromiumWebBrowser("file://" + Application.StartupPath + "/dsb/favorites.html");

            display.LoadingStateChanged += Display_LoadingStateChanged;

            InitDisplay();

            ClearTabSelections();
            tab1.Active = true;
        }

        protected void ClearTabSelections()
        {
            tab1.Active = false;
            tab2.Active = false;
            tab3.Active = false;
            tab4.Active = false;
        }

        protected void InitDisplay()
        {
            display.Dock = DockStyle.Fill;
            display.Parent = Content;
            display.Show();

            display.LoadingStateChanged += Display_LoadingStateChanged;
            display.MenuHandler = new NoMenuHandler();
        }

        private void Display_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                display.GetBrowser().MainFrame.ExecuteJavaScriptAsync("internationalize(\"" + EscapeJS(LanguageManager.language.phrases.favorites) + "\", \"" + EscapeJS(LanguageManager.language.phrases.internet) + "\", \"" + LanguageManager.language.phrases.normal + "\");");
            }
        }

        protected string EscapeJS(string str)
        {
            string output = "";

            foreach (char character in str)
            {
                output += string.Format("\\u{0:x4}", (int)character);
            }

            return output;
        }
    }

    public class NoMenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser wbrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
        }

        public bool OnContextMenuCommand(IWebBrowser wbrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand command, CefEventFlags flags)
        {
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser wbrowser, IBrowser browser, IFrame frame)
        {

        }

        public bool RunContextMenu(IWebBrowser wbrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
