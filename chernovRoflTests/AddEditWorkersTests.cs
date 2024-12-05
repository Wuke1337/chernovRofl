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
    public class AddEditWorkersTests
    {
        [TestMethod()]
        public void CheckWrkTest()
        {
            Workers c = new Workers { ServID = 1, FIO = "ЧерновМихаилАлександрович" };
            bool expected = true;
            bool actual = AddEditWorkers.CheckWrk(c);
            Assert.AreEqual(expected, actual);
        }
    }
}