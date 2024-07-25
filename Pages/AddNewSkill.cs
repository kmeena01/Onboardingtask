using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using NUnit.Framework;

namespace SpecProj2.Pages
{
    public class AddNewSkill
    {
        public void navigatetoskill(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")));
            IWebElement skillbutton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillbutton.Click();
        }

        public void Addskill(IWebDriver driver, string Skill, string level)
        {
            IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill_tab.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
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
        public void cancelbutton(IWebDriver driver, string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
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
        public void verifyaddedskillinlist(IWebDriver driver, string skill)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")));
            IWebElement list = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            Assert.That(list.Text == skill, "skill added successfully");
        }
        public void Duplicateerrormessage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string errorMessageText = errorMessage.Text;
            Assert.That(errorMessage.Text == "This skill is already exist in your skill list.", "Already exists");

        }
        public void Duplicatedatamessage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string errorMessageText = errorMessage.Text;
            Assert.That(errorMessage.Text == "Duplicated data", "Duplicate data");

        }
        public void errormessage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//div[@class='ns-box-inner']")));
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            string errorMessageText = errorMessage.Text;
            Assert.That(errorMessage.Text == "Please enter skill and experience level", "error displays");

        }
        public void Addmultipleskill(IWebDriver driver, string Skill)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //IWebElement skill_tab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            //skill_tab.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")));
            driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
            //IWebElement Addskill = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
            //Addskill.SendKeys(Skill);
            IWebElement AddSkillTextbox = driver.FindElement(By.Name("name"));
            AddSkillTextbox.SendKeys(Skill);
            IWebElement SkillDropDownButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            SkillDropDownButton.Click();
            IWebElement Beginnerleveloption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
            Beginnerleveloption.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Add']")));
            IWebElement Add = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            Add.Click();
            Thread.Sleep(5000);
        }
        public void cleardata(IWebDriver driver) {
            
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
                    Thread.Sleep(3000);
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
        public void TearDown(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}

