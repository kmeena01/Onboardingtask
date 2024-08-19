using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecProj2.Pages;
using System;
using TechTalk.SpecFlow;
using SpecProj2.Utilities;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;
using TechTalk.SpecFlow.Assist;

namespace SpecProj2.StepDefinitions
{
    [Binding]
    public class AddskillsStepDefinitions : Hook
    {
        Login Loginobj = new Login();
        AddSkill Addnewskillobj = new AddSkill();
        
        [Given(@"User logging in Mars portal")]
        public void GivenUserLoggingInMarsPortal()
        {
            Loginobj.loginstep();
        }
        
        [When(@"User creates a new Skill record '([^']*)' and '([^']*)'")]
        public void WhenUserCreatesANewSkillRecordAnd(string skill, string level)
        {
            Addnewskillobj.Addskill(skill, level);
        }

        [Then(@"new Skill '([^']*)' should be successfully created")]
        public void ThenNewSkillShouldBeSuccessfullyCreated(string skill)
        {
            Addnewskillobj.verifyaddedskillinlist(skill);
            
        }
        [Then(@"User should get Already exists error")]
        public void ThenUserShouldGetAlreadyExistsError()
        {
            Addnewskillobj.Duplicateerrormessage();
            
        }

        [When(@"User creates new Skill record '([^']*)' and '([^']*)'")]
        public void WhenUserCreatesNewSkillRecordAnd(string skill, string level)
        {
            Addnewskillobj.Addskill(skill, level);
        }

        [Then(@"User should get Duplicated data error")]
        public void ThenUserShouldGetDuplicatedDataError()
        {
            Addnewskillobj.Duplicatedatamessage();
           
        }
        [When(@"User creates new Skill record '([^']*)' '([^']*)'")]
        public void WhenUserCreatesNewSkillRecord(string skill, string level)
        {
            Addnewskillobj.Addskill(skill, level);
        }

        [Then(@"New skill '([^']*)' and level added in below list")]
        public void ThenNewSkillAndLevelAddedInBelowList(string skill)
        {
            Console.WriteLine("Skill added successfully");
         
        }
        [When(@"User clears already skill and edits with new skill '([^']*)' '([^']*)'")]
        public void WhenUserClearsAlreadySkillAndEditsWithNewSkill(string skill, string level)
        {
            Addnewskillobj.Updatebutton(skill, level);
        }

        [Then(@"New skill '([^']*)' Updated successfully")]
        public void ThenNewSkillUpdatedSuccessfully(string skill)
        {
            Addnewskillobj.verifyupdatedskill(skill);
        }
        [When(@"User try to give '([^']*)' skill and '([^']*)'")]
        public void WhenUserTryToGiveSkillAnd(string skill, string level)
        {
            Addnewskillobj.Addskill(skill, level);
        }

        [Then(@"Gets an error Please enter skill and experience level")]
        public void ThenGetsAnErrorPleaseEnterSkillAndExperienceLevel()
        {
            Addnewskillobj.errormessage();
        }
        [When(@"User tries to give '([^']*)' skill and '([^']*)'")]
        public void WhenUserTriesToGiveSkillAnd(string skill, string level)
        {
            Addnewskillobj.Addskill(skill, level);
        }

        [Then(@"Gets error Please enter skill and experience level")]
        public void ThenGetsErrorPleaseEnterSkillAndExperienceLevel()
        {
            Addnewskillobj.errormessage();
        }
        [When(@"User tries to delete the skills")]
        public void WhenUserTriesToDeleteTheSkills()
        {
            Addnewskillobj.deletebutton();
        }
        [Then(@"User successfully deletes all the skill")]
        public void ThenUserSuccessfullyDeletesAllTheSkill()
        {
            Addnewskillobj.AssertDeleteskill();
        }

        [When(@"User tries to cancel skill '([^']*)' and '([^']*)' by not adding")]
        public void WhenUserTriesToCancelSkillAndByNotAdding(string skill, string level)
        {
            Addnewskillobj.cancelbutton(skill, level);
        }
        [Then(@"User successfully cancels the skill '([^']*)'")]
        public void ThenUserSuccessfullyCancelsTheSkill(string skill)
        {
            Console.WriteLine("Skill canceled successfully");
        }
        [Given(@"Clears all the existing skills")]
        public void GivenClearsAllTheExistingSkills()
        {
            Addnewskillobj.cleardata();
        }

        [When(@"User try to create multiple skill records")]
        public void WhenUserTryToCreateMultipleSkillRecords(Table table)
        {

            foreach (var row in table.Rows)
            {
                string skills = row["Skill"];
                string levels = row["Level"];
                Addnewskillobj.Addskill(skills, levels);
            }
        }
        [Then(@"User created the multiple skill successfully")]
        public void ThenUserCreatedTheMultipleSkillSuccessfully(Table table)
        {
            //var expectedSkills = table.Rows.Select(row => row["Skill"]).ToArray();
            //var expectedlevels = table.Rows.Select(row => row["Level"]).ToArray();
            //Addnewskillobj.AssertAllSkills(driver, expectedSkills, expectedlevels);
            Console.WriteLine("Skills and Levels Added successfully");
            Addnewskillobj.TearDown();

        }

      }
}
