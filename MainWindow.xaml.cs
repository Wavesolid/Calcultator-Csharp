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

namespace Calculator_.NET_Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        SelectedOperator selectedoperator;
        public MainWindow()
        {
            InitializeComponent();
            resultButton.Click += ResultButton_Click;
            percentButton.Click += PercentButton_Click;
            minPlusButton.Click += MinPlusButton_Click;
            acButton.Click += AcButton_Click;
        }
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
        private void MinPlusButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }
        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber /= 100;
                operatorLabel.Content = "%";
                resultLabel.Content = lastNumber.ToString();
            }
        }
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == plusButton)
            {
                selectedoperator = SelectedOperator.Pertambahan;
                operatorLabel.Content = "+";
            }
            if (sender == minusButton)
            {
                selectedoperator = SelectedOperator.Pengurangan;
                operatorLabel.Content = "-";
            }
            if (sender == multiplyButton)
            {
                selectedoperator = SelectedOperator.Perkalian;
                operatorLabel.Content = "*";
            }
            if (sender == divideButton)
            {
                selectedoperator = SelectedOperator.Pembagian;
                operatorLabel.Content = "/";
            }
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() is "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        private void ComaButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains(","))
            {
                // Kosong
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content},";
            }
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            Console.WriteLine(lastNumber);
            if(double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedoperator)
                {
                    case SelectedOperator.Pertambahan:
                        result = Hitung.Pertambahan(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Pengurangan:
                        result = Hitung.Pengurangan(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Perkalian:
                        result = Hitung.Perkalian(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Pembagian:
                        result = Hitung.Pembagian(lastNumber, newNumber);
                        break;
                }
                operatorLabel.Content = "";
                resultLabel.Content = result.ToString();
            }
        }
    }
    public enum SelectedOperator
    {
        Pertambahan,
        Pengurangan,
        Perkalian,
        Pembagian
    }
    public class Hitung
    {
        public static double Pertambahan(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Pengurangan(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Perkalian(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Pembagian(double n1, double n2)
        {
            if(n2 is 0)
            {
                MessageBox.Show("You can't divide by 0", "Number is Wrong", MessageBoxButton.OK, MessageBoxImage.Hand);
                return 0;
            }
            return n1 / n2;
        }
    }
}
