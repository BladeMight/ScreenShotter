using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ScreenShotter
{
    class CurrentWindowScreenShot
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public static Bitmap CaptureCurrentWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }
        public static int WinShadow = 8; // around 8px shadow
        public static Bitmap CaptureWindow(IntPtr h)
        {
            var rect = new Rect();
            var sw = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width; // fix blackout
            var sh = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            GetWindowRect(h, ref rect);
            var bounds = new Rectangle(rect.Left+WinShadow, rect.Top, (rect.Right>sw ? sw : rect.Right) - rect.Left-WinShadow*2, (rect.Bottom>sh ? sh : rect.Bottom) - rect.Top-WinShadow);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }
    }
}
