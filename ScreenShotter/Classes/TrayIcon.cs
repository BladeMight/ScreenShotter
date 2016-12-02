using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ScreenShotter
{
    class TrayIcon
    {
        public event EventHandler<EventArgs> ExitClick;
        public event EventHandler<EventArgs> ShowClick;
        public event EventHandler<EventArgs> Click;
        public event EventHandler<EventArgs> AboutClick;
        public event EventHandler<EventArgs> ConfigsClick;
        private NotifyIcon Trycon;
        private ContextMenu Connu;
        public MenuItem ConfigMI,ShowHideMI,AboutMI,ExitMI;
        public TrayIcon(bool? visible = true)
        {
            Trycon = new NotifyIcon();
            Connu = new ContextMenu();
            RefreshMenu();
            Trycon.Icon = Properties.Resources.ScreenShotter;
            Trycon.Visible = visible == true;
            Trycon.ContextMenu = Connu;
            Trycon.MouseDoubleClick += DoubleClickHandler;
            Trycon.BalloonTipClicked += ClickHandler;
            }

        private void ClickHandler(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click(this, null);
            }
        }
        public void RefreshMenu()
        {
            var whole = "Screenshooter\n"+ScreenShotter.cc_lang[11]+ScreenShotter.muc.Read("Main","LastPath");
            string clipped = "";
            try{ clipped = whole.Substring(0,63);} catch {clipped = whole;}
            Trycon.Text = clipped;
            Connu.MenuItems.Clear();
            ConfigMI = new MenuItem(ScreenShotter.cc_lang[59], ConfigsClickHandler);
            ShowHideMI = new MenuItem(ScreenShotter.cc_lang[60], ShowClickHandler);
            AboutMI = new MenuItem(ScreenShotter.cc_lang[61], AboutClickHandler);
            ExitMI = new MenuItem(ScreenShotter.cc_lang[62], ExitClickHandler);
            Connu.MenuItems.Add(ConfigMI);
            Connu.MenuItems.Add(ShowHideMI);
            Connu.MenuItems.Add(AboutMI);
            Connu.MenuItems.Add(ExitMI);
        }
        private void ConfigsClickHandler(object sender, EventArgs e)
        {
            if (ConfigsClick != null)
            {
                ConfigsClick(this, null);
            }
        }
        public void ShowTooltip(string a, string b)
        {
            Trycon.ShowBalloonTip(1000, a, b, ToolTipIcon.Info);
        }
        public void Show()
        {
            Trycon.Visible = true;
        }
        public void Hide()
        {
            Trycon.Visible = false;
        }
        private void AboutClickHandler(object sender, EventArgs e)
        {
            if (AboutClick != null)
            {
                AboutClick(this, null);
            }
        }
        private void ExitClickHandler(object sender, EventArgs e)
        {
            if (ExitClick != null)
            {
                ExitClick(this, null);
            }
        }

        private void ShowClickHandler(object sender, EventArgs e)
        {
            if (ShowClick != null)
            {
                ShowClick(this, null);
            }
        }
        private void DoubleClickHandler(object sender, MouseEventArgs e)
        {
            if (Click != null)
            {
                Click(this, null);
            }
        }
    }
}
