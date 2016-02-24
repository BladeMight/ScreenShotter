using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Classes;
namespace ScreenShotter
{
    public partial class Configs : Form
    {
        private bool cb, tb, toob, xb, onopen = true;
        private string language, wasit;
        private string[] backupl;
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
                    MessageBox.Show(ScreenShotter.cc_lang[65], ScreenShotter.cc_lang[66], MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            jpgQualityBox.Text = 90.ToString();
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
        }
        public void Apply()
        {
            ScreenShotter.mus.ConsoleButton = cb;
            ScreenShotter.mus.TrayButton = tb;
            ScreenShotter.mus.Tooltips = toob;
            ScreenShotter.mus.ExitOnX = xb;
            ScreenShotter.mus.siFormat = format;
            ScreenShotter.mus.jpgQuality = jpgq;
            ScreenShotter.mus.lang = language;
            ScreenShotter.langchange();
            ScreenShotter.check.Start();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancell();
        }
        public void Cancell()
        {
            if (wasit != language)
            {
                ScreenShotter.cc_lang = backupl;
                language = wasit;
                ScreenShotter.langchange();
                ScreenShotter.check.Start();
            }
            onopen = true;
            ScreenShotter.console.Write(ScreenShotter.cc_lang[7] + " " + ScreenShotter.cc_lang[25]);
        }
        public void InstantLangChange()
        {
            if (language == "ru")
            {
                langLabel.Location = new Point(225, 62);
                langLabel.Size = new Size(66, 17);
                langLabel.TextAlign = ContentAlignment.MiddleCenter;
                ScreenShotter.cc_lang = Translations.lang_ru;
                ScreenShotter.console.Write(ScreenShotter.cc_lang[44] + "\"Русский\"");
            }
            if (language == "en")
            {
                langLabel.Location = new Point(168, 85);
                langLabel.Size = new Size(55, 15);
                langLabel.TextAlign = ContentAlignment.TopRight;
                ScreenShotter.cc_lang = Translations.lang_en;
                ScreenShotter.console.Write(ScreenShotter.cc_lang[44] + "\"English\"");
            }
            this.Text = ScreenShotter.cc_lang[4];
            consCheckbox.Text = ScreenShotter.cc_lang[34];
            TTCheckbox.Text = ScreenShotter.cc_lang[35];
            TooltipCheckbox.Text = ScreenShotter.cc_lang[36];
            XCheckbox.Text = ScreenShotter.cc_lang[37];
            langLabel.Text = ScreenShotter.cc_lang[38];
            jpgLabel.Text = ScreenShotter.cc_lang[39];
            sfLabel.Text = ScreenShotter.cc_lang[40];
            cancelButton.Text = ScreenShotter.cc_lang[41];
            dfltButton.Text = ScreenShotter.cc_lang[42];
        }
        private void Configs_VisibleChanged(object sender, EventArgs e)
        {
            if (ScreenShotter.mus.lang == "ru")
            {
                comboBox2.SelectedIndex = 1;
                langLabel.Location = new Point(225, 62);
                langLabel.Size = new Size(66, 17);
                langLabel.TextAlign = ContentAlignment.MiddleCenter;
            }
            if (ScreenShotter.mus.lang == "en")
            {
                comboBox2.SelectedIndex = 0;
                langLabel.Location = new Point(168, 85);
                langLabel.Size = new Size(55, 15);
                langLabel.TextAlign = ContentAlignment.TopRight;
            }
            language = ScreenShotter.mus.lang;
            wasit = ScreenShotter.mus.lang;
            backupl = ScreenShotter.cc_lang;
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
            onopen = false;
        }

        private void Configs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Cancell();
            }
        }
        #region Tooltips
        private void XCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(ScreenShotter.cc_lang[53], XCheckbox);
        }

        private void TooltipCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(ScreenShotter.cc_lang[54], TooltipCheckbox);
        }

        private void TTCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(ScreenShotter.cc_lang[55], TTCheckbox);
        }

        private void consCheckbox_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(ScreenShotter.cc_lang[56], consCheckbox);
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(ScreenShotter.cc_lang[57], sfLabel);
        }
        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(ScreenShotter.cc_lang[58], comboBox2);
        }
        #endregion

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onopen)
            {
                if (comboBox2.Text == "Русский")
                {
                    language = "ru";
                }
                else
                {
                    language = "en";
                }
            }
            InstantLangChange();
            ScreenShotter.check.Start();
        }
    }
}
