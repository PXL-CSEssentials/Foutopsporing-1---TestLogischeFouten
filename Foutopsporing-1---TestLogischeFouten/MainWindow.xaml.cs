using System;
using System.Collections.Generic;
using System.IO;
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

namespace Foutopsporing_1___TestLogischeFouten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            // Oorspronkelijke foute code
            int product = 0;
            int counter = 1;
            int number = 0;
            resultTextBox.Text = "";
            number = System.Convert.ToInt32(numberTextBox.Text);
            while (product <= 1000 || counter <= 51)
            {
                product = number * counter;
                resultTextBox.Text = resultTextBox.Text + counter.ToString() + " x " +
                    number.ToString() + " = " + product.ToString() + "\r\n";
                counter++;
            }

            // Getest door getallen 17, 21, -17 en -21 in te lezen in txtGetal
            // Verbetering: 
            // * Voorwaarde in while moet && hebben ipv. || en 50 ipv. 51
            // * Vang de FormatException en OverflowException op van Convert.ToInt32()
            // * Als je geen negatief getal wil toelaten, dan moet je dit ook eerst testen
        }

        private void start2Button_Click(object sender, RoutedEventArgs e)
        {
            int product = 0;
            int counter = 1;
            int number = 0;
            resultTextBox.Text = "";
            number = System.Convert.ToInt32(numberTextBox.Text);
            while (product <= 1000 && counter < 51)
            {
                product = number * counter;
                resultTextBox.Text = resultTextBox.Text + counter.ToString() + " x " +
                    number.ToString() + " = " + product.ToString() + "\r\n";
                counter++;
            }

            // Getest door getallen 17, 21, -17 en -21 in te lezen in txtGetal
            // Verbetering: 
            // * Vang de FormatException en OverflowException op van Convert.ToInt32()
            // * Als je geen negatief getal wil toelaten, dan moet je dit ook eerst testen
        }

        private void startCorrectButton_Click(object sender, RoutedEventArgs e)
        {

            int product = 0;
            int counter = 1;
            int number = 0;
            resultTextBox.Text = "";
            errorLabel.Content = "";
            try
            {
                number = System.Convert.ToInt32(numberTextBox.Text);
            }
            catch (FormatException)
            {
                errorLabel.Content = "(Alleen natuurlijke getallen worden toegestaan)";
                return;
            }
            catch (OverflowException)
            {
                errorLabel.Content = "(Getal is te groot)";
                return;
            }
            if (number < 0)
            {
                errorLabel.Content = "(Geef een natuurlijk getal in)";
                return;
            }

            while (product <= 1000 && counter <= 50)
            {
                product = number * counter;
                resultTextBox.Text = resultTextBox.Text + counter.ToString() + " x " +
                    number.ToString() + " = " + product.ToString() + "\r\n";
                counter++;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            numberTextBox.Clear();
            resultTextBox.Clear();
            errorLabel.Content = string.Empty;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void showImageButton_Click(object sender, RoutedEventArgs e)
        {
            int number = rnd.Next(10); // willekeurig getal van 0 t.e.m. 9
            string fileName = $@"../..\images\zee{number}.jpg";
            showImage.Source = new BitmapImage(
                new Uri(AppDomain.CurrentDomain.BaseDirectory + fileName, UriKind.RelativeOrAbsolute));
        }

        // Let op de Content van deze Button in de XAML file:
        // Content="Toon beeld&#xa;met controle"
        // We gebruiken &#xa; voor een nieuwe regel!
        private void showImageButtonWithCheck_Click(object sender, RoutedEventArgs e)
        {
            int number = rnd.Next(10); // willekeurig getal van 0 t.e.m. 9
            string fileName = $@"../..\images\zee{number}.jpg";
            try
            {
                showImage.Source = new BitmapImage(
                    new Uri(AppDomain.CurrentDomain.BaseDirectory + fileName, UriKind.RelativeOrAbsolute));
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Afbeelding niet aanwezig.", "Fout", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
