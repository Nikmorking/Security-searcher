using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private string[] add_path(string[] mass, int index)
        {
            string[] c = new string[mass.Length + 1];
            for (int i = 0; i < c.Length - 1; i++)
            {
                c[i] = mass[i];
            }
            c[c.Length - 1] = paths_array[index];
            return (c);
        }

        private void add_list(RegistryKey key, CheckedListBox box)
        {
            for (int c = 0; c < 3; c++)
            {
                if (key.OpenSubKey(paths_array[c]) != null)
                {
                    string[] a = key.OpenSubKey(paths_array[c]).GetValueNames();
                    for (int i = 0; i < a.Length; i++)
                    {
                        box.Items.Add(a[i]);
                        if (box == checkedListBox2)
                        {
                            user_paths = add_path(user_paths, c);
                        }
                        if (box == checkedListBox3)
                        {
                            machine_paths = add_path(machine_paths, c);
                        }
                    }
                }
            }
        }
        private string[] paths_array = new string[6] { "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run" };
        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            add_list(Registry.CurrentUser, checkedListBox2);
            add_list(Registry.LocalMachine, checkedListBox3);
        }
        private static void load()
        {

            int a;



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
        private string put = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+@"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(put);
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

        private void Open_Click(object sender, EventArgs e)
        {
            Process.Start(put);
        }
        private string[] user_paths = new string[0];
        private string[] machine_paths = new string[0];

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemChecked(i))
                {
                    Registry.CurrentUser.OpenSubKey(user_paths[i], true).DeleteValue(checkedListBox2.Items[i].ToString());
                }
            }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                if (checkedListBox3.GetItemChecked(i))
                {
                    Registry.CurrentUser.OpenSubKey(user_paths[i], true).DeleteValue(checkedListBox3.GetItemText(i));
                }
            }
            button2_Click(sender, e);
        }
    }
}

