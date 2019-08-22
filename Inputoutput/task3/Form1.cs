using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
//Напишите приложение для поиска заданного файла на диске.Добавьте код, использующий
//класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
//добавьте возможность сжатия найденного файла.
namespace task3
{
    public partial class Form1 : Form
    {
        //Массив путей
        public string[] path = { };

        public Form1()
        {
            InitializeComponent();

            //Получение физических дисков
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                {
                    comboBox1.Items.Add(drive.Name.ToString());
                }
            }
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Очистка Listbox
            listBox1.Items.Clear();

            //Обнуление переменной
            path = new string[] {};

            //Имя файла
            string fileName = textBox1.Text;
            DirectoryInfo directory = new DirectoryInfo(comboBox1.Text);
            listBox1.Items.Add("search start");

            //Поиск файлов в папках на диске
            //нет доступа с системным папкам
            Search(directory, fileName);
            //Для примера с папками имя файла "exemple.txt"
            //Search(new DirectoryInfo(@"..\..\.."), fileName);
            listBox1.Items.Add("search finish");
            void Search(DirectoryInfo dr, string file)
            {
                FileInfo[] files = dr.GetFiles();
                foreach (var item in files)
                {
                    if (file == item.Name)
                    {
                        
                        listBox1.Items.Add("Файл найден");
                        listBox1.Items.Add(item.FullName);
                        path = path.Add(item.FullName);
                        StreamReader reader = File.OpenText(item.FullName.ToString());
                        while (!reader.EndOfStream)
                        {
                            listBox1.Items.Add(reader.ReadLine());
                        }
                        reader.Close();
                        listBox1.Items.Add("Весь файл записан");
                    }
                }
                DirectoryInfo[] dirs = dr.GetDirectories();
                foreach (DirectoryInfo directoryInfo in dirs)
                {
                    Search(directoryInfo, file);
                }
            }
        }

        private void BtnArchivin_Click(object sender, EventArgs e)
        {
            btnArchivin.Text= "Архивация...";
            if (path.Length == 0)
            {
                MessageBox.Show("файл не найден");
            }
            else
            {
                for (int i = 0; i < path.Length; i++)
                {
                    FileStream fileStream = File.OpenRead(path[i]);
                    FileStream fileStream2 = File.Create(path[i] + ".zip");
                    GZipStream gZipStream = new GZipStream(fileStream2, CompressionMode.Compress);
                    int bt = fileStream.ReadByte();
                    while (bt != -1)
                    {
                        gZipStream.WriteByte((byte)bt);
                        bt = fileStream.ReadByte();
                    }
                    gZipStream.Close();
                    listBox1.Items.Add("Заархивировано");
                }
            }
            btnArchivin.Text = "Заархивировано";
        }     
    }
}
