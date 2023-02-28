using NUnit.Framework;
using RA;
using RestAssured;
using ClassLibrary1;
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
            var library = new Class1();
            var response = library.GetUsers();

            // ��������, �� ��, ��� ����� ������-�������� ������������� ���������
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
    }
}