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
    /// Логика взаимодействия для AddEditWorkers.xaml
    /// </summary>
    public partial class AddEditWorkers : Page
    {
        Workers worker;
        bool checkNew;
        public AddEditWorkers(Workers w)
        {
            InitializeComponent();
            if (w == null)
            {
                w = new Workers();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = worker = w;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Class1.context.Workers.Add(worker);
            }
            try
            {
                Class1.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }


        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
        public static bool CheckWrk(Workers c)
        {
            if (string.IsNullOrEmpty(c.FIO) || !c.FIO.All(char.IsLetter))
                return false;
            return true;
        }
    }
}
