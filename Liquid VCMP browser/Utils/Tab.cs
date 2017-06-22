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
    public partial class Tab : UserControl
    {
        public Tab()
        {
            InitializeComponent();
        }

        public bool Active
        {
            set
            {
                panel1.Visible = value;
                RecolorIcon(value);
                label1.ForeColor = value == true ? Color.FromArgb(0, 183, 195) : Color.FromArgb(0, 0, 0);
            }
            get
            {
                return panel1.Visible;
            }
        }

        public Image Icon
        {
            set
            {
                pictureBox1.BackgroundImage = value;
                RecolorIcon(Active);
            }
            get
            {
                return pictureBox1.BackgroundImage;
            }
        }

        public override string Text
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

        public RightToLeft _RightToLeft //Underscored because of a designer bug
        {
            set
            {
                label1.RightToLeft = value;
            }
            get
            {
                return label1.RightToLeft;
            }
        }

        private void RecolorIcon(bool active)
        {
            Bitmap bmap = (Bitmap) pictureBox1.BackgroundImage;

            /*for (int x = 0; x < pictureBox1.BackgroundImage.Width; ++x)
            {
                for (int y = 0; y < pictureBox1.BackgroundImage.Height; ++y)
                {
                    if (bmap.GetPixel(x, y).A > 0)
                    {
                        bmap.SetPixel(x, y, active == true ? Color.FromArgb(0, 183, 195) : Color.FromArgb(0, 0, 0));
                    }
                }
            }*/

            //Getting image's size breaks execution :(
        }

        private void Tab_Load(object sender, EventArgs e)
        {

        }

        private void Tab_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(255, 220, 220, 220);
        }

        private void Tab_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
        }
    }
}
