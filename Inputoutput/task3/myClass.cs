
namespace task3
{
    public static class myClass
    {
        //Расширяющий метод
        public static string[] Add(this string[] str, string path)
        {
            string[] a = str;
            str = new string[str.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                str[i] = a[i];
            }
            str[str.Length - 1] = path;
            return str;
        }
    }
}
