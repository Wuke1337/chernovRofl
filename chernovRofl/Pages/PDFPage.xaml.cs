using chernovRofl.AppData;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для PDFPage.xaml
    /// </summary>
    public partial class PDFPage : Page
    {
        public PDFPage()
        {
            InitializeComponent();
            var vizisl = Class1.context.Salaries
              .Select(g => new
              {
                  ServID = g.ServID,
                  FIO = g.Workers.FIO,
                  Salary = g.Salary,
                  DaysIllnes = g.DaysIllnes,
                  ProcPay = g.ProcPay,
                  Sum = g.Salary * g.ProcPay / 100M * g.DaysIllnes

              }).ToList();
            OtchetDG.ItemsSource = vizisl;
        }

        private void OtchetBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем новый документ PDF
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("Зарплата.pdf", FileMode.Create));
                doc.Open();

                // Устанавливаем шрифт
                BaseFont baseFont = BaseFont.CreateFont(@"C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);

                // Создаем таблицу с 6 столбцами
                PdfPTable table = new PdfPTable(6);

                // Добавляем заголовки таблицы
                table.AddCell(new PdfPCell(new Phrase("Табельный номер", font)));
                table.AddCell(new PdfPCell(new Phrase("Фамилия, имя, отчество", font)));
                table.AddCell(new PdfPCell(new Phrase("Среднедневная зарплата", font)));
                table.AddCell(new PdfPCell(new Phrase("Количество дней болезни", font)));
                table.AddCell(new PdfPCell(new Phrase("Процент оплаты", font)));
                table.AddCell(new PdfPCell(new Phrase("Сумма", font)));

                // Переменная для хранения общей стоимости
                decimal totalCost = 0;

                // Заполняем таблицу данными
                foreach (var item in Class1.context.Salaries.ToList())
                {
                    decimal itemCost = item.Salary * item.ProcPay / 100M * item.DaysIllnes;
                    totalCost += itemCost; // Суммируем сумму

                    table.AddCell(new Phrase(item.ServID.ToString(), font));
                    table.AddCell(new Phrase(item.Workers.FIO.ToString(), font));
                    table.AddCell(new Phrase(item.Salary.ToString(), font));
                    table.AddCell(new Phrase(item.DaysIllnes.ToString(), font));
                    table.AddCell(new Phrase(item.ProcPay.ToString(), font));
                    table.AddCell(new Phrase(itemCost.ToString(), font));
                }

                // Добавляем строку "Итого"
                table.AddCell(new PdfPCell(new Phrase("Итого", font)) { Colspan = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new Phrase(totalCost.ToString(), font));

                // Добавляем таблицу в документ
                doc.Add(table);
                doc.Close();

                MessageBox.Show("Pdf-документ сохранен");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Pdf-документ не сохранен: {ex.Message}", "Ошибка!");
            }
        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new MainPage());
        }
    }
}
