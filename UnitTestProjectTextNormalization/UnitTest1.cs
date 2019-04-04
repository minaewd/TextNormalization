using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextNormalization;

namespace UnitTestProjectTextNormalization
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAppRegExp()
        {
            // исходные данные
            string expected = "HeLL o wOrl d";

            // получение значения с помощью тестируемого метода
            string actual = FormNormalization.AppRegExp("HeLL()o wOrl*/d");

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
    }
}
