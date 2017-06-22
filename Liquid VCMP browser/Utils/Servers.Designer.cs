namespace Liquid_VCMP_browser
{
    partial class Servers
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroScrollBar1 = new MetroFramework.Controls.MetroScrollBar();
            this.serversContent1 = new Liquid_VCMP_browser.ServersContent();
            this.SuspendLayout();
            // 
            // metroScrollBar1
            // 
            this.metroScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroScrollBar1.LargeChange = 100;
            this.metroScrollBar1.Location = new System.Drawing.Point(730, 0);
            this.metroScrollBar1.Maximum = 100;
            this.metroScrollBar1.Minimum = 0;
            this.metroScrollBar1.MouseWheelBarPartitions = 10;
            this.metroScrollBar1.Name = "metroScrollBar1";
            this.metroScrollBar1.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this.metroScrollBar1.ScrollbarSize = 10;
            this.metroScrollBar1.Size = new System.Drawing.Size(10, 393);
            this.metroScrollBar1.TabIndex = 0;
            this.metroScrollBar1.UseSelectable = true;
            // 
            // serversContent1
            // 
            this.serversContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serversContent1.Location = new System.Drawing.Point(0, 0);
            this.serversContent1.Name = "serversContent1";
            this.serversContent1.Size = new System.Drawing.Size(730, 393);
            this.serversContent1.TabIndex = 1;
            // 
            // Servers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.serversContent1);
            this.Controls.Add(this.metroScrollBar1);
            this.Name = "Servers";
            this.Size = new System.Drawing.Size(740, 393);
            this.Resize += new System.EventHandler(this.Servers_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroScrollBar metroScrollBar1;
        private ServersContent serversContent1;
    }
}
