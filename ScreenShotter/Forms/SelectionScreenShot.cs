using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenShotter
{
    public partial class SelectionScreenShot : Form
    {
        public SelectionScreenShot()
        {
            InitializeComponent();
            KeyDown += SelectionScreenShot_KeyDown;
        }

        void SelectionScreenShot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Hide();
                ScreenShotter.cancelled = true;
            }
        }
        public Bitmap selImage;
        private Rectangle selection = new Rectangle(0,0,0,0);
        private Point sPos;
        private void setPos()
        {
            Location = new Point(0, 0);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
        }

        private void SelectionScreenShot_Load(object sender, EventArgs e)
        {
            setPos();
        }

        private void SelectionScreenShot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                ScreenShotter.cancelled = true;
            }
        }

        private void SelectionScreenShot_MouseDown(object sender, MouseEventArgs e)
        {
            selection.Width = 0;
            selection.Height = 0;
            selection.X = e.X;
            selection.Y = e.Y;
            sPos.X = e.X;
            sPos.Y = e.Y;
        }
        private void SelectionScreenShot_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            int x = Math.Min(sPos.X, p.X);
            int y = Math.Min(sPos.Y, p.Y);
            Point loc = new Point(p.X + 20, p.Y + 10);
            if (loc.Y >= Screen.PrimaryScreen.Bounds.Height - 20)
            { loc.Y -= 30; }
            if (loc.X >= Screen.PrimaryScreen.Bounds.Width - 80)
            { loc.X -= 100; }
            if (e.Button == MouseButtons.Left)
            {
                int w = Math.Abs(p.X - sPos.X);
                int h = Math.Abs(p.Y - sPos.Y);
                Graphics g = this.CreateGraphics();
                selection = new Rectangle(x, y, w, h);
                ttSize.Show("W:" + w + " H:" + h, this, loc);
                this.Refresh();
                g.FillRectangle(Brushes.LightGray, selection);
            }
            if (e.Button == MouseButtons.None)
            {
                ttSize.Show("X:" + p.X + " Y:" + p.Y, this, loc);
            }
        }
        private void SelectionScreenShot_MouseUp(object sender, MouseEventArgs e)
        {
            if (selection.Height > 0 && selection.Width > 0)
            {
                selImage = new Bitmap(selection.Width, selection.Height);
                Graphics g = Graphics.FromImage(selImage as Image);
                Hide();
                g.CopyFromScreen(new Point(selection.Left, selection.Top), Point.Empty, selection.Size);
                g.Dispose();
            }
            else MessageBox.Show("Too small selection", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
