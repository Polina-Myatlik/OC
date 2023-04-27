using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Лаба8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\наша программа");
            key.SetValue("Параметр", "Значение");
            key.SetValue("Параметр2", "Значение2");
            foreach (string n in key.GetValueNames())
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            key.SetValue("Параметр3", "Значение3");
            Console.WriteLine(key?.GetValue("Параметр3")?.ToString());

            Registry.Export(@"C:\registry_backup.reg");
            Registry(@"C:\registry_backup.reg");

            key.DeleteSubKey("SOFTWARE\\наша программа");
            key.Close();
        }
    }
}
