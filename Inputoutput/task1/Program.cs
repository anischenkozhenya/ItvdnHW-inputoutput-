using System;
using System.Diagnostics;
using System.IO;


//Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их.

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Путь к папке в которой будут создаваться и удаляться новые папки
            string folder = @"..\..\WorkFolder\";


            DirectoryInfo directory = new DirectoryInfo(folder);

            //Открытие рабочей папки
            Process.Start("explorer.exe", folder);

            Console.WriteLine("Подпапок в папке " + directory.Name + " " + directory.GetDirectories().Length);
            Console.WriteLine("Для удаления нажмите кнопку");
            Console.ReadKey();

            //Создание 100 новых папок
            for (int i = 0; i < 100; i++)
            {
                directory.CreateSubdirectory("Folder_" + i.ToString());
            }


            Console.WriteLine("Подпапок в папке " + directory.Name + " " + directory.GetDirectories().Length);
            Console.WriteLine("Для удаления нажмите кнопку");
            Console.ReadKey();

            //удаление папок

            //Первый вариант
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Directory.Delete(directory.ToString() + "\\Folder_" + i.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //Второй вариант
            //DirectoryInfo[] dirarray = directory.GetDirectories();
            //for (int i = 0; i < 100; i++)
            //{
            //    foreach(var dir in dirarray)
            //    {
            //        if(dir.Name=="Folder_" + i.ToString())
            //        {
            //            dir.Delete();
            //        }
            //    }
            //}
            Console.WriteLine("Подпапок в папке " + directory.Name + " " + directory.GetDirectories().Length);
            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();

        }
    }
}
