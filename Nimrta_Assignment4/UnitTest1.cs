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
        

    
        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
