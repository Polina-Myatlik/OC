using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Диск
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 250;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                label2.Text = $"Наличие диска: {drive.IsReady}\nНазвание: {drive.Name}";
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    label1.Text = $"Кол-во свободного места: {drive.AvailableFreeSpace} байт\nОбъём памяти: {drive.TotalSize} байт";
                }
            }
        }
    }
}
