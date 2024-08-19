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
using SpecProj2.Utilities;

namespace SpecProj2.StepDefinitions
{
    [Binding]
    public class AddlangStepDefinitions : CommonDriver
    {
        Login Loginobj = new Login();
        Addlanguage Addlanguageobj = new Addlanguage();
              

        [Given(@"User logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            Loginobj.loginstep();
        }
        [When(@"User creates a new Language record '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewLanguageRecord(string language, string level)
        {
            Addlanguageobj.cleardata();
            Addlanguageobj.addlanguage(language, level);
        }
        [Then(@"new Language '([^']*)' and '([^']*)' should be successfully created")]
        public void ThenNewLanguageAndShouldBeSuccessfullyCreated(string language, string level)
        {
            Addlanguageobj.verifyaddedinlist(language, level);
        }
        [When(@"User enters new Language '([^']*)' '([^']*)'")]
        public void WhenUserEntersNewLanguage(string language, string level)
        {
            Addlanguageobj.addlanguage(language, level);
        }
        [Then(@"Language '([^']*)' and '([^']*)' should be successfully created")]
        public void ThenLanguageAndShouldBeSuccessfullyCreated(string language, string level)
        {
           Addlanguageobj.verifyaddedinlist(language, level);
        }



        [When(@"User enters new Language '([^']*)' and '([^']*)'")]
        public void WhenUserEntersNewLanguageAnd(string language, string level)
        {
            Addlanguageobj.addlanguage(language, level);
        }


        [Then(@"User gets Error message as Duplicate Data")]
        public void ThenUserGetsErrorMessageAsDuplicateData()
        {
            Addlanguageobj.Duplicateerrormessage();
        }

        [When(@"clean the existing data and add new language '([^']*)'")]
        public void WhenCleanTheExistingDataAndAddNewLanguage(string language)
        {
            Addlanguageobj.updatebutton(language);
        }

        [Then(@"new Language '([^']*)' Updated successfully")]
        public void ThenNewLanguageUpdatedSuccessfully(string language)
        {
            Console.WriteLine("Language updated successfully");
        }
        [When(@"User creates a new Language with empty language '([^']*)' and '([^']*)' record")]
        public void WhenUserCreatesANewLanguageWithEmptyLanguageAndRecord(string language, string level)
        {
            Addlanguageobj.addlanguage(language, level);
        }

        [Then(@"User should gets an error message")]
        public void ThenUserShouldGetsAnErrorMessage()
        {
            Addlanguageobj.errormessage();
        }
        [When(@"User enters a new Language '([^']*)' record and click cancel")]
        public void WhenUserEntersANewLanguageRecordAndClickCancel(string language)
        {
            Addlanguageobj.cancelbutton(language);
        }
        [Then(@"Entered'([^']*)' language canceled and not display in below list")]
        public void ThenEnteredLanguageCanceledAndNotDisplayInBelowList(string language)
        {
            Addlanguageobj.verifycanceledinlist(language);
        }
        [When(@"User clears all languages data in the list")]
        public void WhenUserClearsAllLanguagesDataInTheList()
        {
            Addlanguageobj.deletedata();
        }
        [Then(@"All language in the list deleted successfully")]
        public void ThenAllLanguageInTheListDeletedSuccessfully()
        {
            Addlanguageobj.AssertDeletelanguage();
        }
        [When(@"User enter new Language '([^']*)' '([^']*)'")]
        public void WhenUserEnterNewLanguage(string language, string level)
        {
            Addlanguageobj.addlanguage(language, level);
        }
        [Then(@"Language '([^']*)' and '([^']*)' should successfully created")]
        public void ThenLanguageAndShouldSuccessfullyCreated(string language, string level)
        {
            Addlanguageobj.verifyaddedinlist(language, level);
        }


        [When(@"User try to create multiple languages records")]
        public void WhenUserTryToCreateMultipleLanguagesRecords(Table table)
        {
            Addlanguageobj.cleardata();
            foreach (var row in table.Rows)
            {
                string languages = row["Language"];
                string levels = row["Level"];
                Addlanguageobj.addlanguage(languages, levels);
            }
        }


            [Then(@"User created multiple records successfully")]
        public void ThenUserCreatedMultipleRecordsSuccessfully(Table table)
        {
                var expectedLanguages = table.Rows.Select(row => row["Language"]).ToArray();
            Addlanguageobj.AssertAllLanguages(expectedLanguages);
        }

    }
}
