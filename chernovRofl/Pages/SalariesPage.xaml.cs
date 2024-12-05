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
using chernovRofl.AppData;

namespace chernovRofl.Pages
{
    /// <summary>
    /// Логика взаимодействия для SalariesPage.xaml
    /// </summary>
    public partial class SalariesPage : Page
    {
        public SalariesPage()
        {
            InitializeComponent();
            SalariesLV.ItemsSource = Class1.context.Salaries.ToList();
            var f = Class1.context.Salaries.ToList();
            f.Insert(0, new Salaries() { Month = "По умолчанию" });
            var g = Class1.context.Salaries.ToList();
            g.Insert(0, new Salaries() { ProcPay = 0 });
            Filt1Cmb.ItemsSource = f;
            Filt2Cmb.ItemsSource = f;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditSalaries(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delSalaries = SalariesLV.SelectedItems.Cast<Salaries>().ToList();
            if (MessageBox.Show($"Удалить {delSalaries.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Class1.context.Salaries.RemoveRange(delSalaries);
            try
            {
                Class1.context.SaveChanges();
                SalariesLV.ItemsSource = Class1.context.Salaries.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void RefrBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new MainPage());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SalariesLV.ItemsSource = Class1.context.Salaries.ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditSalaries((sender as Button).DataContext as Salaries));
        }
        private void Poisktol_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Filt1Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void Filt2Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        void Update()
        {
            var p = Class1.context.Salaries.ToList();
            var h = Class1.context.Salaries.ToList();

            //Поиск
            if (Poisktol.Text.Length > 0)
                p = p.Where(cx => cx.Month.ToLower().Contains(Poisktol.Text.ToLower()) || cx.ProcPay.ToString().Contains(Poisktol.Text.ToLower())).ToList();
            SalariesLV.ItemsSource = p;

            //Фильтрация
            if (Filt1Cmb.SelectedIndex > 0)
            {
                var selectedFiltr = Filt1Cmb.SelectedItem as Salaries;
                p = p.Where(cx => cx.Salary == selectedFiltr.Salary).ToList();
            }
            if (Filt2Cmb.SelectedIndex > 0)
            {
                var selectedFiltr = Filt2Cmb.SelectedItem as Salaries;
                p = p.Where(cx => cx.ProcPay == selectedFiltr.ProcPay).ToList();
            }
            SalariesLV.ItemsSource = p;
        }      
    }
}
