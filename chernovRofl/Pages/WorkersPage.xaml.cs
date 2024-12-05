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
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
            WorkersLV.ItemsSource = Class1.context.Workers.ToList();
            var f = Class1.context.Workers.ToList();
            f.Insert(0, new Workers() { FIO = "По умолчанию" });
            SortCmb.ItemsSource = new[] { "По умолчанию", "По возрастанию", "По убыванию" };
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditWorkers(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delWorkers = WorkersLV.SelectedItems.Cast<Workers>().ToList();
            foreach (var delWorker in delWorkers) // цикл проверrи наличия в учетной таблице данных на справочной
                if (Class1.context.Workers.Any(x => x.ServID == delWorker.ServID))
                {
                    MessageBox.Show("Данные используются в таблице зарплаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delWorkers.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Class1.context.Workers.RemoveRange(delWorkers);
            try
            {
                Class1.context.SaveChanges();
                WorkersLV.ItemsSource = Class1.context.Workers.ToList();
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
            WorkersLV.ItemsSource = Class1.context.Workers.ToList();
        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditWorkers((sender as Button).DataContext as Workers));
        }
        private void Poisktol_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void SortCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        void Update()
        {
            var p = Class1.context.Workers.ToList();
            var h = Class1.context.Workers.ToList();

            //Поиск
            if (Poisktol.Text.Length > 0)
                p = p.Where(cx => cx.FIO.ToLower().Contains(Poisktol.Text.ToLower())).ToList();
            WorkersLV.ItemsSource = p;

            //Сортировка
            switch (SortCmb.SelectedIndex)
            {
                case 1:
                    p = p.OrderBy(x => x.ServID).ToList();
                    break;
                case 2:
                    p = p.OrderByDescending(x => x.ServID).ToList();
                    break;
            }
            WorkersLV.ItemsSource = p;
        }
    }
}
