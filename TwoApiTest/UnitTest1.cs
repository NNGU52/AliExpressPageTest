using NUnit.Framework;
using RA;
using RestAssured;
using ClassLibrary1;
using ClassLibrary2;
using RestSharp;
using System;
using System.Text.RegularExpressions;
using ClassLibrary3;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary4;
using ClassLibrary5;

namespace TwoApiTest
{
    [TestFixture]

    public class Tests
    {
        /*
         * ��������� ������ http://reqres.in/, �������� ������ ������������� �� ������ ��������;
         * ���������, ��� ����� ������-�������� ������������� ���������;
         * ���������, ��� email ������������� ����� ��������� reqres.in;
         */

        [TestCase]
        public void Test1()
        {
            var library1 = new Class1();
            var response = library1.GetUsers();

            Assert.AreEqual(library1.expectedCodeInt, library1.statusCodeInt, "Error statusCode");

            for (int i = 0; i < response.data.Count; i++)
            {
                // ��������, � �������������� ������������ ���������
                Assert.AreEqual(Convert.ToInt32(Regex.Replace(response.data[i].avatar, @"[^\d]+", "")), response.data[i].id, "Error");
                // �������� �� ������� id � email � ������ ������ Contains
                Assert.IsTrue(response.data[i].avatar.Contains(response.data[i].id.ToString()));
            }

            for (int i = 0; i < response.data.Count; i++)
            {
                Assert.IsTrue(response.data[i].email.EndsWith("reqres.in"));
            }
        }

        /*
         * ��������� ������ http://reqres.in/, �������������� ����������� ����������� � �������;
         * ���������� �������� 2 ������:
         * - �������� �����������;
         * - ����������� � �������� ��-�� ���������� ������;
         * - ��������� ���� ������;
         */

        [TestCase]
        public void Test2()
        {
            var library2 = new Class2();
            var response = library2.SuccessfulResultRegistration();

            Assert.AreEqual(library2.expectedCodeSuccessful, library2.statusCodeIntSuccessful, "Error statusCode");

            Assert.NotNull(response.id, "NULL");
            Assert.NotNull(response.token, "NULL");

            Assert.AreEqual(library2.id, response.id, "Error registration");
            Assert.AreEqual(library2.token, response.token, "Error registration");
        }

        [TestCase]
        public void Test3()
        {
            var library2 = new Class2();
            var response = library2.UnSuccessfulRegistration();

            Assert.AreEqual(library2.expectedCodeUnSuccessful, library2.statusCodeIntUnSuccessful, "Error statusCode");
            Assert.AreEqual("Missing password", response.Error, "Error");
        }

        /*
         * ��������� ������ http://reqres.in/, ���������, ��� �������� LIST<RESOURCE> ���������� ������, ��������������� �� �����;
         */

        [TestCase]
        public void Test4()
        {
            var library3 = new Class3();
            var response = library3.Years();
            var expectedSortDate = response.OrderBy(x => x);

            Assert.AreEqual(library3.expectedCodeInt, library3.statusCodeInt, "Error statusCode");
            Assert.IsTrue(expectedSortDate.SequenceEqual(response), "The sort years is wrong");
        }

        /*
        * ��������� ������ http://reqres.in/, ����������� ������� ������� ������������ � �������� ������-���;
        */

        [TestCase]
        public void Test5()
        {
            var library4 = new Class4();
            var response = library4.DeleteMethod();
            Assert.AreEqual(library4.expectedCodeInt, response, "Error statusCode");
        }

        /*
        * ��������� ������ http://reqres.in/, �������� ���������� � ������������ � �������� ���� ���������� � ������� ����� �� ������;
        */

        [TestCase]
        public void Test6()
        {
            var library5 = new Class5();
            string dateUpdate = library5.PutMethod();
            DateTimeOffset dateToday = DateTime.Today;
            string s = Regex.Replace(dateToday.ToString(), @"\s\d:\d{2}:\d{2}\s\+\d{2}:\d{2}", "");

            Assert.AreEqual(s, dateUpdate, "Error");
        }
    }
}