using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShotter
{
    public partial class ConsoleForm : Form
    {
        public ConsoleForm()
        {
            InitializeComponent();
        }
        public void Write(string log)
        {
            DateTime now = DateTime.Now;
            ConsoleText.Text += "> " + now.ToString("HH:mm:ss ") + log+ Environment.NewLine;
            ConsoleText.SelectionStart = ConsoleText.Text.Length;
            ConsoleText.ScrollToCaret();
        }

        private void ConsoleForm_Shown(object sender, EventArgs e)
        {
            this.Height = Owner.Height;
            this.Location = new Point(Owner.Left + Owner.Width, Owner.Top);
        }

        private void ConsoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Write("Console Hidden");
                ScreenShotter.cws = false;
                Hide();
            }
        }

        private void ConsoleForm_VisibleChanged(object sender, EventArgs e)
        {
            Owner.Controls["consButton"].Text = Visible ? "<" : ">";
        }
    }
}
