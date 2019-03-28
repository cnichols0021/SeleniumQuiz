using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Quiz
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("et_pb_contact_name_1")).SendKeys("Quiz Time");
            driver.FindElement(By.Id("et_pb_contact_message_1")).SendKeys("Quiz Passed!!!");
            string digits = driver.FindElement(By.ClassName("et_pb_contact_captcha_question")).Text;
            string firstDigit = driver.FindElement(By.XPath("//input[@data-first_digit]")).GetAttribute("data-first_digit");
            string secondDigit = driver.FindElement(By.XPath("//input[@data-second_digit]")).GetAttribute("data-second_digit");
            Console.WriteLine(digits);
            Console.WriteLine(firstDigit);
            Console.WriteLine(secondDigit);
            int sum = Int32.Parse(firstDigit) + Int32.Parse(secondDigit);
            Console.WriteLine(sum);
            driver.FindElement(By.Name("et_pb_contact_captcha_1")).SendKeys(sum.ToString());
            driver.FindElement(By.XPath("(//button[contains(text(),'Submit')])[2]")).Click();
            driver.Quit();
        }
    }
}
