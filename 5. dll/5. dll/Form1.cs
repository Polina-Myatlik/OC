using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5.dll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count1 = 0;
        int count2 = 0;
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            count1++;
            int a = Convert.ToInt32(textBox3.Text);
            int b = Convert.ToInt32(textBox3.Text);
            string s = textBox1.Text;
            string res = Lib.Class1.Number(s, a, b+1);
            textBox2.Text = res;
            if(res.Contains("Загаданное число:") == false)
            {
                count2++;
            }
            label1.Text = $"Кол-во побед: {count2} Кол-во игор: {count1}";
        }
    }
}
