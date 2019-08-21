using System;
using System.IO;

//Создайте файл, запишите в него произвольные данные и закройте файл.Затем снова откройте
//этот файл, прочитайте из него данные и выведете их на консоль.

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileStream("file.txt", FileMode.OpenOrCreate);
            var strwrite = new StreamWriter(file);
            Console.WriteLine("Введите строку текста в файл");
            strwrite.WriteLine(Console.ReadLine());
            strwrite.Close();
            file.Close();
            Console.WriteLine("Файл сохранен\nДля открытия нажмите любую кнопку...");
            Console.ReadKey();
            var strread = File.OpenText("file.txt");
            Console.WriteLine("текст в файле:");
            Console.WriteLine(strread.ReadLine());
            strread.Close();
            Console.ReadKey();
            Console.WriteLine("Файл прочтён\nДля удаления нажмите любую кнопку...");
            File.Delete("file.txt");
            Console.ReadKey();
        }
    }
}
