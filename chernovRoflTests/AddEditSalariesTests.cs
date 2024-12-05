using Microsoft.VisualStudio.TestTools.UnitTesting;
using chernovRofl.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chernovRofl.AppData;

namespace chernovRofl.Pages.Tests
{
    [TestClass()]
    public class AddEditSalariesTests
    {
        [TestMethod()]
        public void CheckSrsTest()
        {
            Salaries c = new Salaries { RecordID = 2, Month = "Февраль" };
            bool expected = true;
            bool actual = AddEditSalaries.CheckSrs(c);
            Assert.AreEqual(expected, actual);
        }
    }
}