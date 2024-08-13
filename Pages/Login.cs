using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecProj2.Utilities;

namespace SpecProj2.Pages
{
    internal class Login : Hook
    {
        public void loginstep() 
        {            
            IWebElement siginbutton = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
            siginbutton.Click();
            Thread.Sleep(1000);
            try
            {
                IWebElement emailaddressTextbox = driver.FindElement(By.Name("email"));
                emailaddressTextbox.SendKeys("ctmeena@gmail.com");
            }
            catch (Exception ex)
            {
                //Assert.Fail("Confirm your email", ex.Message);
                Assert.Fail(ex.Message);
            }
            IWebElement passwordTextBox = driver.FindElement(By.Name("password"));
            passwordTextBox.SendKeys("Sriram_007");
            IWebElement loginbutton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginbutton.Click();
            Thread.Sleep(1000);

        }
    }
}
