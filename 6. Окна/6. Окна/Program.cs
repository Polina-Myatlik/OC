using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _6.Окна
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            foreach (Process process in Process.GetProcesses())
            {
                //Console.WriteLine($"Имя процесса: {process.ProcessName}");
                c++;
            }
            var process1 = Process.GetCurrentProcess();
            //Console.WriteLine(c);
            //Console.WriteLine($"Name: {process1.ProcessName}");
            Process proc = Process.GetProcessesByName("devenv")[0]; // 
            ProcessModuleCollection modules = proc.Modules;
            foreach (ProcessModule module in modules)
            {
                Console.WriteLine($"Name: {module.ModuleName}  FileName: {module.FileName}");
            }

        }
    }
}
