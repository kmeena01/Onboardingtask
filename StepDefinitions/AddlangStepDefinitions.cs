using OpenQA.Selenium;
using System;
using SpecProj2.Pages;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Reflection.Emit;
using OpenQA.Selenium.Support.UI;

namespace SpecProj2.StepDefinitions
{
    [Binding]
    public class AddlangStepDefinitions
    {
        IWebDriver driver = new ChromeDriver();
        Login Loginobj = new Login();
        Addmultiplelanguage Addmultiplelanguageobj = new Addmultiplelanguage();
        Editlanguage Editlanguageobj = new Editlanguage();
        Deletelanguage deletelanguageobj = new Deletelanguage();

        [Given(@"User logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            Loginobj.login(driver);
        }
        [When(@"User creates a new Language record '([^']*)'")]
        public void WhenUserCreatesANewLanguageRecord(string language)
        {
            Addmultiplelanguageobj.cleardata(driver);
            Addmultiplelanguageobj.addlanguage(driver, language);
        }
        [Then(@"new Language '([^']*)' should be successfully created")]
        public void ThenNewLanguageShouldBeSuccessfullyCreated(string language)
        {
            Addmultiplelanguageobj.verifyaddedinlist(driver, language);
            Addmultiplelanguageobj.TearDown(driver);
        }
       
        [When(@"User enters new Language '([^']*)'")]
        public void WhenUserEntersNewLanguage(string language)
        {
            Addmultiplelanguageobj.addlanguage(driver, language);
        }

        [Then(@"User gets Error message as Duplicate Data")]
        public void ThenUserGetsErrorMessageAsDuplicateData()
        {
            Addmultiplelanguageobj.Duplicateerrormessage(driver);
            Addmultiplelanguageobj.TearDown(driver);
        }

        [When(@"clean the existing data and add new language '([^']*)'")]
        public void WhenCleanTheExistingDataAndAddNewLanguage(string language)
        {
            Editlanguageobj.updatebutton(driver, language);
        }

        [Then(@"new Language '([^']*)' Updated successfully")]
        public void ThenNewLanguageUpdatedSuccessfully(string language)
        {
            Console.WriteLine("Language updated successfully");
            Addmultiplelanguageobj.TearDown(driver);
        }
               
        [When(@"User creates a new Language with empty language '([^']*)' record")]
        public void WhenUserCreatesANewLanguageWithEmptyLanguageRecord(string language)
        {
            Addmultiplelanguageobj.addlanguage(driver, language);
        }

        [Then(@"User should gets an error message")]
        public void ThenUserShouldGetsAnErrorMessage()
        {
            Addmultiplelanguageobj.errormessage(driver);
            Addmultiplelanguageobj.TearDown(driver);
        }
        [When(@"User enters a new Language '([^']*)' record and click cancel")]
        public void WhenUserEntersANewLanguageRecordAndClickCancel(string language)
        {
            Addmultiplelanguageobj.cancelbutton(driver, language);
        }
        [Then(@"Entered'([^']*)' language canceled and not display in below list")]
        public void ThenEnteredLanguageCanceledAndNotDisplayInBelowList(string language)
        {
            Addmultiplelanguageobj.verifycanceledinlist(driver, language);
            Addmultiplelanguageobj.TearDown(driver);
        }
        [When(@"User clears all languages data in the list")]
        public void WhenUserClearsAllLanguagesDataInTheList()
        {
            deletelanguageobj.deletedata(driver);
        }
        [Then(@"All language in the list deleted successfully")]
        public void ThenAllLanguageInTheListDeletedSuccessfully()
        {
            deletelanguageobj.AssertDeletelanguage(driver);
            Addmultiplelanguageobj.TearDown(driver);
        }

        [When(@"User try to create multiple language records")]
        public void WhenUserTryToCreateMultipleLanguageRecords(Table table)
        
            {
            Addmultiplelanguageobj.cleardata(driver);
            foreach (var row in table.Rows)
                {
                    string languages = row["Language"];
                    Addmultiplelanguageobj.addlanguage(driver, languages);
                }
            }


            [Then(@"User created multiple records successfully")]
        public void ThenUserCreatedMultipleRecordsSuccessfully(Table table)
        {
                var expectedLanguages = table.Rows.Select(row => row["Language"]).ToArray();
                Addmultiplelanguageobj.AssertAllLanguages(driver, expectedLanguages);
            Addmultiplelanguageobj.TearDown(driver);
        }

    }
}
