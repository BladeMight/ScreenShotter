using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Threading;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace ScreenShotter
{
    public partial class ScreenShotter : Form
    {
        #region Variables
        public static bool cws = false, cwsw = false, force = false, ssws = false, cancelled = false;
        public static Bitmap ScSh = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        public FolderBrowserDialog Selpath;
        public static Settings mus = new Settings();
        private HotkeyHandler ScrShHK, ScrShshhHK, ScrShExit, Oplast, SelScrShot, curWindowSS;
        private Configs configs = new Configs();
        public static ConsoleForm console = new ConsoleForm();
        private SelectionScreenShot selSCR = new SelectionScreenShot();
        private AboutBox About = new AboutBox();
        TrayIcon icon;
        SoundPlayer sound = new SoundPlayer(Properties.Resources.sound);
        #endregion
        public ScreenShotter()
        {
            cwl("Program started.");
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
            MemoryManagement.FlushMemory();
        }
        #region Functions
        void InitializeTrayIcon()
        {
            icon = new TrayIcon(mus.TrayShow);
            icon.ShowClick += icon_DoubleClick;
            icon.ExitClick += icon_ExitClick;
            icon.DoubleClick += icon_DoubleClick;
            icon.AboutClick += icon_AboutClick;
            icon.ConfigsClick += confButton_Click;
            cwl("Tray Icon Initialized.");
        }
        public void cwl(string log)
        {
            console.Write(log);
        }
        private void ApplySave()
        {
            mus.Save();
            cwl("Settings saved.");
            MemoryManagement.FlushMemory();
        }
        private void TooltipShow(string text, IWin32Window window)
        {
            if (mus.Tooltips == true)
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
            else { if (cwsw == true) { cws = true; console.Show(); } MainWindowShow(); }
            MemoryManagement.FlushMemory();
        }
        private void ReferenceVisibility()
        {
            if (mus.ConsoleButton == true)
            {
                consButton.Visible = true;

            }else { consButton.Visible = false; }
            if (mus.TrayButton == true)
            {
                ttButton.Visible = true;
            }else { ttButton.Visible = false; }
            if (mus.Tooltips == true)
            {
                Info.Visible = true;
            }
            else { Info.Visible = false; }
            MemoryManagement.FlushMemory();
        }
        private void SSConsoleHide()
        {
            console.Hide();
            cwl("Console Hidden.");
            MemoryManagement.FlushMemory();
        }
        private void SSConsoleShow()
        {
            console.Show();
            cwl("Console Shown.");
            MemoryManagement.FlushMemory();
        }
        private void MainWindowShow()
        {
            Show();
            TopMost = true;
            Thread.Sleep(1);
            TopMost = false;
            cwl("ScreenShotter Main Window Shown.");
            MemoryManagement.FlushMemory();
        }
        private void MainWindowHide()
        {
            Hide();
            cwl("SreenShotter Main Window Hidden.");
            MemoryManagement.FlushMemory();
        }
        private void checkFileExist()
        {
            if (!File.Exists(@mus.LastPath) && mus.LastPath !="")
            {
                cwl("Last Screenshot(" + mus.LastPath + ") not exist.");
                pictureBox1.Image = null;
                lstButton.Visible = false;
                SasLabel.Text = "";
                mus.LastPath = "";
            }
        }
        private void saveImage(string path, Bitmap image, ImageFormat format, long ifjpgQuality)
        {
            if (format == ImageFormat.Jpeg)
            {
                var enc = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                var encQ = new EncoderParameters() { Param = new[] { new EncoderParameter(Encoder.Quality, ifjpgQuality) } };
                image.Save(path, enc, encQ);
            }else
            {
                image.Save(path, format);
            }
        }
        private string GETextension()
        {
            string ext = Convert.ToString(mus.siFormat).ToLower();
            if (ext == "jpeg")
            {
                return "jpg";
            }
            return ext;
        }
        #endregion
        #region Hotkey Handlers & WNDPROC
        private void HandleHotkey()
        {
            Graphics SS = Graphics.FromImage(ScSh as Image);
            SS.CopyFromScreen(0, 0, 0, 0, ScSh.Size);
            cwl("Screenshot taken.");
            cwl("Playing sound.");
            sound.Play();
            DateTime now = DateTime.Now;
            string name = now.ToString("yyyy-MM-dd,hh-mm-ss");
            string dateString = string.Format(@"{0}{1}", mus.path, name + "." + GETextension());
            cwl("Name for Screenshot created, name = " + name );
            SasLabel.Text = "Last Screenshot Saved as:" + Environment.NewLine + dateString;
            saveImage(dateString, ScSh, mus.siFormat, mus.jpgQuality);
            pictureBox1.Image = ScSh;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            cwl("Screenshot saved as " + dateString);
            cwl("Saving path to last path");
            mus.LastPath = dateString;
            if (lstButton.Visible == false)
            {
                cwl("Showing lstButton");
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
                    cwl("Screenshot taken.");
                    cwl("Playing sound.");
                    sound.Play();
                    DateTime now = DateTime.Now;
                    string name = now.ToString("yyyy-MM-dd,hh-mm-ss") + "-Selection";
                    string dateString = string.Format(@"{0}{1}", mus.path, name + "." + GETextension());
                    cwl("Name for Screenshot created, name = " + name);
                    SasLabel.Text = "Last Screenshot Saved as:" + Environment.NewLine + dateString;
                    saveImage(dateString,ScSh,mus.siFormat,mus.jpgQuality);
                    pictureBox1.Image = ScSh;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    mus.LastPath = dateString;
                    if (lstButton.Visible == false)
                    {
                        cwl("Showing lstButton");
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
            cwl("Screenshot taken.");
            cwl("Playing sound.");
            sound.Play();
            DateTime now = DateTime.Now;
            string name = now.ToString("yyyy-MM-dd,hh-mm-ss") + "-Window";
            string dateString = string.Format(@"{0}{1}", mus.path, name + "." + GETextension());
            cwl("Name for Screenshot created, name = " + name);
            SasLabel.Text = "Last Screenshot Saved as:" + Environment.NewLine + dateString;
            saveImage(dateString, ScSh, mus.siFormat, mus.jpgQuality);
            pictureBox1.Image = ScSh;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            mus.LastPath = dateString;
            if (lstButton.Visible == false)
            {
                cwl("Showing lstButton");
                lstButton.Visible = true;
            }
            MemoryManagement.FlushMemory();
        }
        protected override void WndProc(ref Message m)
        {
            string HotkeyCatchLog ="Hotkey catched with m.LParam of Key = " + (((int)m.LParam >> 16) & 0xFFFF) + " and m.LParam of Modifier = " + ((int)m.LParam & 0xFFFF);
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
                    if (File.Exists(@mus.LastPath) && mus.LastPath != "")
                    {
                        Process.Start(@mus.LastPath);
                    }
                    else 
                    {
                        MessageBox.Show("Last Screenshot not exist!", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cwl("Last Screenshot(" + mus.LastPath + ") not exist.");                        
                        pictureBox1.Image = null;
                        lstButton.Visible = false;
                        SasLabel.Text = "";
                        mus.LastPath = "";
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
                cwl("Detected another instance of ScreenShotter is being opened, it was closed.");
                if (Visible == true)
                {
                    cwl("ScreenShotter Main Window is visible, getting it to top.");
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
                mus.path = Selpath.SelectedPath + "\\";
                cwl("Path set, path = " + mus.path);
                ApplySave();
                pathLabel.Text = "Current path: " + Environment.NewLine + mus.path;
                cwl("Writing current path to pathLabel.");
            }
            else { cwl("Path Selection Dialog was closed or cancelled."); }
            MemoryManagement.FlushMemory();
        }
        private void ttButton_Click(object sender, EventArgs e)
        {
            if (mus.TrayShow == true)
            {
                mus.TrayShow = false;
                icon.Hide();
                Refresh();
                cwl("Tray Icon Hidden.");
                ttButton.Text = "Tray Icon Hidden";
                ApplySave();
            }
            else { mus.TrayShow = true; icon.Show(); Refresh(); cwl("Tray Icon Shown."); ApplySave(); ttButton.Text = "Tray Icon Visible"; }
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
                cwl("Configs Window Shown.");
                if (configs.ShowDialog() == DialogResult.OK)
                {
                    configs.Apply();
                    cwl("Settings Applyed, Tooltips=" + mus.Tooltips + ", ConsoleButton=" + mus.ConsoleButton + ", TrayToogleButton=" + mus.TrayButton + ", Exit on Close =" + mus.ExitOnX + ", Format=" + Convert.ToString(mus.siFormat) + ".");
                    ReferenceVisibility();
                }
                else { cwl("Setting not Applyed"); }
            }
            else { configs.Activate(); cwl("Configs window alredy opened!"); }
            MemoryManagement.FlushMemory();
        }
        private void lstButton_Click(object sender, EventArgs e)
        {
            Process.Start(@mus.LastPath);
            MemoryManagement.FlushMemory();
        }

        private void icon_DoubleClick(object sender, EventArgs e)
        {
            HideTogether();
        }
        private void icon_AboutClick(object sender, EventArgs e)
        {
            if (About.Visible == true)
            {
                About.Hide();
            }
            else { About.Show(); }
            MemoryManagement.FlushMemory();
        }
        private void icon_ExitClick(object sender, EventArgs e)
        {
            ExitHandler();
        }
        #endregion
        #region MainForm Events
        private void ScreenShotterMain_Load(object sender, EventArgs e)
        {
            if (mus.path != "")
            {
                pathLabel.Text = "Current path:" + Environment.NewLine + mus.path;
            }
            else
            {
                pathLabel.Text = "Current path:" + Environment.NewLine + "Root folder of the program";
            }
            cwl("Writing current path to pathLabel.");
            if (mus.TrayShow == true)
            {
                ttButton.Text = "Tray Icon Visible";
            }
            else { ttButton.Text = "Tray Icon Hidden"; }
            if (mus.LastPath == "")
            {
                lstButton.Visible = false;
            }
            else
            {
                if (File.Exists(mus.LastPath))
                {
                    SasLabel.Text = "Last Screenshot Saved as:" + Environment.NewLine + mus.LastPath;
                    pictureBox1.Image = Image.FromFile(@mus.LastPath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else { lstButton.Visible = false; cwl("Last Screenshot(" + mus.LastPath + ") not exist."); }
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
                if (mus.ExitOnX == true)
                {
                    ExitHandler();
                }
                else
                {
                    e.Cancel = true;
                    HideTogether();
                }
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
            TooltipShow("ALT + F3 to make a Screenshot\nCTRL + F3 to make Screenshot of active window\nCTRL + SHIFT + F3 to make Selection Screenshot(ESC or ALT+F4 to cancel)\nALT + CTRL + F3 to Show/Hide Main Window\nALT + SHIFT + F3 to open last Screenshot\nALT + WIN + CTRL + F4 to immediately Shutdown.", Info);
            MemoryManagement.FlushMemory();
        }

        private void ttButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow("Click here to Toogle Tray Icon Visibility.", ttButton);
            MemoryManagement.FlushMemory();
        }

        private void spButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow("Click here to Select Path where to save Screenshots.", spButton);
            MemoryManagement.FlushMemory();
        }

        private void lstButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow("Click here to open last Screenshot.", lstButton);
            MemoryManagement.FlushMemory();
        }

        private void consButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow("Click here to Toogle Console of ScreenShotter.", consButton);
            MemoryManagement.FlushMemory();
        }

        private void confButton_MouseHover(object sender, EventArgs e)
        {
            TooltipShow("Click here to Open Configs window.", confButton);
            MemoryManagement.FlushMemory();
        }

        private void pathLabel_MouseHover(object sender, EventArgs e)
        {
            TooltipShow("This show current path for saving screenshots.\nPath:" + mus.path, pathLabel);
            MemoryManagement.FlushMemory();
        }
        #endregion

    }
}
