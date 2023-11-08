using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Windows.Controls;

namespace LibMas
{
    public static class LibMas
    {
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length;i++)
            {
                res.Columns.Add("col" + (i +1),typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        public static void SaveMass(int[] mas)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.Write(mas.Length);
                for (int i = 0;i < mas.Length;i++)
                {
                    file.Write(mas[i]);
                }
                file.Close();
            }
        }
        public static int[] OpenMass(int[] mas)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Dct afqks (*.*) | *.* |Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Сохранение таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int len = Convert.ToInt32(file.ReadLine());
                mas = new Int32[len];
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
                return mas;
            }
            else
            {
                if (mas == null)
                {
                    int[] m = new int[1];
                    m[0] = 0;
                    return m;
                }
                else 
                { 
                    return mas; 
                }
            }

        }
    }
}
