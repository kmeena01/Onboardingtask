using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using NUnit.Framework;

namespace SpecProj2.Pages
{
    public class Editskill
    {
        public void Updatebutton(IWebDriver driver, string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")));
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editbutton.Click();
            IWebElement Addskill = driver.FindElement(By.Name("name"));
            Addskill.Clear();
            driver.FindElement(By.Name("name")).SendKeys(skill);
            IWebElement Levelchoice = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
            Levelchoice.Click();
            IWebElement levelvalue = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            levelvalue.Click();
            driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")).Click();
            Thread.Sleep(1000);   
        }

        public void verifyupdatedskill(IWebDriver driver, string skill)
        {
            IWebElement list = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            
            Assert.That(list.Text == skill, "Language updated successfully");

        }
    }
}
