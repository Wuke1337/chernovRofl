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
    /// Логика взаимодействия для AddEditSalaries.xaml
    /// </summary>
    public partial class AddEditSalaries : Page
    {
        Salaries salaries;
        bool checkNew;
        public AddEditSalaries(Salaries s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new Salaries();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = salaries = s;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Class1.context.Salaries.Add(salaries);
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

        public static bool CheckSrs(Salaries c)
        {
            if (string.IsNullOrEmpty(c.Month) || !c.Month.All(char.IsLetter))
                return false;
            return true;
        }
    }
}
