using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using IWshRuntimeLibrary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form

    {
        public Form1()
        {
            InitializeComponent();
            services = ServiceController.GetServices();
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
                        if(box == checkedListBox2)
                        {
                            user = add_path(user, paths_array[c]);
                        }
                        if (box == checkedListBox3)
                        {
                            local = add_path(local, paths_array[c]);
                        }
                    }
                }
            }
        }

        private string[] add_path(string[] math, string path)
        {
            string[] mass = new string[math.Length + 1];
            for (int i = 0; i < math.Length; i++)
            {
                mass[i] = math[i];
            }
            mass[math.Length] = path;
            return mass;
        }
        private string[] paths_array = { "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run" };
        private string[] local = new string[0];
        private string[] user = new string[0];

        private void button2_Click(object sender, EventArgs e)
        {
            //ДОБАВЛЕНИЕ СТРОКИ ##################################################################################################################
            checkedListBox2.Items.Clear(); //Очищает список
            checkedListBox3.Items.Clear(); //Очищает список
            add_list(Registry.CurrentUser, checkedListBox2);
            add_list(Registry.LocalMachine, checkedListBox3);
            if(checkedListBox2.Items.Count == 0)
            {
                label11.Visible = true;
            }
            else
            {
                label11.Visible = false;
            }
            if (checkedListBox3.Items.Count == 0)
            {
                label12.Visible = true;
            }
            else
            {
                label12.Visible = false;
            }
        }

        private string[] put = { Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp" };

        private void reload(int o)
        {
            if (o == 0)
            {
                checkedListBox1.Items.Clear();
            }
            if (o == 1)
            {
                checkedListBox5.Items.Clear();
            }
            try
            {
                
                DirectoryInfo dir = new DirectoryInfo(put[o]);
                FileInfo[] files = dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name != "desktop.ini")
                    {
                        if(o == 0)
                        {
                            checkedListBox1.Items.Add(files[i]);
                        }
                        if (o == 1)
                        {
                            checkedListBox5.Items.Add(files[i]);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Папка с автозагрусками не найдена\r\nЗапустите от имени Администратора");
            }
            if (checkedListBox1.Items.Count == 0)
            {
                label10.Visible = true;
            }
            else
            {
                label10.Visible = false;
            }
            if (checkedListBox5.Items.Count == 0)
            {
                label13.Visible = true;
            }
            else
            {
                label13.Visible = false;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            reload(0);
            reload(1);
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
            sel = checkedListBox5.CheckedItems;
            if (sel != null)
            {
                foreach (FileInfo item in sel)
                {
                    item.Delete();
                }
            }
            reload(0);
            reload(1);
        }


        private void Add(int o)
        {
            string filePath = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Program (*.exe)|*.exe";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }
            if (filePath != "")
            {
                WshShell shell = new WshShell();

                string[] name = filePath.Split(Convert.ToChar(@"\"));
                //путь к ярлыку
                string shortcutPath = put[o] + @"\" + name[name.Length - 1].Split('.')[0] + @".lnk";

                //создаем объект ярлыка
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

                //задаем свойства для ярлыка
                //описание ярлыка в всплывающей подсказке
                shortcut.Description = "Ярлык для текстового редактора";
                //путь к самой программе
                shortcut.TargetPath = filePath;
                //Создаем ярлык
                shortcut.Save();
            }
            reload(0);
            reload(1);
        }

        private void Add__Click(object sender, EventArgs e)
        {
            Add(0);
        }

        private void Open_Click(object sender, EventArgs e)
        {
            foreach (string n in put)
            {
                Process.Start(n);
            }
        }

        private ServiceController[] services;
        private string[] system = { "Средство построения конечных точек Windows Audio", "Служба базовой фильтрации", "Служба инфраструктуры фоновых задач", "Служба платформы подключенных устройств", "CoreMessaging", "Модуль запуска процессов DCOM-сервера", "Служба сопоставления устройств", "DHCP-клиент", "Функциональные возможности для подключенных пользователей и телеметрия", "Служба политики отображения", "DNS-клиент", "Использование данных", "Журнал событий Windows", "Система событий COM+", "Служба кэша шрифтов Windows", "Клиент групповой политики" };

        private void service_reload(bool auto)
        {
            for (int i = 0; i < services.Length; i++)
            {
                foreach (string name in system)
                {
                    if(services[i].DisplayName == name)
                    {
                        ServiceController[] newarr = services.Where(s => s != services[i]).ToArray();
                        services = newarr;
                    }
                }
            }
            checkedListBox4.Items.Clear();
            foreach (ServiceController service in services)
            {
                if ((service.StartType == ServiceStartMode.Automatic) == auto)
                {
                    checkedListBox4.Items.Add(service.DisplayName);
                }
            }
        }

        private void Service_seach_Click(object sender, EventArgs e)
        {
            service_reload(true);
        }

        private void disable_Click(object sender, EventArgs e)
        {
            var check = checkedListBox4.CheckedItems;
            if (checkedListBox4.CheckedItems != null)
            {
                for (int i = 0; i < check.Count; i++)
                {
                    foreach (ServiceController service in services)
                    {
                        if (check[i].ToString() == service.DisplayName)
                        {
                            ServiceHelper.ChangeStartMode(service, ServiceStartMode.Manual);
                        }
                    }
                }
            }
            service_reload(true);
        }
        public static class ServiceHelper
        {
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern Boolean ChangeServiceConfig(
                IntPtr hService,
                UInt32 nServiceType,
                UInt32 nStartType,
                UInt32 nErrorControl,
                String lpBinaryPathName,
                String lpLoadOrderGroup,
                IntPtr lpdwTagId,
                [In] char[] lpDependencies,
                String lpServiceStartName,
                String lpPassword,
                String lpDisplayName);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern IntPtr OpenService(
                IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManager(
                string machineName, string databaseName, uint dwAccess);

            [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
            public static extern int CloseServiceHandle(IntPtr hSCObject);

            private const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
            private const uint SERVICE_QUERY_CONFIG = 0x00000001;
            private const uint SERVICE_CHANGE_CONFIG = 0x00000002;
            private const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;

            public static void ChangeStartMode(ServiceController svc, ServiceStartMode mode)
            {
                var scManagerHandle = OpenSCManager(null, null, SC_MANAGER_ALL_ACCESS);
                if (scManagerHandle == IntPtr.Zero)
                {
                    Debug.WriteLine("Error");
                }

                var serviceHandle = OpenService(
                    scManagerHandle,
                    svc.ServiceName,
                    SERVICE_QUERY_CONFIG | SERVICE_CHANGE_CONFIG);

                if (serviceHandle == IntPtr.Zero)
                {
                    Debug.WriteLine("Error");
                }

                var result = ChangeServiceConfig(
                    serviceHandle,
                    SERVICE_NO_CHANGE,
                    (uint)mode,
                    SERVICE_NO_CHANGE,
                    null,
                    null,
                    IntPtr.Zero,
                    null,
                    null,
                    null,
                    null);

                if (result == false)
                {
                    int nError = Marshal.GetLastWin32Error();
                    var win32Exception = new Win32Exception(nError);
                    MessageBox.Show("Не удалость изменить состояние автозагрузки\r\nЗапустите от имени Администратора");
                }

                CloseServiceHandle(serviceHandle);
                CloseServiceHandle(scManagerHandle);
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemChecked(i))
                {
                    Registry.CurrentUser.OpenSubKey(user[i], true).DeleteValue(checkedListBox2.Items[i].ToString());
                }
            }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                if (checkedListBox3.GetItemChecked(i))
                {
                    Registry.LocalMachine.OpenSubKey(local[i], true).DeleteValue(checkedListBox3.Items[i].ToString());
                }
            }
            button2_Click(sender, e);
        }
        private bool add = false;
        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "Выбирете службы, которые хотите добавить и нажмите ОК";
            service_reload(false);
            add = true;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (add)
            {
                if(checkedListBox4.CheckedItems != null)
                {
                    foreach (string nid in checkedListBox4.CheckedItems)
                    {
                        foreach(ServiceController serv in services)
                        {
                            if (serv.DisplayName == nid)
                            {
                                ServiceHelper.ChangeStartMode(serv, ServiceStartMode.Automatic);
                            }
                        }
                        
                    }
                }
            }
            service_reload(true);
            add = false;
            label6.Text = "Службы в режиме автозагрузки:";
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "\nHKEY_LOCAL_MACHINE:\n";
            richTextBox1.Text = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon").GetValue("Shell").ToString();
            string a = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon").GetValue("Shell").ToString();

            if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon").GetValue("Shell").ToString() != "explorer.exe")
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true).SetValue("Shell", "explorer.exe");
                //try
                //{
                //Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon", true).SetValue("Shell", "explorer.exe");
                //richTextBox1.Text += "На пути HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon был исправлен";
                //}
                //catch
                //{
                //richTextBox1.Text += "Не получилось заменить значение Shell на пути HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon, скорее всего у приожения недостаточно прав!\nЗапустите приложение от имени администратора\n\n";
                //}
            }
            else
            {
                richTextBox1.Text += "На пути HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon не найдено автозагрузок!\n";
            }

            if (Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders").GetValue("Common Startup").ToString() != "%ProgramData%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup")
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders", true).SetValue("Common Startup", "%ProgramData%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
                    richTextBox1.Text += "Автозагрузка на пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders была исправлен\n";
                }
                catch
                {
                    richTextBox1.Text += "К сожалению, у нас не получилось заменить автозагрузку в редакторе реестра по пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders\\Backup, либо данная папка отсутствует!\n";
                }
            }
            else
            {
                richTextBox1.Text += "На пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders не найдено автозагрузок!\n";
            }

            if(Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup").GetValue("CmdLine").ToString() == "")
            {
                richTextBox1.Text += "На пути HKEY_LOCAL_MACHINE\\SYSTEM\\Setup\\CmdLine нет автозагрузок\n";
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup").SetValue("CmdLine", "");
                    richTextBox1.Text += "Автозагрузка на пути HKEY_LOCAL_MACHINE\\SYSTEM\\Setup\\CmdLine была исправлен\n";
                }
                catch
                {
                    richTextBox1.Text += "К сожалению, у нас не получилось заменить автозагрузку в редакторе реестра по пути HKEY_LOCAL_MACHINE\\SYSTEM\\Setup\\CmdLine, либо данная папка отсутствует!\n Измените значение на ' '\n";
                }
            }

            if (Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup").GetValue("SetupType").ToString() == "0")
            {
                richTextBox1.Text += "Значение на пути HKEY_LOCAL_MACHINE\\SYSTEM\\Setup\\SetupType стандартное\n";
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("SYSTEM\\Setup").SetValue("SetupType", 0);
                    richTextBox1.Text += "Значение на пути HKEY_LOCAL_MACHINE\\SYSTEM\\Setup\\SetupType было исправлено\n";
                }
                catch
                {
                    richTextBox1.Text += "К сожалению, у нас не получилось заменить значение в редакторе реестра по пути HKEY_LOCAL_MACHINE\\SYSTEM\\Setup\\SetupType, либо данная папка отсутствует! Попробуйте запустить от имени администратора.\n Или измените значение StartType на 0\n";
                }
            }

            richTextBox1.Text += "\nHKEY_CURRENT_USER:\n";

            if (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders").GetValue("Startup").ToString() == "%ProgramData%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup")
            {
                try
                {
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders", true).SetValue("Startup", "%ProgramData%\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
                    richTextBox1.Text += "Автозагрузка на пути CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders была исправлен";
                }
                catch
                {
                    richTextBox1.Text += "К сожалению, у нас не получилось заменить автозагруску в редакторе реестра по пути HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders, либо данная папка отсутствует!\n\n";
                }
            }
            else
            {
                richTextBox1.Text += "На пути HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders не найдено автозагрузок!\n\n";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Add(1);
            }
            catch
            {
                MessageBox.Show("Папка с автозагрусками не найдена\r\nЗапустите от имени Администратора");
            }
        }
    }
}

