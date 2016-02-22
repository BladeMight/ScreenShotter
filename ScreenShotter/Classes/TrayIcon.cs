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
        public event EventHandler<EventArgs> DoubleClick;
        public event EventHandler<EventArgs> AboutClick;
        public event EventHandler<EventArgs> ConfigsClick;
        private NotifyIcon Trycon;
        private ContextMenu Connu;

        public TrayIcon(bool? visible = true)
        {
            Trycon = new NotifyIcon();
            Connu = new ContextMenu();
            Connu.MenuItems.Add("Configs", ConfigsClickHandler);
            Connu.MenuItems.Add("Show/Hide", ShowClickHandler);
            Connu.MenuItems.Add("About", AboutClickHandler);
            Connu.MenuItems.Add("Exit", ExitClickHandler);
            Trycon.Text = "Screenshooter";
            Trycon.Icon = Properties.Resources.ScreenShotter;
            Trycon.Visible = visible == true;
            Trycon.ContextMenu = Connu;
            Trycon.MouseDoubleClick += DoubleClickHandler;
            }

        private void ConfigsClickHandler(object sender, EventArgs e)
        {
            if (ConfigsClick != null)
            {
                ConfigsClick(this, null);
            }
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
        void DoubleClickHandler(object sender, MouseEventArgs e)
        {
            if (DoubleClick != null)
            {
                DoubleClick(this, null);
            }
        }
    }
}
