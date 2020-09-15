using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Media;
using System.IO;
using System.Threading;
using System.Linq;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Classes;
namespace ScreenShotter
{
    public partial class ScreenShotter : Form
    {
        #region Variables
        public static bool cws = false, cwsw = false, force = false, ssws = false, cancelled = false, _sound = true;
        public static Bitmap ScSh = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        public FolderBrowserDialog Selpath;
        public static Configs muc = new Configs();
        private HotkeyHandler ScrShHK, ScrShshhHK, ScrShExit, Oplast, SelScrShot, curWindowSS;
        private ConfigsForm configs = new ConfigsForm();
        public static ConsoleForm console = new ConsoleForm();
        private SelectionScreenShot selSCR = new SelectionScreenShot();
        private AboutBox About;
        public static string[] cc_lang;
        public static System.Windows.Forms.Timer check = new System.Windows.Forms.Timer();
        TrayIcon icon;
        SoundPlayer sound = new SoundPlayer(Properties.Resources.sound);
        #endregion
        public ScreenShotter()
        {
//            if (muc.Read("Main","lang") == "")
//            {
//                muc.Read("Main","lang") ="en";
//            }
            if (!File.Exists(Configs.filePath))
            {
            	muc.Write("Main","TrayShow","true");
	            var syslang = System.Globalization.CultureInfo.CurrentCulture;
	            if (Convert.ToString(syslang) == "ru-RU")
	            {
	            	muc.Write("Main","lang","ru");
	            }
           		langchange();
                icon.ShowTooltip(cc_lang[68], cc_lang[69]);
            }
            langchange();
            check.Tick += new EventHandler(checkis);
            check.Interval = 50;
            check.Start();
            langchange();
            cwl(cc_lang[9]);
            AddOwnedForm(configs);
            AddOwnedForm(console);
            AddOwnedForm(selSCR);
            InitializeComponent();
            ScrShHK = new HotkeyHandler(Modifiers.ALT, Keys.F3, this);
            ScrShshhHK = new HotkeyHandler(Modifiers.ALT + Modifiers.CTRL, Keys.F3, this);
            ScrShExit = new HotkeyHandler(Modifiers.ALT + Modifiers.CTRL + Modifiers.WIN, Keys.F4, this);
            Oplast = new HotkeyHandler(Modifiers.ALT + Modifiers.SHIFT, Keys.F3, this);
            SelScrShot = new HotkeyHandler(Modifiers.CTRL + Modifiers.SHIFT, Keys.F3, this);
            curWindowSS = new HotkeyHandler(Modifiers.CTRL, Keys.F3, this);
            Selpath = new FolderBrowserDialog();
            ScrShHK.Register();
            ScrShshhHK.Register();
            ScrShExit.Register();
            Oplast.Register();
            curWindowSS.Register();
            SelScrShot.Register();
            InitializeTrayIcon();
            About = new AboutBox();
            _sound = muc.ReadBool("Main", "sound");
            CurrentWindowScreenShot.WinShadow = muc.ReadInt("Main", "WShadow");
            MemoryManagement.FlushMemory();
        }
        #region Functions
        public static void langchange()
        {
        	switch(muc.Read("Main","lang"))
        	{
        		case "en":
               		cc_lang = Translations.lang_en;
        			break;
        		case "ru":
        			cc_lang = Translations.lang_ru;
        			break;
        		default:
        			cc_lang = Translations.lang_en;
        			break;        			
        	}
        }
        public static string ifru(string ending)
        {
            string ifru = "";
            if (muc.Read("Main","lang") == "ru")
            { ifru = ending;
            return ifru;
            }
            return ifru;
        }
        public void checkis(object sender, EventArgs e)
        {
            if (muc.ReadBool("Main","TrayShow") == true)
            {
                ttButton.Text = ScreenShotter.cc_lang[8] + " " + ScreenShotter.cc_lang[0] + ifru("а");
            }
            else
            {
                ttButton.Text = ScreenShotter.cc_lang[8] + " " + ScreenShotter.cc_lang[1] + ifru("а");
            }
            spButton.Text = cc_lang[31];
            lstButton.Text = cc_lang[32];
            if (muc.Read("Main","Path") != "")
            {
                pathLabel.Text = cc_lang[17] + ":" + Environment.NewLine + muc.Read("Main","Path");
            }
            else
            {
                pathLabel.Text = cc_lang[17] + ":" + Environment.NewLine + cc_lang[33];
            }
            console.Text = cc_lang[45];
            icon.RefreshMenu();
            About.RefreshAll();
            check.Stop();
        }
        private void InitializeTrayIcon()
        {
        	icon = new TrayIcon(muc.ReadBool("Main","TrayShow"));
            icon.ShowClick += icon_DoubleClick;
            icon.ExitClick += icon_ExitClick;
            icon.Click += icon_DoubleClick;
            icon.AboutClick += icon_AboutClick;
            icon.ConfigsClick += confButton_Click;
            cwl( cc_lang[8] +" " + cc_lang[10]);
        }
        public void cwl(string log)
        {
            console.Write(log+".");
        }
        private void ApplySave()
        {
            cwl(cc_lang[4] + " " + cc_lang[2]);
            MemoryManagement.FlushMemory();
        }
        private void TooltipShow(string text, IWin32Window window)
        {
            if (muc.ReadBool("Main","Tooltips") == true)
            {
                toolTip.Show(text, window);
            }
            else { toolTip.Hide(window); }
            MemoryManagement.FlushMemory();
        }
        private void HideTogether()
        {
            if (Visible == true)
            {
                if (cws == true)
                {
                    cws = false;
                    console.Hide();
                }
                MainWindowHide();
            }
            else { if (cwsw == true) { cws = true; console.Show(); } MainWindowShow(); this.Activate(); }
            MemoryManagement.FlushMemory();
        }
        private void ReferenceVisibility()
        {
            if (muc.ReadBool("Main","ConsoleButton") == true)
            {
                consButton.Visible = true;

            }else { consButton.Visible = false; }
            if (muc.ReadBool("Main","TrayButton") == true)
            {
                ttButton.Visible = true;
            }else { ttButton.Visible = false; }
            if (muc.ReadBool("Main","Tooltips") == true)
            {
                Info.Visible = true;
            }
            else { Info.Visible = false; }
            MemoryManagement.FlushMemory();
        }
        private void SSConsoleHide()
        {
            console.Hide();
            cwl(cc_lang[5] + " " + cc_lang[1] + ifru("а"));
            MemoryManagement.FlushMemory();
        }
        private void SSConsoleShow()
        {
            console.Show();
            cwl(cc_lang[5] + " " + cc_lang[0] + ifru("а"));
            MemoryManagement.FlushMemory();
        }
        private void ShowHideAbout()
        {
            if (About.Visible == true)
            {
                About.Hide();
            }
            else { About.ShowDialog(); }
            MemoryManagement.FlushMemory();
        }
        private void MainWindowShow()
        {
            Show();
            TopMost = true;
            Thread.Sleep(1);
            TopMost = false;
            cwl(cc_lang[6] + " " + cc_lang[0] + ifru("о"));
            MemoryManagement.FlushMemory();
        }
        private void MainWindowHide()
        {
            Hide();
            cwl(cc_lang[6] + " " + cc_lang[1] + ifru("о"));
            MemoryManagement.FlushMemory();
        }
        private void checkFileExist()
        {
            if (!File.Exists(@muc.Read("Main","LastPath")) && muc.Read("Main","LastPath") !="")
            {
                cwl(cc_lang[11] +"(" + muc.Read("Main","LastPath") + ")" + cc_lang[12]);
                pictureBox1.Image = null;
                lstButton.Visible = false;
                SasLabel.Text = "";
                muc.Write("Main","LastPath","");
            }
        }
        private void saveImage(string path, Bitmap image, string format, long ifjpgQuality)
        {
            if ((ImageFormat)new ImageFormatConverter().ConvertFromString(format) == ImageFormat.Jpeg)
            {
                var enc = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                var encQ = new EncoderParameters() { Param = new[] { new EncoderParameter(Encoder.Quality, ifjpgQuality) } };
                image.Save(path, enc, encQ);
            }else
            {
            	image.Save(path, (ImageFormat)new ImageFormatConverter().ConvertFromString(format));
            }
        }
        #endregion
        #region Hotkey Handlers & WNDPROC
        private void HandleHotkey()
        {
            Graphics SS = Graphics.FromImage(ScSh as Image);
            SS.CopyFromScreen(0, 0, 0, 0, ScSh.Size);
            cwl(cc_lang[13]);
            cwl(cc_lang[14]);
            if (_sound)
            	sound.Play();
            DateTime now = DateTime.Now;
            string name = now.ToString("yyyy-MM-dd,hh-mm-ss");
            string dateString = string.Format(@"{0}{1}", muc.Read("Main","Path"), name + "." + muc.Read("Main","Format"));
            cwl(cc_lang[20] + name);
            SasLabel.Text = cc_lang[11]+ cc_lang[21] + ":" + Environment.NewLine + dateString;
            saveImage(dateString, ScSh, muc.Read("Main","Format"), muc.ReadInt("Main","jpgQuality"));
            pictureBox1.Image = ScSh;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            cwl(cc_lang[11] + cc_lang[21] + " " + dateString);
            cwl(cc_lang[16]);
            muc.Write("Main", "LastPath",dateString);
            if (lstButton.Visible == false)
            {
                cwl(cc_lang[22]);
                lstButton.Visible = true;
            }
            SS.Dispose();
            MemoryManagement.FlushMemory();
        }
        private void ExitHandler()
        {
            force = true;
            ApplySave();
            icon.Hide();
            Refresh();
            Application.Exit();
        }
        private void SelShotHandler()
        {
            if (ssws == false)
            {
                ssws = true;
                selSCR.ShowDialog();
                if (cancelled == false)
                {
                    ScSh = selSCR.selImage;
                    cwl(cc_lang[13]);
                    cwl(cc_lang[14]);
                    if (_sound)
                	    sound.Play();
                    DateTime now = DateTime.Now;
                    string name = now.ToString("yyyy-MM-dd,hh-mm-ss") + "-Selection";
                    string dateString = string.Format(@"{0}{1}", muc.Read("Main","Path"), name + "." +  muc.Read("Main","Format"));
                    cwl(cc_lang[20] + name);
                    SasLabel.Text = cc_lang[11] + cc_lang[21] + ":" + Environment.NewLine + dateString;
                    saveImage(dateString,ScSh, muc.Read("Main","Format"), muc.ReadInt("Main","jpgQuality"));
                    pictureBox1.Image = ScSh;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    cwl(cc_lang[11] + cc_lang[21] + " " + dateString);
                    cwl(cc_lang[16]);
                    muc.Write("Main", "LastPath",dateString);
                    if (lstButton.Visible == false)
                    {
                        cwl(cc_lang[22]);
                        lstButton.Visible = true;
                    }
                }
                cancelled = false;
                ssws = false;
            }
            MemoryManagement.FlushMemory();
        }
        private void curWindSSHandler()
        {
            ScSh = CurrentWindowScreenShot.CaptureCurrentWindow();
            cwl(cc_lang[13]);
            cwl(cc_lang[14]);
            if (_sound)
            	sound.Play();
            DateTime now = DateTime.Now;
            string name = now.ToString("yyyy-MM-dd,hh-mm-ss") + "-Window";
            string dateString = string.Format(@"{0}{1}", muc.Read("Main","Path"), name + "." +  muc.Read("Main","Format"));
            cwl(cc_lang[20] + name);
            SasLabel.Text = cc_lang[11] + cc_lang[21] + ":" + Environment.NewLine + dateString;
            saveImage(dateString, ScSh, muc.Read("Main","Format"), muc.ReadInt("Main","jpgQuality"));
            pictureBox1.Image = ScSh;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            cwl(cc_lang[11] + cc_lang[21] + " " + dateString);
            cwl(cc_lang[16]);
            muc.Write("Main", "LastPath",dateString);
            if (lstButton.Visible == false)
            {
                cwl(cc_lang[22]);
                lstButton.Visible = true;
            }
            MemoryManagement.FlushMemory();
        }
        protected override void WndProc(ref Message m)
        {
            string HotkeyCatchLog = cc_lang[26] + (((int)m.LParam >> 16) & 0xFFFF) + " " + cc_lang[27] + ((int)m.LParam & 0xFFFF);
            if (m.Msg == Modifiers.WM_HOTKEY_MSG_ID)
                if ((Keys)(((int)m.LParam >> 16) & 0xFFFF) == Keys.F3 && ((int)m.LParam & 0xFFFF) == Modifiers.ALT)
                {
                    cwl(HotkeyCatchLog);
                    HandleHotkey();
                }
                else if ((Keys)(((int)m.LParam >> 16) & 0xFFFF) == Keys.F3 && ((int)m.LParam & 0xFFFF) == Modifiers.ALT + Modifiers.CTRL)
                {
                    cwl(HotkeyCatchLog);
                    HideTogether();
                }
                else if ((Keys)(((int)m.LParam >> 16) & 0xFFFF) == Keys.F4 && ((int)m.LParam & 0xFFFF) == Modifiers.ALT + Modifiers.CTRL + Modifiers.WIN)
                {
                    cwl(HotkeyCatchLog);
                    ExitHandler();
                }
                else if ((Keys)(((int)m.LParam >> 16) & 0xFFFF) == Keys.F3 && ((int)m.LParam & 0xFFFF) == Modifiers.ALT + Modifiers.SHIFT)
                {
                    cwl(HotkeyCatchLog);
                    if (File.Exists(@muc.Read("Main","LastPath")) && muc.Read("Main","LastPath") != "")
                    {
                        Process.Start(@muc.Read("Main","LastPath"));
                    }
                    else 
                    {
                        MessageBox.Show(cc_lang[11]+"("+muc.Read("Main","LastPath")+")"+cc_lang[12], cc_lang[30], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cwl(cc_lang[11] + "(" + muc.Read("Main","LastPath") + ")" + cc_lang[12]);                  
                        pictureBox1.Image = null;
                        lstButton.Visible = false;
                        SasLabel.Text = "";
                        muc.Write("Main","LastPath","");
                    }
                    MemoryManagement.FlushMemory();
                }
                else if ((Keys)(((int)m.LParam >> 16) & 0xFFFF) == Keys.F3 && ((int)m.LParam & 0xFFFF) == Modifiers.CTRL + Modifiers.SHIFT)
                {
                    cwl(HotkeyCatchLog);
                    SelShotHandler();
                }
                else if ((Keys)(((int)m.LParam >> 16) & 0xFFFF) == Keys.F3 && ((int)m.LParam & 0xFFFF) == Modifiers.CTRL)
                {
                    cwl(HotkeyCatchLog);
                    curWindSSHandler();
                }
            if (m.Msg == Program.ao)
            {
                cwl(cc_lang[28]);
                if (Visible == true)
                {
                    cwl(cc_lang[29]);
                    this.Activate();
                }
                else
                {
                    MainWindowShow();
                }
            }
            base.WndProc(ref m);
        }
        #endregion
        #region Clicks on buttons & clicks in tray
        private void spButton_Click(object sender, EventArgs e)
        {
            cwl("Showing Path Selection Dialog.");
            DialogResult result = Selpath.ShowDialog();
            if (result == DialogResult.OK)
            {
            	muc.Write("Main","Path",Selpath.SelectedPath + "\\");
                cwl(cc_lang[15] + muc.Read("Main","Path"));
                ApplySave();
                pathLabel.Text = cc_lang[17]+": " + Environment.NewLine + muc.Read("Main","Path");
                cwl(cc_lang[18]);
            }
            else { cwl(cc_lang[19]); }
            MemoryManagement.FlushMemory();
        }
        private void ttButton_Click(object sender, EventArgs e)
        {
            if (muc.ReadBool("Main","TrayShow"))
            {
            	muc.Write("Main","TrayShow","false");
                icon.Hide();
                Refresh();
                cwl(cc_lang[8] + " " + cc_lang[1] + ifru("а"));
                ttButton.Text = cc_lang[8] + " " + cc_lang[1] + ifru("а");
                ApplySave();
            }
            else 
            {
            	muc.Write("Main", "TrayShow","true");
                icon.Show();
                Refresh();
                cwl(cc_lang[8] + " " + cc_lang[0] + ifru("а")); ApplySave(); ttButton.Text = cc_lang[8] + " " + cc_lang[0] + ifru("а");
            }
        }
        private void consButton_Click(object sender, EventArgs e)
        {
            if (cws == true)
            {
                cws = false;
                cwsw = false;
                SSConsoleHide();
            }
            else
            {
                SSConsoleShow();
                cws = true;
                cwsw = true;
            }
            MemoryManagement.FlushMemory();
        }
        private void confButton_Click(object sender, EventArgs e)
        {
            if (configs.Visible == false)
            {
                cwl(cc_lang[7] + " " + cc_lang[0] + ifru("о"));
                if (configs.ShowDialog() == DialogResult.OK)
                {
                    configs.Apply();
                    cwl(cc_lang[4] + " " + cc_lang[2]+", Tooltips=" + muc.ReadBool("Main","Tooltips") + ", ConsoleButton=" + muc.ReadBool("Main","ConsoleButton") + ", TrayToogleButton=" + muc.ReadBool("Main","TrayButton") + ", Exit on Close =" + muc.ReadBool("Main","ExitOnX") + ", Format=" + Convert.ToString(muc.Read("Main","Format")) + ", Language = " + muc.Read("Main","lang"));
                    ReferenceVisibility();
                }
                else { cwl(cc_lang[4] + " " + cc_lang[3]); }
            }
            else { configs.Activate(); cwl(cc_lang[24]); }
            MemoryManagement.FlushMemory();
        }
        private void lstButton_Click(object sender, EventArgs e)
        {
            Process.Start(@muc.Read("Main","LastPath"));
            MemoryManagement.FlushMemory();
        }

        private void icon_DoubleClick(object sender, EventArgs e)
        {
            HideTogether();
        }
        private void icon_AboutClick(object sender, EventArgs e)
        {
            ShowHideAbout();
        }
        private void icon_ExitClick(object sender, EventArgs e)
        {
            ExitHandler();
        }
        #endregion
        #region MainForm Events
        private void ScreenShotterMain_Load(object sender, EventArgs e)
        {
            if (muc.Read("Main","Path") != "")
            {
                pathLabel.Text = cc_lang[17] + ":" + Environment.NewLine + muc.Read("Main","Path");
            }
            else
            {
                pathLabel.Text = cc_lang[17] + ":" + Environment.NewLine + cc_lang[33];
            }
            cwl( cc_lang[18]);
            if (muc.ReadBool("Main","TrayShow") == true)
            {
                ttButton.Text = cc_lang[8] + " " + cc_lang[0] + ifru("а");
            }
            else { ttButton.Text = cc_lang[8] + " " + cc_lang[1] + ifru("а"); }
            if (muc.Read("Main","LastPath") == "")
            {
                lstButton.Visible = false;
            }
            else
            {
                if (File.Exists(muc.Read("Main","LastPath")))
                {
                    SasLabel.Text = cc_lang[11] + cc_lang[21] + ":" + Environment.NewLine + muc.Read("Main","LastPath");
                    pictureBox1.Image = Image.FromFile(@muc.Read("Main","LastPath"));
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else { lstButton.Visible = false; cwl(cc_lang[11] + "(" + muc.Read("Main","LastPath") + ")" + cc_lang[12]); }
            }
            ReferenceVisibility();
            }
        private void ScreenShotterMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (force == true)
            {
                ExitHandler();
            }
            else
            {
                if (muc.ReadBool("Main","ExitOnX") == true)
                {
                    ExitHandler();
                }
                else
                {
                    e.Cancel = true;
                    HideTogether();
                }
            }
            if (About.Visible == true)
            {
                About.Visible = false;
            }
        }
        private void ScreenShotter_Activated(object sender, EventArgs e)
        {
            checkFileExist();
        }
        private void ScreenShotter_Move(object sender, EventArgs e)
        {
            Point p = new Point(this.Left + this.Width, this.Top);
            console.Location = p;
            this.Location = this.Location;
        }
        #endregion
        #region Tooltips
        private void Info_MouseHover(object sender, EventArgs e)
        {
            TooltipShow(cc_lang[46], Info);
            MemoryManagement.FlushMemory();
        }

        private void ttButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow(cc_lang[47], ttButton);
            MemoryManagement.FlushMemory();
        }

        private void spButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow(cc_lang[48], spButton);
            MemoryManagement.FlushMemory();
        }

        private void lstButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow(cc_lang[49], lstButton);
            MemoryManagement.FlushMemory();
        }

        private void consButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow(cc_lang[50], consButton);
            MemoryManagement.FlushMemory();
        }

        private void confButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow(cc_lang[51], confButton);
            MemoryManagement.FlushMemory();
        }

        private void pathLabel_MouseHover(object sender, EventArgs e)
        {
            if (muc.Read("Main","Path") == "")
            {
                TooltipShow(cc_lang[52] + " " + cc_lang[33], pathLabel);
            }
            else
            {
                TooltipShow(cc_lang[52] + muc.Read("Main","Path"), pathLabel);
            }
            MemoryManagement.FlushMemory();
        }
        #endregion

        private void Info_Click(object sender, EventArgs e)
        {
            ShowHideAbout();
        }

    }
}
