using NUnit.Framework;
using RA;
using RestAssured;
using ClassLibrary1;
using ClassLibrary2;
using RestSharp;
using System;
using System.Text.RegularExpressions;

namespace TwoApiTest
{
    [TestFixture]

    public class Tests
    {

        [Test]
        public void Test1()
        {
            var library1 = new Class1();
            var response = library1.GetUsers();

            // проверка, на то, что имена файлов-аватаров пользователей совпадают
            for (int i = 0; i < response.data.Count; i++)
            {
                // проверка, с использованием ренгулярного выражения
                Assert.AreEqual(Convert.ToInt32(Regex.Replace(response.data[i].avatar, @"[^\d]+", "")), response.data[i].id, "Error");
                // порверка на наличие id в email с омощью метода Contains
                Assert.IsTrue(response.data[i].avatar.Contains(response.data[i].id.ToString()));
            }

            for (int i = 0; i < response.data.Count; i++)
            {
                Assert.IsTrue(response.data[i].email.EndsWith("reqres.in"));
            }
        }

        [Test]
        public void Test2()
        {
            var library2 = new Class2();
            library2.name();
        }
    }
}