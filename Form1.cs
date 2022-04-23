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
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string last = "";
        private bool turn_on = false;
        CGlobalKeyboardHook _kbdHook = new CGlobalKeyboardHook();

        public Form1()
        {
            InitializeComponent();
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
                    }
                }
                if (e.KeyCode == Keys.F)
                {
                    if (dau_huyen(last))
                    {
                        e.Handled = true;
                    }
                }
                if (e.KeyCode == Keys.F)
                {
                    if (dau_huyen(last))
                    {
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.J)
                {
                    if (dau_nang(last))
                    {
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.X)
                {
                    if (dau_nga(last))
                    {
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.R)
                {
                    if (dau_hoi(last))
                    {
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.F)
                {
                    if (dau_huyen(last))
                    {
                        e.Handled = true;
                    }
                }

                if (Key.Length == 1)
                {
                    last = Key;
                    label1.Text = last;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private bool dau_sac(string last)
        {

            if (last == "A")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("á");
            }
            else
            if (last == "E")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("é");
            }
            else
            if (last == "O")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ó");
            }
            else
            if (last == "I")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("í");
            }
            else
            if (last == "U")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ú");
            }
            else
            if (last == "Y")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ý");
            }
            else
            {
                return false;
            }
            return true;
        }

        private bool dau_huyen(string last)
        {

            if (last == "A")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("à");
            }
            else
            if (last == "E")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("è");
            }
            else
            if (last == "O")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ò");
            }
            else
            if (last == "I")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ì");
            }
            else
            if (last == "U")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ù");
            }
            else
            if (last == "Y")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ỳ");
            }
            else
            {
                return false;
            }
            return true;
        }
        private bool dau_nang(string last)
        {

            if (last == "A")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ạ");
            }
            else
            if (last == "E")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ẹ");
            }
            else
            if (last == "O")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ọ");
            }
            else
            if (last == "I")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ị");
            }
            else
            if (last == "U")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ụ");
            }
            else
            if (last == "Y")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ỵ");
            }
            else
            {
                return false;
            }
            return true;
        }
        private bool dau_hoi(string last)
        {

            if (last == "A")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ả");
            }
            else
            if (last == "E")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ẻ");
            }
            else
            if (last == "O")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ỏ");
            }
            else
            if (last == "I")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ỉ");
            }
            else
            if (last == "U")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ủ");
            }
            else
            if (last == "Y")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ỷ");
            }
            else
            {
                return false;
            }
            return true;
        }
        private bool dau_nga(string last)
        {

            if (last == "A")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ã");
            }
            else
            if (last == "E")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ẽ");
            }
            else
            if (last == "O")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("õ");
            }
            else
            if (last == "I")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ĩ");
            }
            else
            if (last == "U")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ũ");
            }
            else
            if (last == "Y")
            {
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("ỹ");
            }
            else
            {
                return false;
            }
            return true;
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
    }
}

