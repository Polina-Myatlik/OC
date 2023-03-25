using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace КР_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 120000;
        }
        int c = 0;
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (c == 0)
            {
                c++;
                timer1.Enabled = true;
            }
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (FileStream a = File.OpenRead("Цитаты.txt"))
            {
                byte[] array = new byte[a.Length];
                a.Read(array, 0, array.Length);

                string textFrom = System.Text.Encoding.Default.GetString(array);
                string[] article = textFrom.Split('\n');
                try
                {
                    if (timer1.Enabled)
                    {
                        richTextBox1.Text = article[i];
                        i++;
                    }
                }
                catch
                {
                    timer1.Stop();
                    richTextBox1.Text = "";
                    MessageBox.Show("На сегодня всё!");
                    c = 0;
                    i = 0;
                }
            }
        }
    }
}
