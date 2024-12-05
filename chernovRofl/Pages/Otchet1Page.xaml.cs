using Microsoft.Office.Interop.Excel;
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
using Excel = Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;
using System.Drawing;
using chernovRofl.AppData;

namespace chernovRofl.Pages
{
    /// <summary>
    /// Логика взаимодействия для Otchet1Page.xaml
    /// </summary>
    public partial class Otchet1Page : Page
    {
        public Otchet1Page()
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
            //Объявляем приложение
            Excel.Application app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Ведомость";

            // Установили шрифт
            sheet.Cells.Font.Name = "Times New Roman";

            // Системная дата
            sheet.Cells[1, 1].Value = $"Дата: {DateTime.Now.ToString("dd.MM.yyyy")}";
            sheet.Cells[1, 1].Font.Bold = true;

            //Оглавление
            Range r = sheet.get_Range("A2");
            r.Font.Bold = true;
            r.VerticalAlignment = XlVAlign.xlVAlignCenter;
            r.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            sheet.Cells[2, 1].Value = "Ведомость начисления сумм по больничному";
            Range r1 = sheet.Cells[2, 1];
            Range r2 = sheet.Cells[2, 6];
            Range mR = sheet.get_Range(r1, r2);
            mR.Merge();

            //Названия столбцов
            Range nazv = sheet.get_Range("A4", "F4");
            nazv.Font.Bold = true;
            nazv.VerticalAlignment = XlVAlign.xlVAlignTop;
            nazv.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            nazv.Rows.RowHeight = 25;

            sheet.Cells[4, 1].Value = "Табельный номер";
            sheet.Cells[4, 2].Value = "Фамилия, имя, отчество";
            sheet.Cells[4, 3].Value = "Среднедневная зарплата";
            sheet.Cells[4, 4].Value = "Количество дней болезни";
            sheet.Cells[4, 5].Value = "Процент оплаты";
            sheet.Cells[4, 6].Value = "Сумма";

            //Содержимое
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

            int currow = 5;
            foreach (var item in vizisl)
            {
                sheet.Cells[currow, 1].Value = item.ServID;
                sheet.Cells[currow, 2].Value = item.FIO;
                sheet.Cells[currow, 3].Value = item.Salary;
                sheet.Cells[currow, 4].Value = item.DaysIllnes;
                sheet.Cells[currow, 5].Value = item.ProcPay;
                sheet.Cells[currow, 6].Value = item.Sum;
                currow++;
            }
            r1 = sheet.Cells[4, 1];
            r2 = sheet.Cells[currow - 1, 6];
            mR = sheet.get_Range(r1, r2);
            mR.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
            sheet.Columns.AutoFit();

            //Итого
            int totalRow = currow;
            Range iR = sheet.Cells[totalRow, 1].Resize[1, 5];
            iR.Merge();
            iR.Value2 = "Итого: ";
            iR.Font.Bold = true;
            iR.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            iR.VerticalAlignment = XlVAlign.xlVAlignCenter;
            iR.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
            //Счёт в итоге
            Range j = sheet.Cells[totalRow, 6];
            j.Font.Bold = true;
            j.FormulaLocal = "=СУММ(F5:F16)";
            j.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new MainPage());
        }
    }
}
