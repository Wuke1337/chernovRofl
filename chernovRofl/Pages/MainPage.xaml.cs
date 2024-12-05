using chernovRofl.AppData;
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

namespace chernovRofl.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new WorkersPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new SalariesPage());
        }

        private void VizislBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FiltrBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GroupBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RealFiltrBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new Otchet1Page());
        }

        private void PDFBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new PDFPage());
        }
    private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
