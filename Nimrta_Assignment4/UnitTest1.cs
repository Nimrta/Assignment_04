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



        [Test]
        public void TestFirstNameOmitted()
        {
            string URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/getQuote.html");
            Thread.Sleep(1500);

            //Arrange
            firstName = "";
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

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("firstName-error")).Text;

            Assert.AreEqual("First Name is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestLastNameOmitted()
        {
            string URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/getQuote.html");
            Thread.Sleep(1500);

            //Arrange
            firstName = "TestFName";
            lastName = "";
            address = "123 Street test";
            city = "Test City";
            postalCode = "A1A 1A1";
            phone = "111-111-1111";
            emailAddress = "test@gmail.com";
            age = "26";
            experience = "3";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("lastName-error")).Text;

            Assert.AreEqual("Last Name is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestInvalidPhoneNumber()
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
            phone = "1111111111";
            emailAddress = "test@gmail.com";
            age = "27";
            experience = "3";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("phone-error")).Text;

            Assert.AreEqual("Phone Number must follow the patterns 111-111-1111 or (111)111-1111", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestInvalidEmailAddress()
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
            emailAddress = "testgmail.com";
            age = "28";
            experience = "3";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("email-error")).Text;

            Assert.AreEqual("Must be a valid email address", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestInvalidPostalCode()
        {
            string URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/getQuote.html");
            Thread.Sleep(1500);

            //Arrange
            firstName = "TestFName";
            lastName = "TestLName";
            address = "123 Street test";
            city = "Test City";
            postalCode = "A1A1A1";
            phone = "111-111-1111";
            emailAddress = "test@gmail.com";
            age = "35";
            experience = "17";
            accidents = "1";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("postalCode-error")).Text;

            Assert.AreEqual("Postal Code must follow the pattern A1A 1A1", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestAgeOmitted()
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
            age = "";
            experience = "5";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("age-error")).Text;

            Assert.AreEqual("Age (>=16) is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestAccidentsOmitted()
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
            age = "37";
            experience = "8";
            accidents = "";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.Id("btnSubmit"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("accidents-error")).Text;

            Assert.AreEqual("Number of accidents is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestExperienceOmitted()
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
            age = "45";
            experience = "";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.Id("btnSubmit"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("experience-error")).Text;

            Assert.AreEqual("Years of experience is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestPhoneNumberOmitted()
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
            phone = "";
            emailAddress = "test@gmail.com";
            age = "27";
            experience = "3";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("phone-error")).Text;

            Assert.AreEqual("Phone Number is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestEmailOmitted()
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
            emailAddress = "";
            age = "28";
            experience = "3";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("email-error")).Text;

            Assert.AreEqual("email address is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestPostalOmitted()
        {
            string URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/getQuote.html");
            Thread.Sleep(1500);

            //Arrange
            firstName = "TestFName";
            lastName = "TestLName";
            address = "123 Street test";
            city = "Test City";
            postalCode = "";
            phone = "111-111-1111";
            emailAddress = "test@gmail.com";
            age = "35";
            experience = "17";
            accidents = "1";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("postalCode-error")).Text;

            Assert.AreEqual("Postal Code is required", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestAgeBelow16()
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
            age = "10";
            experience = "5";
            accidents = "0";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetErrorMsg = driver.FindElement(By.Id("age-error")).Text;

            Assert.AreEqual("Please enter a value greater than or equal to 16.", GetErrorMsg);
            Thread.Sleep(2000);
        }

        [Test]
        public void TestCustomerInformationOmitted()
        {
            string URL = driver.Url;
            Assert.AreEqual(URL, "http://localhost/prog8170a04/getQuote.html");
            Thread.Sleep(1500);

            //Arrange
            firstName = "";
            lastName = "";
            address = "";
            city = "";
            postalCode = "";
            phone = "";
            emailAddress = "";
            age = "38";
            experience = "12";
            accidents = "1";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.XPath("//div[contains(text(),'Customer Information')]"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetFirstNameErrorMsg = driver.FindElement(By.Id("firstName-error")).Text;
            string GetLastNameErrorMsg = driver.FindElement(By.Id("lastName-error")).Text;
            string GetAddressErrorMsg = driver.FindElement(By.Id("address-error")).Text;
            string GetCityErrorMsg = driver.FindElement(By.Id("city-error")).Text;
            string GetPostalCodeErrorMsg = driver.FindElement(By.Id("postalCode-error")).Text;
            string GetPhoneErrorMsg = driver.FindElement(By.Id("phone-error")).Text;
            string GetEmailErrorMsg = driver.FindElement(By.Id("email-error")).Text;

            Assert.AreEqual("First Name is required", GetFirstNameErrorMsg);
            Assert.AreEqual("Last Name is required", GetLastNameErrorMsg);
            Assert.AreEqual("Address is required", GetAddressErrorMsg);
            Assert.AreEqual("City is required", GetCityErrorMsg);
            Assert.AreEqual("Postal Code is required", GetPostalCodeErrorMsg);
            Assert.AreEqual("Phone Number is required", GetPhoneErrorMsg);
            Assert.AreEqual("email address is required", GetEmailErrorMsg);

            Thread.Sleep(2000);
        }

        [Test]
        public void TestCustomerDrivingInformationOmitted()
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
            age = "";
            experience = "";
            accidents = "";

            //Act
            EnterInformation();

            IWebElement Form = driver.FindElement(By.Id("btnSubmit"));
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Form);
            Thread.Sleep(1000);

            //Assert
            string GetAgeErrorMsg = driver.FindElement(By.Id("age-error")).Text;
            string GetExperienceErrorMsg = driver.FindElement(By.Id("experience-error")).Text;
            string GetAccidentsErrorMsg = driver.FindElement(By.Id("accidents-error")).Text;

            Assert.AreEqual("Age (>=16) is required", GetAgeErrorMsg);

            Assert.AreEqual("Years of experience is required", GetExperienceErrorMsg);

            Assert.AreEqual("Number of accidents is required", GetAccidentsErrorMsg);
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
