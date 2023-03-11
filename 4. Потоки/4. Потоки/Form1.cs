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

namespace _4.Потоки
{
    public partial class Form1 : Form
    {
        private Thread thread1;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Thread thread2 = new Thread(Q)
            {
                Priority = ThreadPriority.Normal
            };
            thread2.Start();
            thread1 = new Thread(W)
            {
                Priority = ThreadPriority.Highest
            };
        }
        public int cnt = 0;
        public int i = 0;
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            cnt ++;
            label1.Text = $"Номер нажатия: {cnt}";
            try
            {
                if (cnt == 1)
                {
                    thread1.Start();
                }
                else
                {
                    if (cnt % 2 != 0)
                    {
                        thread1.Start();
                    }
                    else
                    {
                        thread1.Abort();
                        thread1 = new Thread(() =>
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                Console.WriteLine($"Основной поток: {i}\n");
                                Thread.Sleep(1000);
                            }
                        })
                        {
                            Priority = ThreadPriority.Highest
                        };
                    }
                }
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
        }
        void Q()
        {
            while (timer1.Enabled)
            {
                Console.WriteLine($"Дочерний поток {i++}\n");
                Thread.Sleep(5000);
            }
        }
        void W()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Основной поток: {i}\n");
                Thread.Sleep(1000);
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            thread1.Abort();
            thread1 = new Thread((W))
            {
                Priority = ThreadPriority.Normal
            };
            thread1.Start();
        }
    }
}
