using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WinFormsApp2
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        [DllImport("User32.dll")]
        public static extern bool OpenClipboard(IntPtr hWnd);[DllImport("User32.dll")]
        public static extern IntPtr SetClipboardData(CF Format, IntPtr hMem);
        [DllImport("User32.dll")]
        public static extern bool EmptyClipboard();[DllImport("User32.dll")]
        public static extern IntPtr GetClipboardData(CF Format);
        [DllImport("User32.dll")]
        public static extern bool CloseClipboard();
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)] public static extern bool CloseHandle(IntPtr hObject);
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)] public static extern IntPtr GlobalSize(IntPtr hMem);
        public enum CF
        {
            Text = 1, Bitmap = 2, MetaFilePict = 3, Sylk = 4, Dif = 5, Tiff = 6, OemText = 7, Dib = 8, Palette = 9, Pendata = 10, Riff =
            11, Wave = 12, UnicodeText = 13, EnhMetaFile = 14, HDrop = 15, Locale = 16, Dibv5 = 17, OwnerDisplay = 128, DspText
            = 129, DspBitmap = 130, DspMetaFilePict = 131, DspEnhMetaFile = 142, PrivateFirst = 512, PrivateLast = 767,
            GdiObjFirst = 768, GdiObjLast = 1023
        }
        private void SetClipboardAPI(string s)
        {
            OpenClipboard(this.Handle); EmptyClipboard();
            SetClipboardData(CF.UnicodeText, Marshal.StringToCoTaskMemUni(s));
            CloseClipboard();
        }
        private string last = " ";
        private bool turn_on = true;
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        CGlobalKeyboardHook _kbdHook = new CGlobalKeyboardHook();

        public Form1()
        {
            InitializeComponent();
            if (rkApp.GetValue("MyApp") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                checkBox1.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                checkBox1.Checked = true;
            }
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            _kbdHook.hook();
            _kbdHook.KeyDown += _kbdHook_KeyDown;
        }

        private void _kbdHook_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F8)
            {
                if (button1.Text == "Bật")
                {
                    turn_on = true;
                    button1.Text = "Tắt";
                }
                else
                if (button1.Text == "Tắt")
                    {
                        turn_on = false;
                        button1.Text = "Bật";
                    }
            }

            if (turn_on)
            {
                string Key = e.KeyCode.ToString();
                if (e.KeyCode == Keys.S)
                {
                    if (dau_sac(last))
                    {
                        e.Handled = true;
                        replace(last);
                    }

                }
                if (e.KeyCode == Keys.F)
                {
                    if (dau_huyen(last))
                    {
                        e.Handled = true;
                        replace(last);
                    }
                }

                if (e.KeyCode == Keys.J)
                {
                    if (dau_nang(last))
                    {
                        e.Handled = true;
                        replace(last);
                    }
                }

                if (e.KeyCode == Keys.X)
                {
                    if (dau_nga(last))
                    {
                        e.Handled = true;
                        replace(last);
                    }
                }

                if (e.KeyCode == Keys.R)
                {
                    if (dau_hoi(last))
                    {
                        e.Handled = true;
                        replace(last);
                    }
                }

                if (e.KeyCode == Keys.D)
                {
                    if (chu_d(last))
                    {
                        e.Handled = true;
                        replace(last);
                        last = "đ";
                    }
                }

                if (e.KeyCode == Keys.A)
                {
                    if (chu_a(last))
                    {
                        e.Handled = true;
                        replace(last);
                        last = "â";
                    }
                }

                if (e.KeyCode == Keys.W)
                {
                    if (chu_w(last))
                    {
                        e.Handled = true;
                        replace(last);
                        last = Clipboard.GetText(TextDataFormat.Text);
                    }
                }

                if (e.KeyCode == Keys.O)
                {
                    if (chu_o(last))
                    {
                        e.Handled = true;
                        replace(last);
                        last = "ô";
                    }
                }

                if (e.KeyCode == Keys.E)
                {
                    if (chu_e(last))
                    {
                        e.Handled = true;
                        replace(last);
                        last = "ê";
                    }
                }

                if (Key.Length == 1 && !e.Handled)
                {
                    last += Key.ToLower();
                }
                if (Key == "Space")
                {
                    last = "";
                }
                if (Key == "Back" && last.Length > 0)
                {
                    last = last.Substring(0,last.Length-1);
                }
            }
        }

        private void replace(string old)
        {
            for (int i = 0; i < old.Length; i++)
            {   // xoa ky ty cu
                keybd_event((byte)Keys.Back, 0, 0, UIntPtr.Zero);//press 
                keybd_event((byte)Keys.Back, 0, 2, UIntPtr.Zero);//release
            }

            // thay ky tu moi
            keybd_event(0x10, 0, 0, UIntPtr.Zero);
            keybd_event(0x2D, 0, 1, UIntPtr.Zero);
            keybd_event(0x2D, 0, 2, UIntPtr.Zero);
            keybd_event(0x10, 0, 2, UIntPtr.Zero);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool chu_w(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("ă");
                }
                else
                if (c == 'u' && !isDone)
                {
                    newString += ("ư");
                }
                else
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("ơ");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }

        private bool chu_o(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("ô");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }

        private bool chu_e(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'e' && !isDone)
                {
                    isDone = true;
                    newString += ("ê");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }
        private bool chu_a(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("â");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }
        private bool chu_d(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'd' && !isDone)
                {
                    isDone = true;
                    newString += ("đ");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }

        private bool dau_sac(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'â' && !isDone)
                {
                    isDone = true;
                    newString += ("ấ");
                }
                else
                if (c == 'ă' && !isDone)
                {
                    isDone = true;
                    newString += ("ắ");
                }
                else
                if (c == 'ô' && !isDone)
                {
                    isDone = true;
                    newString += ("ố");
                }
                else
                if (c == 'ơ' && !isDone)
                {
                    isDone = true;
                    newString += ("ớ");
                }
                else
                if (c == 'ư' && !isDone)
                {
                    isDone = true;
                    newString += ("ứ");
                }
                else
                if (c == 'ê' && !isDone)
                {
                    isDone = true;
                    newString += ("ế");
                }
                else
                if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("á");
                }
                else
                if (c == 'e' && !isDone)
                {
                    isDone = true;
                    newString += ("é");
                }
                else
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("ó");
                }
                else
                if (c == 'i' && !isDone)
                {
                    isDone = true;
                    newString += ("í");
                }
                else
                if (c == 'u' && !isDone)
                {
                    isDone = true;
                    newString += ("ú");
                }
                else
                if (c == 'y' && !isDone)
                {
                    isDone = true;
                    newString += ("ý");
                }
                else
                {
                    newString += c;
                }
            }
            
            if(newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }else return false;
        }

        private bool dau_huyen(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'â' && !isDone)
                {
                    isDone = true;
                    newString += ("ầ");
                }
                else
                if (c == 'ă' && !isDone)
                {
                    isDone = true;
                    newString += ("ằ");
                }
                else
                if (c == 'ô' && !isDone)
                {
                    isDone = true;
                    newString += ("ồ");
                }
                else
                if (c == 'ơ' && !isDone)
                {
                    isDone = true;
                    newString += ("ờ");
                }
                else
                if (c == 'ư' && !isDone)
                {
                    isDone = true;
                    newString += ("ừ");
                }
                else
                if (c == 'ê' && !isDone)
                {
                    isDone = true;
                    newString += ("ề");
                }
                else
                if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("à");
                }
                else
                if (c == 'e' && !isDone)
                {
                    isDone = true;
                    newString += ("è");
                }
                else
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("ò");
                }
                else
                if (c == 'i' && !isDone)
                {
                    isDone = true;
                    newString += ("ì");
                }
                else
                if (c == 'u' && !isDone)
                {
                    isDone = true;
                    newString += ("ù");
                }
                else
                if (c == 'y' && !isDone)
                {
                    isDone = true;
                    newString += ("ỳ");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }
        private bool dau_nang(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'â' && !isDone)
                {
                    isDone = true;
                    newString += ("ậ");
                }
                else
                if (c == 'ă' && !isDone)
                {
                    isDone = true;
                    newString += ("ặ");
                }
                else
                if (c == 'ô' && !isDone)
                {
                    isDone = true;
                    newString += ("ộ");
                }
                else
                if (c == 'ơ' && !isDone)
                {
                    isDone = true;
                    newString += ("ợ");
                }
                else
                if (c == 'ư' && !isDone)
                {
                    isDone = true;
                    newString += ("ự");
                }
                else
                if (c == 'ê' && !isDone)
                {
                    isDone = true;
                    newString += ("ệ");
                }
                else
                if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("ạ");
                }
                else
                if (c == 'e' && !isDone)
                {
                    isDone = true;
                    newString += ("ẹ");
                }
                else
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("ọ");
                }
                else
                if (c == 'i' && !isDone)
                {
                    isDone = true;
                    newString += ("ị");
                }
                else
                if (c == 'u' && !isDone)
                {
                    isDone = true;
                    newString += ("ụ");
                }
                else
                if (c == 'y' && !isDone)
                {
                    isDone = true;
                    newString += ("ý");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }
        private bool dau_hoi(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'â' && !isDone)
                {
                    isDone = true;
                    newString += ("ẩ");
                }
                else
               if (c == 'ă' && !isDone)
                {
                    isDone = true;
                    newString += ("ẳ");
                }
                else
               if (c == 'ô' && !isDone)
                {
                    isDone = true;
                    newString += ("ổ");
                }
                else
               if (c == 'ơ' && !isDone)
                {
                    isDone = true;
                    newString += ("ở");
                }
                else
               if (c == 'ư' && !isDone)
                {
                    isDone = true;
                    newString += ("ử");
                }
                else
               if (c == 'ê' && !isDone)
                {
                    isDone = true;
                    newString += ("ể");
                }
                else
               if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("ả");
                }
                else
                if (c == 'e' && !isDone)
                {
                    isDone = true;
                    newString += ("ẻ");
                }
                else
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("ỏ");
                }
                else
                if (c == 'i' && !isDone)
                {
                    isDone = true;
                    newString += ("í");
                }
                else
                if (c == 'u' && !isDone)
                {
                    isDone = true;
                    newString += ("ủ");
                }
                else
                if (c == 'y' && !isDone)
                {
                    isDone = true;
                    newString += ("ỷ");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }
        private bool dau_nga(string last)
        {
            string newString = "";
            bool isDone = false;
            foreach (char c in last)
            {
                if (c == 'â' && !isDone)
                {
                    isDone = true;
                    newString += ("ẫ");
                }
                else
               if (c == 'ă' && !isDone)
                {
                    isDone = true;
                    newString += ("ẵ");
                }
                else
               if (c == 'ô' && !isDone)
                {
                    isDone = true;
                    newString += ("ỗ");
                }
                else
               if (c == 'ơ' && !isDone)
                {
                    isDone = true;
                    newString += ("ỡ");
                }
                else
               if (c == 'ư' && !isDone)
                {
                    isDone = true;
                    newString += ("ữ");
                }
                else
               if (c == 'ê' && !isDone)
                {
                    isDone = true;
                    newString += ("ễ");
                }
                else
               if (c == 'a' && !isDone)
                {
                    isDone = true;
                    newString += ("ã");
                }
                else
                if (c == 'e' && !isDone)
                {
                    isDone = true;
                    newString += ("ẽ");
                }
                else
                if (c == 'o' && !isDone)
                {
                    isDone = true;
                    newString += ("õ");
                }
                else
                if (c == 'i' && !isDone)
                {
                    isDone = true;
                    newString += ("ĩ");
                }
                else
                if (c == 'u' && !isDone)
                {
                    isDone = true;
                    newString += ("ũ");
                }
                else
                if (c == 'y' && !isDone)
                {
                    isDone = true;
                    newString += ("ỹ");
                }
                else
                {
                    newString += c;
                }
            }

            if (newString != last)
            {
                SetClipboardAPI(newString);
                return true;
            }
            else return false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Thoát Chương Trình?", "Hệ Thống", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Bật")
            {
                turn_on = true;
                button1.Text = "Tắt";
            }else
            if (button1.Text == "Tắt")
            {
                turn_on = false;
                button1.Text = "Bật";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RegisterInStartup(checkBox1.Checked);
        }

  
        private void RegisterInStartup(bool isChecked)
        {
            

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }
    }
}

