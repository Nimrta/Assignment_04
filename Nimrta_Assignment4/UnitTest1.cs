using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Nimrta_Assignment4
{
    
    public class UnitTest1
    {
        IWebDriver driver;

        public static string firstName { get; set; }
        public static string lastName { get; set; }
        public static string address { get; set; }
        public static string city { get; set; }
        public static string postalCode { get; set; }
        public static string phone { get; set; }
        public static string emailAddress{ get; set; }
        public static string age { get; set; }
        public static string experience { get; set; }
        public static string accidents { get; set; }


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Url = "http://localhost/prog8170a04/";

            string URL = driver.Url;

            Assert.AreEqual(URL, "http://localhost/prog8170a04/");
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//a[contains(text(),'Quote!')]")).Click();
            Thread.Sleep(1000);


        }

        [Test]
        public void TestValidData()
        {
            string URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/getQuote.html");
            Thread.Sleep(1500);

            //Arrange

            firstName = "TestFName";
            lastName = "TestLName";
            address = "123 Street test";
            city = "Test City";
            postalCode = "A1A 1A1";
            phone = "111-111-1111";
            emailAddress = "test@gmail.com";
            age = "25";
            experience = "3";
            accidents = "0";

            //Act
            EnterInformation();

            //Assert
            URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/viewQuote.html?1");
            Thread.Sleep(2000);

        }

        public void EnterInformation()
        {
            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);

            IWebElement provinceElement = driver.FindElement(By.Id("province"));

            SelectElement dropdown = new SelectElement(provinceElement);
            dropdown.SelectByText("NL");

            driver.FindElement(By.Id("postalCode")).SendKeys(postalCode);
            driver.FindElement(By.Id("phone")).SendKeys(phone);
            driver.FindElement(By.Id("email")).SendKeys(emailAddress);

            driver.FindElement(By.Id("age")).SendKeys(age);
            driver.FindElement(By.Id("experience")).SendKeys(experience);
            driver.FindElement(By.Id("accidents")).SendKeys(accidents);

            Thread.Sleep(2000);

            driver.FindElement(By.Id("btnSubmit")).Click();

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
