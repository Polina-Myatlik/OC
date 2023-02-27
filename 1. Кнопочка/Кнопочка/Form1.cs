using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кнопочка
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button2.Text = "Пришёл";
            button1.Text = "Ушёл";
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Text = "Пришёл";
            button2.Text = "Ушёл";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                double number = double.Parse(s);
                number *= 2;
                textBox1.Text = number.ToString();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                double number = double.Parse(s);
                number /= 2;
                textBox1.Text = number.ToString();
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string s = textBox1.Text;
                double number = double.Parse(s);
                if (number == 0)
                {
                    textBox1.BackColor = Color.Red;
                }
                else
                {
                    textBox1.BackColor = Color.LightSkyBlue;
                }
            }
            catch { }
        }
    }
}
