using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMas;
using Lib_2;
using System.Security.Policy;

namespace Prakt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] mas;
        int colich = -1;
        bool bbod = false;
        public void Close(object sender, RoutedEventArgs e)//Закрывает программу
        {//Скобка
            this.Close();//Закрытие окна
        }//Скобка
        public void Imputing(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(Pole.Text, out int n) == true) //Если ввод данных удачный
            {
                Pole.Text = "";
                if (!bbod)
                {
                    Nadpis.Content = "Введите 1 число массива";
                    colich = 0;
                    mas = new int[n];
                    bbod = true;
                }
                else
                {
                    if (colich < mas.Length)
                    {
                        mas[colich] = n;
                        colich += 1;
                        Nadpis.Content = "Введите " + (colich+1) + " число массива";
                        if (colich == mas.Length)
                        {
                            Nadpis.Content = "Введите число n";
                            Massiv.ItemsSource = LibMas.LibMas.ToDataTable(mas).DefaultView;
                            SumNad.Content = Lib_2.Lib_2.sumB15(mas);
                            bbod = false;
                        }
                    }
                }
            }
            else
            {
                if (!bbod)
                {
                    Nadpis.Content = "Введите ЧИСЛО n";
                }
                else 
                {
                    Nadpis.Content = "Введите " + (colich + 1) + " ЧИСЛО массива";
                }
            }
        }
        public void SvFile(object sender, RoutedEventArgs e)
        {
            if (!bbod)
            {
                LibMas.LibMas.SaveMass(mas);
            }
        }
        public void OpFile(object sender, RoutedEventArgs e)
        {
            if (!bbod)
            {
                mas = LibMas.LibMas.OpenMass(mas);
                Massiv.ItemsSource = LibMas.LibMas.ToDataTable(mas).DefaultView;
            }
        }
    }
}
