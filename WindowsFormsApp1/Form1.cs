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
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void add_list(RegistryKey key)
        {
            for (int c = 0; c < 6; c++)
            {
                if (Registry.CurrentUser.OpenSubKey(paths_array[c]) != null)
                {
                    string[] a = key.OpenSubKey(paths_array[c]).GetValueNames();
                    for (int i = 0; i < a.Length; i++)
                    {
                        checkedListBox1.Items.Add(a[i]);
                    }
                }
            }
        }
        private string[] paths_array = new string[6] { "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run" };
        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            add_list(Registry.CurrentUser);
            add_list(Registry.LocalMachine);
        }
        private static void load()
        {

            int a = 0; //Попа сися кака



            Console.WriteLine("\n\n\n\n\nHKEY_LOCAL_MACHINE:\n");



            if (Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders").GetValue("Common Startup").ToString() == "%USERPROFILE%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup")
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders", true).SetValue("Common Startup", "%USERPROFILE%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
                    Console.WriteLine("Автозагрузка на пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders была исправлен");
                }
                catch
                {
                    Console.WriteLine("К сожалению, у нас не получилось заменить автозагруску в редакторе реестра по пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders\\Backup, либо данная папка отсутствует!\n");
                }
            }
            else
            {
                Console.WriteLine("На пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders не найдено автозагрузок!\n");
            }


            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders").GetValue("Startup").ToString() == "%ProgramData%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup")
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders", true).SetValue("Startup", "%ProgramData%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
                    Console.WriteLine("Автозагрузка на пути CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders была исправлен");
                }
                catch
                {
                    Console.WriteLine("К сожалению, у нас не получилось заменить автозагруску в редакторе реестра по пути HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders, либо данная папка отсутствует!\n\n");
                }
            }
            else
            {
                Console.WriteLine("На пути HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders не найдено автозагрузок!\n\n");
            }


            if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon").GetValue("Shell").ToString() != "explorer.exe")
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true).SetValue("Shell", "explorer.exe");
                    Console.WriteLine("Shell на пути HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon был исправлен");
                }
                catch
                {
                    Console.WriteLine("Не получилось заменить значение Shell на пути HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon, скорее всего у приожения недостаточно прав!\nЗапустите приложение от имени администратора\n\n");
                }
            }
            else
            {
                Console.WriteLine("Shell на пути HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon не найдено автозагрузок!\n\n");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+@"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup");
            checkedListBox1.Items.Clear();
            FileInfo[] files = dir.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                checkedListBox1.Items.Add(files[i]);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var sel = checkedListBox1.CheckedItems;
            if (sel != null)
            {
                foreach (FileInfo item in sel)
                {
                    item.Delete();
                }
            }
        }
    }
}

