using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Media;

//Создайте приложение WPF Application, позволяющее пользователям сохранять данные в
//изолированное хранилище.
//Для выполнения этого задания необходимо наличие библиотеки Xceed.Wpf.Toolkit.dll.Ее
//можно получить через References -> Manage NuGet Packages… -> в поиске написать Extended
//WPF Toolkit (помимо интересующей нас библиотеки будут установлены и другие), или же
//скачать непосредственно на сайте http://wpftoolkit.codeplex.com/ и подключить в проект только
//интересующую нас бибилиотеку(References -> Add Reference …).
//1. Разместите в окне Label и Button.
//2. Разместите в окне ColorPicker (данный инструмент предоставляется вышеуказанной
//библиотекой). Для этого необходимо в XAML коде в теге Window подключить пространство
//имен xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" . Также, нам понадобиться событие
//Loaded окна.
//3. Реализуйте, чтобы при выборе цвета из ColorPicker в Label выводилось название
//выбранного цвета и в этот цвет закрашивался фон Label.По нажатию на кнопку, данные о
//цвете сохраняются в изолированное хранилище.При запуске приложения заново, цвет фона
//Label остается таким, каким был сохранен при предыдущих запусках приложения.
namespace task4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetUserStoreForAssembly();
            InitializeComponent();
            string color;
            try
            {
                IsolatedStorageFileStream isolatedStorageFileStream =
                new IsolatedStorageFileStream("ColorLabel.cfg",
                FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader reader = new StreamReader(isolatedStorageFileStream);
                color = reader.ReadLine();
                Label1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
                Label1.Content = color;
                reader.Close();
            }
            catch (Exception e)
            {
                Label1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
                Label1.Content = "#00000000";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.MessageBox.Show("Сохранено.перезапустите приложение");
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            IsolatedStorageFileStream isolatedStorageFileStream =
                new IsolatedStorageFileStream("ColorLabel.cfg",
                FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(isolatedStorageFileStream);
            Label1.Content = Colorpicker1.SelectedColor.Value;
            Label1.Background = new SolidColorBrush(Colorpicker1.SelectedColor.Value);
            writer.WriteLine(Label1.Background.ToString());
            writer.Close();
        }
    }
}
