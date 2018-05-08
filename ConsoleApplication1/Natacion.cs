
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;


namespace ConsoleApplication1
{
    class Natacion
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ThePruebaNatacionTest()
        {
            Console.WriteLine("✔ Navegando a http://natacioncs.com/blog/");
            driver.Navigate().GoToUrl("http://natacioncs.com/blog/");

            Console.WriteLine("✔ Click para navegar");
            driver.FindElement(By.XPath("//div[@id='page-content']/div[2]/header")).Click();
            driver.FindElement(By.XPath("//div[@id='page-content']/div[2]/header/p")).Click();
            driver.FindElement(By.XPath("//div[@id='page-content']/div[2]/header/p")).Click();
            try
            {
                Console.WriteLine("✔ Comparando si el texto aparece");
                Assert.AreEqual("Blog de natación creado por el equipo de NatacionCS y sus atletas para los apasionados a la natación.", driver.FindElement(By.XPath("//div[@id='page-content']/div[2]/header/p")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            Console.WriteLine("✔ Buscando art'iculo: la importancia de los bañadores");
            driver.FindElement(By.XPath("//div[@id='postlist']/article/div[2]")).Click();
            Assert.AreEqual("La importancia del tejido en los bañadores de natación", driver.FindElement(By.LinkText("La importancia del tejido en los bañadores de natación")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }
}
