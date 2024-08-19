using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using NUnit.Framework;
using SpecProj2.Utilities;

namespace SpecProj2.Pages
{
    public class AddSkill : CommonDriver
    {
       
        public void Addskill(string Skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill_tab.Click();
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            driver.FindElement(By.Name("name")).SendKeys(Skill);
            IWebElement Levelchoice = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            Levelchoice.Click();
            IWebElement levelvalue = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            levelvalue.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Add']")));
            IWebElement Add = driver.FindElement(By.XPath("//input[@value='Add']"));
            Add.Click();
            Thread.Sleep(5000);
        }
        public void cancelbutton(string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill_tab.Click();
            IWebElement AddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddNewButton.Click();
            driver.FindElement(By.Name("name")).SendKeys(skill);
            IWebElement Levelchoice = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            Levelchoice.Click();
            IWebElement levelvalue = driver.FindElement(By.XPath($"//div[@class='five wide field']/select[@name='level']/option[@value='{level}']"));
            levelvalue.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@class='ui button' and @value='Cancel']")));
            IWebElement cancel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
            cancel.Click();
        }
        public void verifyaddedskillinlist(string skill)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement list = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(list.Text == skill, "skill not added successfully. Test failed");
        }
        public void Duplicateerrormessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string errorMessageText = errorMessage.Text;
            Assert.That(errorMessage.Text == "This skill is already exist in your skill list.", "Already exists");

        }
        public void Duplicatedatamessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string errorMessageText = errorMessage.Text;
            Assert.That(errorMessage.Text == "Duplicated data", "Duplicate data");

        }
        public void errormessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string errorMessageText = errorMessage.Text;
            Assert.That(errorMessage.Text == "Please enter skill and experience level", "error displays");

        }
      
        public void cleardata() {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skillbutton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillbutton.Click();
            while (true)
            {
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")));
                    // Find the delete button for the last record
                    IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));
                    deleteButton.Click();
                    Thread.Sleep(1000);
                }
                catch (NoSuchElementException)
                {
                    // Break the loop if no more delete buttons are found
                    break;
                }
                catch (WebDriverTimeoutException)
                {
                    // Break the loop if the delete button is not found within the wait time
                    break;
                }
            }
        }
        public void TearDown()
        {
            driver.Quit();
        }
        public void deletebutton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill_tab.Click();
            IWebElement deletebutton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deletebutton.Click();

        }
        public void AssertDeleteskill()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement list = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (list == null)
            {
                Console.WriteLine("skill deleted successfully");
            }
            else
            {
                Console.WriteLine("skill not deleted successfully");

            }
        }
        public void Updatebutton(string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill_tab.Click();
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

        public void verifyupdatedskill(string skill)
        {
            IWebElement list = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));

            Assert.That(list.Text == skill, "Language not updated successfully. Test failed");

        }
    }
}

