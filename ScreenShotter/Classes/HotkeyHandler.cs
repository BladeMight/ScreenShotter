﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ScreenShotter
{
    public class HotkeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int modifier;
        private int key;
        private IntPtr hWnd;
        private int id;
        public HotkeyHandler(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }
        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }
        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }
        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

    }
}
