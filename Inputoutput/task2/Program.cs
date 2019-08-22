using System;
using System.Diagnostics;
using System.IO;

//Создайте файл, запишите в него произвольные данные и закройте файл.Затем снова откройте
//этот файл, прочитайте из него данные и выведете их на консоль.

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Относительный путь к папке
            string path = @"..\..";
            
            //Открытие папки для наглядности
            Process.Start("explorer.exe", path);
            Console.WriteLine("Папка открыта для наглядности\nВедите имя нового файла:");

            //Ввод имени файла
            string fileName = Console.ReadLine();

            //Путь к файлу
            string filePath = path + @"\" + fileName;

            //Создание или открытие файла
            MyFileClass.CreateFile(filePath);

            //Создание или открытие файла
            MyFileClass.WriteInFile(filePath);  
            Console.WriteLine("Для открытия нажмите любую кнопку...");
            Console.ReadKey();

            //Чтения из файла
            MyFileClass.ReadFromFile(filePath);

            Console.WriteLine("Для удаления нажмите любую кнопку...");
            Console.ReadKey();

            //Удаление файла
            MyFileClass.Delete(filePath);            ;

            Console.WriteLine("Для удаления нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
