using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.Файл
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = @textBox1.Text;
                string b = @textBox2.Text;
                File.Copy(a, b, true);
                if(File.Exists(b) )
                {
                    label2.Text = "Копирование выполнено";
                }
                else
                {
                    label2.Text = "Копирование не выполнено";
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                label2.Text = "FALSE";
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "1. В верхнюю строку введите название исходного файла\n2. В нижнюю строку введите название нового файла";
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string a = @textBox1.Text;
                string b = @textBox2.Text;
                File.Move(a, b);
                if (File.Exists(b))
                {
                    label2.Text = "Переименовывание выполнено";
                }
                else
                {
                    label2.Text = "Переименовывание не выполнено";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "1. В верхнюю строку введите название исходного файла\n2. В нижнюю строку введите новое название файла";
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string a = @textBox1.Text;
                string b = @textBox2.Text;
                File.Move(a, b);
                if (File.Exists(b))
                {
                    label2.Text = "Перемещение выполнено";
                }
                else
                {
                    label2.Text = "Перемещение не выполнено";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "1. В верхнюю строку введите название файла\n2. В нижнюю строку введите новое место расположения";
        }
    }
}
