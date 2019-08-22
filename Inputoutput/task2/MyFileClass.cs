using System;
using System.IO;


namespace task2
{
    //Статический для работы с файлами
    static class MyFileClass
    {
        //Метод создания файла
        public static void CreateFile(string filePath)
        {
            var file = new FileStream(filePath, FileMode.Create);
            file.Close();
            Console.WriteLine("Пустой файл создан!");
        }

        //Метод записи в файл
        public static void WriteInFile(string filePath)
        {
            try
            {
                var file = new FileStream(filePath, FileMode.Open);
                //Создание потока для записи в файл одним из возможных способов
                var strWrite = new StreamWriter(file);
                Console.WriteLine("Введите строку текста в файл:");
                strWrite.WriteLine(Console.ReadLine());
                strWrite.Close();
                file.Close();
                Console.WriteLine("Файл сохранен!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл удален или не был создан");
            }
        }

        //Метод чтения в файл
        public static void ReadFromFile(string filePath)
        {

            try
            {
                //Создание потока для чтения из файла одним из возможных способов
                var strRead = File.OpenText(filePath);
                Console.WriteLine("Текст в файле:");
                Console.WriteLine(strRead.ReadLine());
                strRead.Close();
                Console.WriteLine("Файл прочтён!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл удален или не был создан");
            }
        }

        public static void Delete(string filePath)
        {
            File.Delete(filePath);
            Console.WriteLine("Файл Удален!");
        }
    }
}
