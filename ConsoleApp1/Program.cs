using Microsoft.Win32;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] paths_array = new string[6] {"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run" };

        int a;
        Console.WriteLine("HKEY_CURRENT_USER: \n");
        for (int c = 0; c < 6; c++)
        {   
            if(Registry.CurrentUser.OpenSubKey(paths_array[c]) != null)
            {
                a = Registry.CurrentUser.OpenSubKey(paths_array[c]).GetValueNames().Length;

                for (int b = 0; b < a; b++)
                {
                    Console.WriteLine("\t" + Registry.CurrentUser.OpenSubKey(paths_array[c]).GetValueNames()[b] + "\n\t\tЗначение: " + Registry.CurrentUser.OpenSubKey(paths_array[c]).GetValue(Registry.CurrentUser.OpenSubKey(paths_array[c]).GetValueNames()[b]) + "\n\t\tПуть в реестре: " + "HKEY_CURRENT_USER\\" + paths_array[c] + "\n\n");
                }
            }
            else
            {
                Console.WriteLine("\tПуть HKEY_CURRENT_USER\\" + paths_array[c] + " не был найден в реестре!\n\n");
            }
        }



        Console.WriteLine("\n\n\n\n\nHKEY_LOCAL_MACHINE:\n");

        for (int c = 0; c < 6; c++)
        {
            if (Registry.LocalMachine.OpenSubKey(paths_array[c]) != null)
            {
                a = Registry.LocalMachine.OpenSubKey(paths_array[c]).GetValueNames().Length;

                for (int b = 0; b < a; b++)
                {
                    Console.WriteLine("\t" + Registry.LocalMachine.OpenSubKey(paths_array[c]).GetValueNames()[b] + "\n\t\tЗначение: " + Registry.LocalMachine.OpenSubKey(paths_array[c]).GetValue(Registry.LocalMachine.OpenSubKey(paths_array[c]).GetValueNames()[b]) + "\n\t\tПуть в реестре: " + "HKEY_CURRENT_USER\\" + paths_array[c] + "\n\n");
                }
            }
            else
            {
                Console.WriteLine("\tПуть HKEY_LOCAL_MACHINE\\" + paths_array[c] + " не был найден в реестре!\n\n\n");
            }
        }




        //if(Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders").GetValue("Common Startup").ToString() == "%USERPROFILE%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup")
        //{
        //    try
        //    {
        //        Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders", true).SetValue("Common Startup", "%USERPROFILE%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
        //        Console.WriteLine("Автозагрузка на пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders была исправлен");
        //    }
        //    catch 
        //    {
        //        Console.WriteLine("К сожалению, у нас не получилось заменить автозагруску в редакторе реестра по пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders\\Backup, либо данная папка отсутствует!\n");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("На пути HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders не найдено автозагрузок!\n");
        //}


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


        if(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon").GetValue("Shell").ToString()  != "explorer.exe")
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
}