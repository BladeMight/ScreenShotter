using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenShotter
{
    public partial class Configs : Form
    {
        private bool cb, tb, toob, xb;
        private ImageFormat format;
        private long jpgq;
        public Configs()
        {
            InitializeComponent();
        }

        private void consCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            cb = consCheckbox.Checked;
        }

        private void TTCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            tb = TTCheckbox.Checked;
        }

        private void TooltipCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            toob = TooltipCheckbox.Checked;
        }

        private void XCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            xb = XCheckbox.Checked;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            jpgLabel.Visible = false;
            jpgQualityBox.Visible = false;
            if (comboBox1.SelectedIndex == 0)
            {
                format = ImageFormat.Jpeg;
                jpgLabel.Visible = true;
                jpgQualityBox.Visible = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                format = ImageFormat.Png;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                format = ImageFormat.Bmp;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                format = ImageFormat.Gif;
            }
        }
        bool clear = false;
        private void jpgQualityBox_TextChanged(object sender, EventArgs e)
        {
            if (clear == false)
            {
                if (!long.TryParse(jpgQualityBox.Text, out jpgq) || jpgq > 100 || jpgq < 0)
                {
                    clear = true;
                    MessageBox.Show("I must be a number!\nNumber must be from 0 to 100", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    jpgQualityBox.Text = "";
                }
                clear = false;
            }
        }
        private void dfltButton_Click(object sender, EventArgs e)
        {
            consCheckbox.Checked = false;
            TTCheckbox.Checked = true;
            TooltipCheckbox.Checked = true;
            XCheckbox.Checked = true;
            comboBox1.SelectedIndex = 1;
        }
        public void Apply()
        {
            ScreenShotter.mus.ConsoleButton = cb;
            ScreenShotter.mus.TrayButton = tb;
            ScreenShotter.mus.Tooltips = toob;
            ScreenShotter.mus.ExitOnX = xb;
            ScreenShotter.mus.siFormat = format;
            ScreenShotter.mus.jpgQuality = jpgq;

        }
        private void Configs_Load(object sender, EventArgs e)
        {
            TooltipCheckbox.Checked = ScreenShotter.mus.Tooltips;
            TTCheckbox.Checked = ScreenShotter.mus.TrayButton;
            consCheckbox.Checked = ScreenShotter.mus.ConsoleButton;
            XCheckbox.Checked = ScreenShotter.mus.ExitOnX;
            jpgLabel.Visible = false;
            jpgQualityBox.Visible = false;
            if (ScreenShotter.mus.siFormat == ImageFormat.Jpeg)
            {
                comboBox1.SelectedIndex = 0;
                jpgLabel.Visible = true;
                jpgQualityBox.Visible = true;
            }
            if (ScreenShotter.mus.siFormat == ImageFormat.Png)
            {
                comboBox1.SelectedIndex = 1;
            }
            if (ScreenShotter.mus.siFormat == ImageFormat.Bmp)
            {
                comboBox1.SelectedIndex = 2;
            }
            if (ScreenShotter.mus.siFormat == ImageFormat.Gif)
            {
                comboBox1.SelectedIndex = 3;
            }
            jpgQualityBox.Text = Convert.ToString(ScreenShotter.mus.jpgQuality);
        }

        private void Configs_FormClosing(object sender, FormClosingEventArgs e)
        {
            ScreenShotter.console.Write("Configs Window Closed.");
        }
        #region Tooltips
        private void XCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("While this enabled Main window closing Main Window will not end program\nto close program hit \"Exit\" in Tray Menu or CTRL + WIN + ALT + F4", XCheckbox);
        }

        private void TooltipCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Displays tooltips like this one in main form, when hovering something.", TooltipCheckbox);
        }

        private void TTCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("If this checked toogle tray button will be visible in main form.", TTCheckbox);
        }

        private void consCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Enabling this will show the console button in main form.", consCheckbox);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Select in which format, screenshots will be saved.", label1);
        }
        #endregion
    }
}
